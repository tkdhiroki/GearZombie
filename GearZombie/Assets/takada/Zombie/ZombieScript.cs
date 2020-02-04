using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;


public class ZombieScript : MonoBehaviour
{
    [SerializeField] private ZombiesJobList zombie = null;

    [SerializeField] private Image HpBar = null;
    private int maxHp;

    private GameObject parent;
    private GameObject rootObj;

    private Transform initPos = null;
    //private List<Transform> initPos = new List<Transform>();

    // 城の耐久地
    private GameObject targetObject = null;

    private ZombieState currentState = ZombieState.None;

    private float attackRange = 2f;
    private float attackTime = 0;

    private void OnValidate()
    {
        this.GetComponent<SpriteRenderer>().sprite = zombie.Sprite;
        //targetObject = GameObject.FindGameObjectWithTag("---");
    }


    private void Start()
    {
        maxHp = zombie.Hp;
        parent = this.transform.parent.gameObject;
        rootObj = this.transform.root.gameObject;
        //Debug.Log(parent.name);
        initPos = GameObject.Find("InitPositon").GetComponent<Transform>();
        targetObject = GameObject.FindGameObjectWithTag("Castle");
        Init();
    }

    private void Update()
    {
        switch(currentState)
        {
            case ZombieState.None:
                break;
            case ZombieState.Move:
                Moving();
                AttackCheck();
                break;
            case ZombieState.Attack:
                Attack();
                break;
            case ZombieState.Death:
                DeathZombie();
                break;
        }
    }

    /// <summary>
    /// ダメージ処理
    /// </summary>
    /// <param name="damage">ダメージ量</param>
    public void Damaged(int damage)
    {
        int hp = zombie.Hp - damage;
        HpBar.fillAmount = hp / maxHp;
        zombie.Hp = hp;
        if(zombie.Hp <= 0)
        {
            currentState = ZombieState.Death;
        }
    }

    private float InitRandomHeight()
    {
        float minmax = 4.0f;

        return UnityEngine.Random.Range(-minmax, minmax);
    }

    public void Init()
    {
        //Debug.Log("Call");
        float y = InitRandomHeight();
        parent.transform.position = initPos.position + new Vector3(0, y);
        //Observable.EveryUpdate()
        //    .Subscribe(_ =>
        //    {

        //    }).AddTo(this.gameObject);
        //this.gameObject.SetActive(true);

        currentState = ZombieState.Move;
    }

    //private void ZombieMove()
    //{
    //    this.UpdateAsObservable()
    //        .Subscribe( _ => Moving() );

    //    Observable.EveryUpdate()
    //              .Subscribe(_ => Moving())
    //              .AddTo(this.gameObject);
    //}

    private void Moving()
    {
        float speed = zombie.Speed / 10.0f;
        float step = speed * Time.deltaTime;
        Vector3 pos = Vector3.zero;
        pos.x = Vector3.MoveTowards(parent.transform.position, targetObject.transform.position, step).x;
        parent.transform.position = new Vector3(pos.x, parent.transform.position.y, 0);
    }

    private void DeathZombie()
    {
        currentState = ZombieState.None;
        this.gameObject.SetActive(false);
        parent.transform.GetChild(1).gameObject.SetActive(false);
        //Destroy(parent);
        rootObj.GetComponent<ZombieCreate>().FieldsZombieCount();
    }

    private void AttackCheck()
    {
        //float diff = Vector2.Distance(targetObject.transform.position, this.transform.position);
        float diff = parent.transform.position.x - targetObject.transform.position.x;

        // 攻撃可能範囲にいなければ攻撃
        if (diff > attackRange) return;

        currentState = ZombieState.Attack;
        //Observable.EveryUpdate()
        //          .Subscribe(_ => Attack())
        //          .AddTo(this.gameObject);
    }

    private void Attack()
    {
        attackTime += Time.deltaTime;

        if (attackTime > zombie.AttackSpeed)
        {
            // 城への攻撃処理
            CastleMgr.HpDecrease(zombie.Attack);

            attackTime = 0;
        }
    }
}

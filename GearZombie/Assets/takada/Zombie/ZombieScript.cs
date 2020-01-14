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

    private Transform initPos = null;
    //private List<Transform> initPos = new List<Transform>();

    // 城の耐久地
    private GameObject targetObject = null;

    private void OnValidate()
    {
        this.GetComponent<SpriteRenderer>().sprite = zombie.Sprite;
        //targetObject = GameObject.FindGameObjectWithTag("---");
    }


    private void Start()
    {
        maxHp = zombie.Hp;
        parent = this.transform.parent.gameObject;
        //Debug.Log(parent.name);
        initPos = GameObject.Find("InitPositon").GetComponent<Transform>();
        targetObject = GameObject.Find("target");
        //Debug.Log(targetObject.name);
        Init();
    }

    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    this.Init();
        //}
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
    }

    private float InitRandomHeight()
    {
        int minmax = 4;

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

        ZombieMove();
    }

    private void ZombieMove()
    {
        this.UpdateAsObservable()
            .Subscribe( _ => Moving() );

        Observable.EveryUpdate()
                  .Subscribe(_ => Moving())
                  .AddTo(this.gameObject);
    }

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
        parent.SetActive(false);
        
    }

    private void Attack()
    {

    }
}

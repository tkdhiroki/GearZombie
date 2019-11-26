using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieScript : MonoBehaviour
{
    [SerializeField] private ZombiesJobList zombie = null;

    [SerializeField] private Image HpBar = null;
    private int maxHp;

    private GameObject parent;
    [SerializeField] private Transform initPos = null;

    private void OnValidate()
    {
        this.GetComponent<SpriteRenderer>().sprite = zombie.Sprite;
    }


    private void Start()
    {
        maxHp = zombie.Hp;
        parent = this.transform.parent.gameObject;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.Init();
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
    }

    private void ZombieMove()
    {
        
    }

    private int InitRandomHeight()
    {
        int minmax = 4;

        return UnityEngine.Random.Range(-minmax, minmax);
    }

    public void Init()
    {
        int y = InitRandomHeight();
        parent.transform.position = initPos.position + new Vector3(0, y);
        ZombieMove();
    }

    private void DeathZombie()
    {
        parent.SetActive(false);
        
    }
}

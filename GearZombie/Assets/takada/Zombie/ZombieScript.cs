using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    [SerializeField] ZombiesJobList zombie = null;


    private void Start()
    {

    }

    /// <summary>
    /// ダメージ処理
    /// </summary>
    /// <param name="damage">ダメージ量</param>
    public void Damaged(int damage)
    {
        int hp = zombie.Hp - damage;
        zombie.Hp = hp;
    }

    private void ZombieMove()
    {

        
    }

    private void Init()
    {

    }
}

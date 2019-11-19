﻿using UnityEngine;

public enum ZombieJob
{
    Normal,
    Power,
    Speed,
    Cook,
    Pumpkin,
    Worker,
    Clown,
    Woman,
    Max
}

[CreateAssetMenu(menuName = "Zombie/Create ZombieTable", fileName = "a")]
public class ZombiesJobList : ScriptableObject
{
    //public ZombieParam zombieJob;
    [SerializeField] ZombieJob job;
    public ZombieJob Job { get { return job; } }
    [SerializeField] Sprite sprite;
    [SerializeField] int hp, attack, deffence, speed;
    public int Hp { get { return hp; } set { hp = value; } }
    public int Attack { get { return attack; } }
    public int Deffence { get { return deffence; } }
    public int Speed { get { return speed; } }
    [SerializeField] float attackSpeed;
    public float AttackSpeed { get { return attackSpeed; } }

    private Condition condition;
    public Condition Condition{ get { return condition; } set { condition = value; } }
}

//[System.Serializable]
//public struct ZombieParam
//{
//    [SerializeField] ZombieJob job;
//    public ZombieJob Job { get { return job;}}
//    [SerializeField] Sprite sprite;
//    [SerializeField] int hp, attack, deffence, speed;
//    public int Hp { get { return hp;}}
//    public int Attack { get { return attack;}}
//    public int Deffence { get { return deffence;}}
//    public int Speed { get { return speed;}}
//    [SerializeField] float attackSpeed;
//    public float AttackSpeed { get { return attackSpeed;}}
//}

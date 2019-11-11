using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieJob
{
    normal,
    Max
}

[CreateAssetMenu(menuName = "Zombie/Create ZombieTable", fileName = "aaa")]
public class ZombiesJobList : ScriptableObject
{
    public ZombieParam zombieJob;
}

[System.Serializable]
public struct ZombieParam
{
 //   [SerializeField] string name;
 //   public string Name { get { return name; } }
    [SerializeField] ZombieJob job;
    public ZombieJob Job { get { return job;}}
    [SerializeField] int hp, attack, deffence, speed;
    public int Hp { get { return hp;}}
    public int Attack { get { return attack;}}
    public int Deffence { get { return deffence;}}
    public int Speed { get { return speed;}}
    [SerializeField] float attackSpeed;
    public float AttackSpeed { get { return attackSpeed;}}
}

using UnityEngine;

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
    public Sprite Sprite { get { return sprite; } }
    // gearFuel -> ゾンビが落とす歯車の燃料になるもの
    [SerializeField] int hp, attack, /*deffence,*/ speed /*gearFuel*/;
    public int Hp { get { return hp; } set { hp = value; } }
    public int Attack { get { return attack; } }
    //public int Deffence { get { return deffence; } }
    public int Speed { get { return speed; } }
    //public int GearFuel { get { return gearFuel; } }
    [SerializeField] float attackSpeed;
    public float AttackSpeed { get { return attackSpeed; } }
    [SerializeField] ZombieState state;
    public ZombieState State { get { return state; } set { state = value; } }
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

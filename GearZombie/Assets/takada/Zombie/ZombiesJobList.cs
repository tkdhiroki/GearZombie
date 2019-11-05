using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieJob
{
    normal,
    Max
}

[CreateAssetMenu(menuName = "Zombie/Create ZombieTable", fileName = "ZombieTable")]
public class ZombiesJobList : ScriptableObject
{
    public List<ZombieParam> ZombiesList = new List<ZombieParam>();
}

[System.Serializable]
public struct ZombieParam
{
    public string Name;
    public ZombieJob job;
    public int HP, Attack, Deffence, Speed;
    public float AttackSpeed;
}

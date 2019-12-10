using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ZombieState", menuName = "GearZombie/ZombieState", order = 0)]
public class ZombieState : ScriptableObject 
{
    [Range(1, 10)]
    private int zombieVariety;     // 出現させるゾンビの種類

    [SerializeField] private List<ZombiesJobList> job = new List<ZombiesJobList>();

}

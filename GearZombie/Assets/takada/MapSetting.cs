using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MapSetting : ScriptableObject
{
    // 出現するゾンビのリスト
    // 出現数
    public List<WaveZoombieClass> wave = new List<WaveZoombieClass>();


}

[System.Serializable]
public struct WaveZoombieClass
{
    public List<ZombieSpawnClass> spawnClasses;
}

[System.Serializable]
public struct ZombieSpawnClass
{
    public ZombiesJobList zombieJob;
    public int spawnNum;
    public float spawnSpeed;
}

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
public class WaveZoombieClass
{
    public List<ZombieSpawnClass> spawnClasses = new List<ZombieSpawnClass>();
}

[System.Serializable]
public struct ZombieSpawnClass
{
    public ZombiesJobList zombieJob;
    public int spawnNum;
    public float spawnSpeed;
}

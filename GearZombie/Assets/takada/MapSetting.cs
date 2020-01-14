using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MapSetting : ScriptableObject
{
    // 出現するゾンビのリスト
    // 出現数
    public List<ZombieSpawnClass> spawnClasses = new List<ZombieSpawnClass>();
    //public List<WaveZoombieClass> wave = new List<WaveZoombieClass>();


}

//[System.Serializable]
//public class WaveZoombieClass
//{
    
//}

[System.Serializable]
public struct ZombieSpawnClass
{
    public ZombieJob zombieJob;
    public GameObject zombiePrefab;
    public int spawnNum;
    public float spawnSpeed;
}

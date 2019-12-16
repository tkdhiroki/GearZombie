using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCreate : MonoBehaviour
{
    [SerializeField] private MapSetting mapSetting = null;
    private Transform zombieBox;
    private List<ZombieSpawnClass> zombieSpawn = new List<ZombieSpawnClass>();

    private void Start()
    {
        zombieBox = this.transform;
        zombieSpawn = mapSetting.spawnClasses;

        // create zombie ( active => false )
        FieldZombieInit();
    }

    private void FieldZombieInit()
    {
        // count check
        if (zombieSpawn.Count < 1) return;

        // １マップ分のエネミー生成
        for (int listNum = 0; listNum < zombieSpawn.Count; listNum++)
        {
            for(int spawn = 0;spawn < zombieSpawn[listNum].spawnNum; spawn++)
            {
                var obj = Instantiate(zombieSpawn[listNum].zombiePrefab, zombieBox);
                obj.SetActive(false);
            }
        }
        #if UNITY_EDITOR
        Debug.Log(zombieBox.childCount);
        #endif
    }
    private void SpawnZombie()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCreate : MonoBehaviour
{
    [SerializeField] private GameObject obj = null;
    [SerializeField] private MapSetting mapSetting = null;
    [SerializeField] private Transform zombieBox;
    //private List<GameObject> zombieVariety = new List<GameObject>();
    private List<ZombieSpawnClass> zombieSpawn = new List<ZombieSpawnClass>();

    //private List<GameObject> fieldZombie = new List<GameObject>();

    // 生成するゾンビの箱を格納用
    private List<GameObject> zombieJobParent = new List<GameObject>();

    private float time = 0;
    private bool initTime = false;

    private void Awake()
    {
        zombieSpawn = mapSetting.spawnClasses;
        
        // create zombie ( active => false )
        FieldZombieInit();
    }

    //private void Update()
    //{
    //    if (!initTime) return;

    //    SpawnZombie();
    //}

    private void FieldZombieInit()
    {
        Debug.Log(zombieSpawn.Count);
        // count check
        if (zombieSpawn.Count < 1) return;


        // １マップ分のエネミー生成
        for (int listNum = 0; listNum < zombieSpawn.Count; listNum++)
        {
            Debug.Log(listNum);
            var parent = Instantiate(obj, zombieBox);
            parent.name = zombieSpawn[listNum].zombiePrefab.name;

            parent.AddComponent<ZombieGenerateGame>();
            var comp = parent.GetComponent<ZombieGenerateGame>();
            comp.SetZombieNum = zombieSpawn[listNum].spawnNum;      // 数
            comp.SetZombieSpeed = zombieSpawn[listNum].spawnSpeed;  // 速度
            zombieJobParent.Add(parent);

            //zombieVariety.Add(Instantiate(new List<GameObject>()));

            for (int spawn = 0; spawn < zombieSpawn[listNum].spawnNum; spawn++)
            {
                var obj = Instantiate(zombieSpawn[listNum].zombiePrefab, zombieJobParent[listNum].transform);
                obj.SetActive(false);
            }

        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;

public class ZombieCreate : MonoBehaviour
{
    [SerializeField] private MapSetting mapSetting = null;
    [SerializeField] private Transform zombieBox;
    //private List<GameObject> zombieVariety = new List<GameObject>();
    private List<ZombieSpawnClass> zombieSpawn = new List<ZombieSpawnClass>();

    private List<GameObject> fieldZombie = new List<GameObject>();

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
            //zombieVariety.Add(Instantiate(new List<GameObject>()));

            for (int spawn = 0; spawn < zombieSpawn[listNum].spawnNum; spawn++)
            {
                var obj = Instantiate(zombieSpawn[listNum].zombiePrefab, zombieBox);
                fieldZombie.Add(obj);
                obj.SetActive(false);
            }
            
        }
#if UNITY_EDITOR
        Debug.Log(zombieBox.childCount);
#endif
        initTime = true;
    }

    /// <summary>
    /// 
    /// </summary>
    private void SpawnZombie()
    {
        if (fieldZombie.FirstOrDefault(x => x.activeSelf == false) == null) return;

        //time += Time.deltaTime;
        for (int pop = 0; pop < zombieSpawn.Count; pop++)
        {
            Observable.EveryUpdate()
                      .Subscribe(_ => ZombieInit(pop))
                      .AddTo(this.gameObject);
            //if (time > zombieSpawn[pop].spawnSpeed)
            //{
            //    //if (!fieldZombie.Contains(zombieSpawn[pop].zombiePrefab)) return;
            //    // zombie genelate
            //    var zombie = fieldZombie.Where
            //                            (x => x.GetComponent<ZombieJobParent>().zombieJob == zombieSpawn[pop].zombieJob)
            //                            .FirstOrDefault(x => x.activeSelf == false);

            //    zombie.SetActive(true);
            //    time = 0;
            //}
        }
    }

    private void ZombieInit(int id)
    {
        time += Time.deltaTime;

        if (time > zombieSpawn[id].spawnSpeed)
        {
            // zombie genelate
            var zombie = fieldZombie.Where
                                    (x => x.GetComponent<ZombieJobParent>().zombieJob == zombieSpawn[id].zombieJob)
                                    .FirstOrDefault(x => x.activeSelf == false);

            zombie.SetActive(true);
            time = 0;
            //zombie.transform.GetChild(0).GetComponent<ZombieScript>().Init();
        }
    }
}

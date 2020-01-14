using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System.Linq;

public class ZombieGenerateGame : MonoBehaviour
{
    private List<GameObject> fieldZombie = new List<GameObject>();

    private float time = 0;
    // zombie setting
    private int zombieNum = 0;
    public int SetZombieNum { set { zombieNum = value; } }
    private float speed = 0;
    public float SetZombieSpeed { set { speed = value; } }
    
    void Start()
    {
        foreach(Transform obj in this.gameObject.transform)
        {
            fieldZombie.Add(obj.gameObject);
        }
        //Observable.EveryUpdate()
        //              .Subscribe(_ => ZombieInit())
        //              .AddTo(this.gameObject);
    }

    void Update()
    {
        ZombieInit();
    }

    /// <summary>
    /// 
    /// </summary>
    private void SpawnZombie()
    {
        if (fieldZombie.FirstOrDefault(x => x.activeSelf == false) == null) return;

        //time += Time.deltaTime;
        for (int pop = 0; pop < zombieNum; pop++)
        {
            Observable.EveryUpdate()
                      .Subscribe(_ => ZombieInit())
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

    private void ZombieInit()
    {
        time += Time.deltaTime;

        if (time > speed)
        {
            // zombie genelate
            var zombie = fieldZombie.FirstOrDefault(x => x.activeSelf == false);
            if (zombie == null) return;

            zombie.SetActive(true);
            //zombie.transform.GetChild(0).GetComponent<ZombieScript>().Init();
            //zombie.GetComponent<ZombieScript>().Init();
            time = 0;
        }
    }
}

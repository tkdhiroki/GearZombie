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
    }

    void Update()
    {
        ZombieInit();
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

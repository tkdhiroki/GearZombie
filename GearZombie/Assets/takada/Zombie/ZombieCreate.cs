using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCreate : MonoBehaviour
{
    [SerializeField] MapSetting mapSetting = null;
    private GameObject zombiePool;

    private void Start()
    {
        zombiePool = this.gameObject.gameObject;
    }
}

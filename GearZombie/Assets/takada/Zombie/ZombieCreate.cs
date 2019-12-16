using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCreate : MonoBehaviour
{
    [SerializeField] MapSetting mapSetting = null;
    private GameObject zombieBox;

    private void Start()
    {
        zombieBox = this.gameObject.gameObject;
    }

    private void FieldZombieInit()
    {
        //for(int i = 0; i < )
    }
}

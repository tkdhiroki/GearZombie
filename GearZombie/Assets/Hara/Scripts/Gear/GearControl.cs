using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearControl : MonoBehaviour
{
    [SerializeField]
    private GearView[] gearObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            foreach(GearView gear in gearObject)
            {
                gear.RotateGearDirection = true;
                gear.GearRotateFlag = true;
            }
        }
        else if(Input.GetMouseButton(1))
        {
            foreach(GearView gear in gearObject)
            {
                gear.RotateGearDirection = false;
                gear.GearRotateFlag = true;
            }
        }
        else
        {
            foreach(GearView gear in gearObject)
            {
                gear.GearRotateFlag = false;
            }
        }
        
    }
}

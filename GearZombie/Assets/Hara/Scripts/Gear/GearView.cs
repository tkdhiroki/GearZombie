using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearView : MonoBehaviour
{
    public bool GearRotateFlag { set; private get; } = false;
    public bool RotateGearDirection { set; private get; } = false;
    

    [SerializeField, Tooltip("歯車が1秒間で回転する角度")]
    private float angle = 180;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateGear(RotateGearDirection);
    }

    /// <summary>
    /// 歯車を回転させる処理
    /// </summary>
    private void RotateGear(bool direction)
    {
        if(!GearRotateFlag) return;

        var direct = 0;
        if(RotateGearDirection)
        {
            direct = -1;
        }
        else
        {
            direct = 1;
        }
        transform.RotateAround(transform.position, Vector3.forward, direct * (angle * Time.deltaTime));
    }
}

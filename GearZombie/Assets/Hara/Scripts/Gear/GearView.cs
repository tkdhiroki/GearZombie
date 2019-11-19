using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearView : MonoBehaviour
{
    public bool GearRotateFlag { set; get; } = false;
    public bool RotateGearDirection { set; private get; } = false;

    private GameObject gearObj1 = null;
    private GameObject gearObj2 = null;
    private GameObject gearObj3 = null;
    private GameObject gearObj4 = null;
    private GameObject gearObj5 = null;

    [SerializeField, Tooltip("歯車が1秒間で回転する角度")]
    private float angle = 180;

    // Start is called before the first frame update
    void Start()
    {
        SetGearObject();
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

        if(gearObj1 != null)
        {
            gearObj1.transform.RotateAround(gearObj1.transform.position, Vector3.forward, direct * (angle * Time.deltaTime));
        }
        if(gearObj2 != null)
        {
            gearObj2.transform.RotateAround(gearObj2.transform.position, Vector3.forward, -direct * (angle * Time.deltaTime));
        }
        if(gearObj3 != null)
        {
            gearObj3.transform.RotateAround(gearObj3.transform.position, Vector3.forward, direct * (angle * Time.deltaTime));
        }
        if(gearObj4 != null)
        {
            gearObj4.transform.RotateAround(gearObj4.transform.position, Vector3.forward, -direct * (angle * Time.deltaTime));
        }
        if(gearObj5 != null)
        {
            gearObj5.transform.RotateAround(gearObj5.transform.position, Vector3.forward, direct * (angle * Time.deltaTime));
        }
    }

    /// <summary>
    /// ギアオブジェクトの割り当て
    /// </summary>
    private void SetGearObject()
    {
        gearObj1 = transform.GetChild(0).gameObject;
        gearObj2 = transform.GetChild(1).gameObject;
        gearObj3 = transform.GetChild(2).gameObject;
        gearObj4 = transform.GetChild(3).gameObject;
        gearObj5 = transform.GetChild(4).gameObject;
    }
}

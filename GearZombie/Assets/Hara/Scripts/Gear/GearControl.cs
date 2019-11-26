using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GearControl : MonoBehaviour
{
    private GearView gearObject = null;

    private EventTrigger trigger = null;
    private bool gearFlag = false;

    private void Awake()
    {
        if(gearObject == null) { gearObject = GetComponent<GearView>(); }
        if(trigger == null) { trigger = GetComponent<EventTrigger>(); }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetEventTrigger();
    }

    // Update is called once per frame
    void Update()
    {
        MouseClick();
    }

    /// <summary>
    /// マウスのクリック検知
    /// </summary>
    private void MouseClick()
    {
        if(!gearFlag) return;

        if(Input.GetMouseButtonDown(0))
        {
            gearObject.RotateGearDirection = true;
            gearObject.GearRotateFlag = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            if(gearObject.GearRotateFlag == true) { gearObject.GearRotateFlag = false; }
        }
        if(Input.GetMouseButtonDown(1))
        {
            gearObject.RotateGearDirection = false;
            gearObject.GearRotateFlag = true;
        }
        if(Input.GetMouseButtonUp(1))
        {
            if(gearObject.GearRotateFlag == true) { gearObject.GearRotateFlag = false; }
        }
    }

    /// <summary>
    /// イベントトリガーにイベントの設定
    /// </summary>
    private void SetEventTrigger()
    {
        if(trigger != null)
        {
            EventTrigger.Entry pointerEnter = new EventTrigger.Entry();
            pointerEnter.eventID = EventTriggerType.PointerEnter;
            pointerEnter.callback.AddListener((x) => { gearFlag = true; });
            trigger.triggers.Add(pointerEnter);

            EventTrigger.Entry pointerExit = new EventTrigger.Entry();
            pointerExit.eventID = EventTriggerType.PointerExit;
            pointerExit.callback.AddListener((x) => { gearFlag = false; if(gearObject.GearRotateFlag == true) { gearObject.GearRotateFlag = false; } });
            trigger.triggers.Add(pointerExit);
        }
    }
}

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
            if(gearObject.Coroutine == null)
            {
                gearObject.StartRotate(true);
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            if(gearObject.Coroutine != null)
            {
                gearObject.StopRotate();
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            if(gearObject.Coroutine == null)
            {
                gearObject.StartRotate(false);
            }
        }
        if(Input.GetMouseButtonUp(1))
        {
            if(gearObject.Coroutine != null)
            {
                gearObject.StopRotate();
            }
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
            pointerExit.callback.AddListener((x) => { gearFlag = false; gearObject.StopRotate(); });
            trigger.triggers.Add(pointerExit);
        }
    }
}

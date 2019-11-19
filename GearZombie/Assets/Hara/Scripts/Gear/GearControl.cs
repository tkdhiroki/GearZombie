using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GearControl : MonoBehaviour
{
    [SerializeField]
    private GearView gearObject = null;

    private EventTrigger trigger = null;
    private bool gearFlag = false;

    public void SetGearFlag(bool b)
    {
        gearFlag = b ? true : false;
    }

    private void Awake()
    {
        if(gearObject != null)
        {
            trigger = gearObject.GetComponent<EventTrigger>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(trigger != null)
        {
            EventTrigger.Entry pointerEnter = new EventTrigger.Entry();
            pointerEnter.eventID = EventTriggerType.PointerEnter;
            pointerEnter.callback.AddListener((x) => { gearFlag = true; });
            trigger.triggers.Add(pointerEnter);

            EventTrigger.Entry pointerExit = new EventTrigger.Entry();
            pointerExit.eventID = EventTriggerType.PointerExit;
            pointerExit.callback.AddListener((x) => { gearFlag = false; if(gearObject.GearRotateFlag) gearObject.GearRotateFlag = false; });
            trigger.triggers.Add(pointerExit);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MouseClick();
    }

    private void MouseClick()
    {
        if(!gearFlag) return;

        if(Input.GetMouseButton(0))
        {
            gearObject.RotateGearDirection = true;
            gearObject.GearRotateFlag = true;
        }
        else if(Input.GetMouseButton(1))
        {
            gearObject.RotateGearDirection = false;
            gearObject.GearRotateFlag = true;
        }
        else
        {
            gearObject.GearRotateFlag = false;
        }
    }
}

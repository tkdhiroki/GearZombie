using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GearControl : SingletonMonoBehaviour<GearControl>
{
    [SerializeField, Header("ギアInstanceオブジェクト")] private GameObject gearInstanceObject = null;

    private GearMasterView master = null;
    private TrapListView trap = null;

    private EventTrigger trigger = null;
    private bool gearFlag = false;

    public bool WindowFlag { set; private get; } = true;

    protected override void Awake()
    {
        base.Awake();
        var gear = Instantiate(gearInstanceObject);
        gear.SetActive(false);
        master = gear.GetComponent<GearMasterView>();
        trigger = master.GetGearView.Event;

        EventTrigger.Entry pointerEnter = new EventTrigger.Entry();
        pointerEnter.eventID = EventTriggerType.PointerEnter;
        pointerEnter.callback.AddListener((x) => { gearFlag = true; });
        trigger.triggers.Add(pointerEnter);

        EventTrigger.Entry pointerExit = new EventTrigger.Entry();
        pointerExit.eventID = EventTriggerType.PointerExit;
        pointerExit.callback.AddListener((x) => { gearFlag = false; master.GetGearView.StopRotate(); });
        trigger.triggers.Add(pointerExit);

        if(FindObjectOfType<EventSystem>() == false)
        {
            gameObject.AddComponent<EventSystem>();
            gameObject.AddComponent<StandaloneInputModule>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        MouseClick();

        if(Input.GetKeyDown(KeyCode.Space) && WindowFlag)
        {
            if(master.gameObject.activeSelf == false)
            {
                master.gameObject.SetActive(true);
            }
            else
            {
                master.gameObject.SetActive(false);
                master.GetGearView.ResetGear();
            }
        }
    }

    /// <summary>
    /// マウスのクリック検知
    /// </summary>
    private void MouseClick()
    {
        if(!gearFlag) return;

        if(Input.GetMouseButtonDown(0))
        {
            if(master.GetGearView.Coroutine == null)
            {
                master.GetGearView.StartRotate(true);
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            if(master.GetGearView.Coroutine != null)
            {
                master.GetGearView.StopRotate();
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            if(master.GetGearView.Coroutine == null)
            {
                master.GetGearView.StartRotate(false);
            }
        }
        if(Input.GetMouseButtonUp(1))
        {
            if(master.GetGearView.Coroutine != null)
            {
                master.GetGearView.StopRotate();
            }
        }
    }

    /// <summary>
    /// ギアの所持数を加算
    /// </summary>
    /// <param name="itemID">対象のギア番号</param>
    public void GearStockPlus(int itemID)
    {
        master.GetGearView.GearStockPlus(itemID);
    }
}

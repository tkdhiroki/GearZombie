using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GearView : MonoBehaviour, IDropHandler
{
    public bool GearRotateFlag { set; get; } = false;
    public bool RotateGearDirection { set; private get; } = false;

    private Image[] gearObjects = null;

    [SerializeField, Tooltip("歯車が1秒間で回転する角度")]
    private float angle = 180;

    private int gearCount = 0;

    private void Awake()
    {
        SetGearObject();
    }

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
        if(GearRotateFlag == false || gearCount <= 0) { return; }

        var direct = 0;
        if(RotateGearDirection == true)
        {
            direct = -1;
        }
        else
        {
            direct = 1;
        }

        for(int i = 0; i < gearObjects.Length; i++)
        {
            int num = i + 1;
            if(num % 2 == 0)
            {
                gearObjects[i].transform.RotateAround(gearObjects[i].transform.position, Vector3.forward, -direct * (angle * Time.deltaTime));
            }
            else
            {
                gearObjects[i].transform.RotateAround(gearObjects[i].transform.position, Vector3.forward, direct * (angle * Time.deltaTime));
            }
        }
    }

    /// <summary>
    /// ギアオブジェクトの割り当て
    /// </summary>
    private void SetGearObject()
    {
        gearObjects = new Image[transform.childCount];
        for(int i = 0; i < gearObjects.Length; i++)
        {
            gearObjects[i] = transform.GetChild(i).GetComponent<Image>();
            gearObjects[i].gameObject.SetActive(false);
        }
        gearObjects[0].gameObject.SetActive(true);
    }

    /// <summary>
    /// ドラッグされたオブジェクトがこのオブジェクトにドロップされた時の処理
    /// </summary>
    /// <param name="eventData"></param>
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        GearItemView item = eventData.pointerDrag.GetComponent<GearItemView>();
        if(item != null)
        {
            if(gearCount < gearObjects.Length - 1)
            {
                item.gameObject.SetActive(false);
                gearCount++;
                gearObjects[gearCount].sprite = item.GearSprite;
                gearObjects[gearCount].color = item.GearColor;
                gearObjects[gearCount].gameObject.SetActive(true);
            }
        }
    }
}

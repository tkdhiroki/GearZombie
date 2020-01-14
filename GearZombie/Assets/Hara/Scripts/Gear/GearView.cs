using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GearView : MonoBehaviour, IDropHandler
{
    [SerializeField, Header("歯車オブジェクト")] private Image[] gearObjects = null;

    [SerializeField, Tooltip("歯車が1秒間で回転する角度")] private float angle = 180;

    private int gearCount = 0;

    public Coroutine Coroutine { private set; get; } = null;

    private Slider createGauge = null;

    private void Awake()
    {
        Init();
    }

    /// <summary>
    /// ギアの回転をSTART
    /// </summary>
    public void StartRotate(bool direction)
    {
        Coroutine = StartCoroutine(DoRotateGear(direction));
    }

    /// <summary>
    /// ギアの回転をSTOP
    /// </summary>
    public void StopRotate()
    {
        StopCoroutine(Coroutine);
        createGauge.value = 0;
        Coroutine = null;
    }

    /// <summary>
    /// 歯車を回転させる処理
    /// </summary>
    private IEnumerator DoRotateGear(bool direction)
    {
        if(gearCount <= 0) { yield break; }

        var direct = 0;
        if(direction == true)
        {
            direct = -1;
        }
        else
        {
            direct = 1;
        }

        while(createGauge.value < createGauge.maxValue)
        {
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

            // ゲージの加算
            createGauge.value += (createGauge.maxValue / 200f) * (((gearCount - 1) * 0.5f) + 1);

            yield return null;
        }
        if(createGauge.value >= createGauge.maxValue)
        {
            BreakGear();
            Coroutine = null;
        }
    }

    /// <summary>
    /// ギアオブジェクトの割り当て
    /// </summary>
    private void Init()
    {
        for(int i = 1; i < gearObjects.Length; i++)
        {
            gearObjects[i].gameObject.SetActive(false);
        }

        createGauge = GetComponent<Slider>();
    }

    /// <summary>
    /// トラップ生成が完了したら実行
    /// </summary>
    private void BreakGear()
    {
        gearCount = 0;
        for(int i = 1; i < gearObjects.Length; i++)
        {
            gearObjects[i].gameObject.SetActive(false);
        }
        createGauge.value = 0;
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
                item.transform.position = item.StartPos;
                if(item.Stock > 0)
                {
                    item.Stock--;
                }
                gearCount++;
                gearObjects[gearCount].sprite = item.GearSprite;
                gearObjects[gearCount].color = item.GearColor;
                gearObjects[gearCount].gameObject.SetActive(true);
            }
        }
    }
}

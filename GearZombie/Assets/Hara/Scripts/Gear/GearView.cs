using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GearView : MonoBehaviour, IDropHandler
{
    [SerializeField, Header("歯車オブジェクト")] private Image[] gearObjects = null;

    [SerializeField, Tooltip("歯車が1秒間で回転する角度")] private float angle = 180;

    [SerializeField] private Button resetButton = null;

    [SerializeField, Header("ギアパーツ")] private GearItemView[] gears = null;

    [SerializeField, Header("トラップ"), Tooltip("生成結果Image")] private Image trapImage = null;
    [SerializeField, Tooltip("トラップImageリスト")] private Sprite[] trapSprites = null;

    private int[] setGearId = null;

    private int gearCount = 0;

    public Coroutine Coroutine { private set; get; } = null;

    private Slider createGauge = null;

    [SerializeField, Header("トラップリスト用のスクリプト")] private TrapListControl trap = null;
    private int trapLevel = 0;

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
        if(Coroutine == null) { return; }
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
            createGauge.value += (createGauge.maxValue / 200f) * (((gearCount - 1) * 0.5f) + 0.75f);

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
            gearObjects[i].enabled = false;
        }

        createGauge = GetComponent<Slider>();
        resetButton.onClick.AddListener(() => ResetGear());
        trapImage.enabled = false;

        setGearId = new int[4];
        for(int i = 0; i < setGearId.Length; i++)
        {
            setGearId[i] = -1;
        }
    }

    /// <summary>
    /// トラップ生成が完了したら実行
    /// </summary>
    private void BreakGear()
    {
        trap.OutputTrap(trapImage.sprite, setGearId[0], trapLevel);
        trapLevel = 0;

        for(int i = 1; i < gearObjects.Length; i++)
        {
            gearObjects[i].enabled = false;
        }

        for(int i = 0; i < setGearId.Length; i++)
        {
            if(setGearId[i] < 0) { break; }
            setGearId[i] = -1;
        }

        gearCount = 0;
        createGauge.value = 0;
        gearObjects[0].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        trapImage.enabled = false;
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
            if(gearCount == 0)
            {
                setGearId[gearCount] = item.Id;
                gearObjects[gearCount].color = item.GearColor;
                trapImage.sprite = trapSprites[setGearId[gearCount]];
                trapImage.enabled = true;
            }
            else
            {
                if(item.Id == setGearId[0])
                {
                    setGearId[gearCount] = item.Id;
                }
                else
                {
                    return;
                }
            }

            if(gearCount < gearObjects.Length - 1)
            {
                item.transform.position = item.StartPos;
                if(item.Stock > 0)
                {
                    item.Stock--;
                }
                gearObjects[gearCount + 1].color = item.GearColor;
                gearObjects[gearCount + 1].enabled = true;
                gearCount++;
                trapLevel++;
            }
        }
    }

    /// <summary>
    /// セットしたギアをリセットする
    /// </summary>
    private void ResetGear()
    {
        if(gearCount <= 0) { return; }
        for(int i = 0; i < setGearId.Length; i++)
        {
            if(setGearId[i] < 0) { break; }

            // ギアのカウントを戻す
            gears[setGearId[i]].Stock++;

            // ギアを非表示にする
            gearObjects[i + 1].enabled = false;

            // セットギアIDの初期化
            setGearId[i] = -1;
        }

        // ギアを初期化
        gearCount = 0;
        gearObjects[0].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        trapImage.enabled = false;
        trapLevel = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GearItemView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private CanvasGroup canvasGroup = null;

    public Vector3 StartPos { private set; get; }

    public Sprite GearSprite { private set; get; } = null;
    public Color GearColor { private set; get; }

    private Image image = null;

    [SerializeField, Tooltip("在庫")] private int stock = 5;
    public int Stock { set { stock = value; } get { return stock; } }

    private void Awake()
    {
        if(canvasGroup == null) { canvasGroup = GetComponent<CanvasGroup>(); }
        if(image == null) { image = GetComponent<Image>(); }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StockCheck();
    }

    /// <summary>
    /// ドラッグを開始したとき実行する処理
    /// </summary>
    /// <param name="eventData"></param>
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        StartPos = transform.position;
        GearSprite = image.sprite;
        GearColor = image.color;
    }

    /// <summary>
    /// ドラッグ中に実行する処理
    /// </summary>
    /// <param name="eventData"></param>
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    /// <summary>
    /// ドラッグを終了したときに実行する処理
    /// </summary>
    /// <param name="eventData"></param>
    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        transform.position = StartPos;
        canvasGroup.blocksRaycasts = true;
    }

    /// <summary>
    /// 在庫が0になったら非表示、それ以外なら表示
    /// </summary>
    private void StockCheck()
    {
        if(stock > 0)
        {
            image.enabled = true;
        }
        else
        {
            image.enabled = false;
        }
    }
}

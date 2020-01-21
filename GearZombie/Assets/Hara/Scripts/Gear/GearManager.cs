using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GearManager : MonoBehaviour, IDropHandler
{
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            item.gameObject.SetActive(false);
        }
    }
}

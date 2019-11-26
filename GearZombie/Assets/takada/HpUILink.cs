using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpUILink : MonoBehaviour
{
    private Transform linkObject;
    private RectTransform uiRectTransform;
    [SerializeField] private Vector3 offset = Vector3.zero;

    private void Start()
    {
        linkObject = this.transform.root;
        uiRectTransform = this.GetComponent<RectTransform>();
        Debug.Log(linkObject);
    }

    void Update()
    {
        uiRectTransform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, linkObject.position + offset);
    }
}

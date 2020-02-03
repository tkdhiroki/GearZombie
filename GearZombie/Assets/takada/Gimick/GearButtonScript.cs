using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
/* Gimmick生成 画面 出現 */
public class GearButtonScript : MonoBehaviour
{
    private bool uiOpen = false;
    private RectTransform rectTransform;
    [SerializeField, Header("Create Gear UI")] private GameObject createGear = null;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnClick()
    {
        // true
        if (uiOpen)
        {
            this.rectTransform.DORotate(new Vector3(0, 0, 90), 1.0f);
            CreateGearUI(uiOpen);
            uiOpen = !uiOpen;   // true -> false
        }
        else    // false
        {
            this.rectTransform.DORotate(new Vector3(0, 0, 90), 1.0f);
            CreateGearUI(uiOpen);
            uiOpen = !uiOpen;   // false -> true
        }
    }

    private void CreateGearUI(bool flag)
    {
        if (flag)
        {
            createGear.transform.DOMoveX(1.0f, 0.5f);
        }
        else
        {
            createGear.transform.DOMoveX(0f, 0.5f);
        }

    }
}

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
            this.rectTransform.DORotate(new Vector3(0, 0, 0), 0.5f)
                              .OnComplete(() => CreateGearUI(uiOpen));
            Time.timeScale = 1.0f;
            uiOpen = !uiOpen;   // true -> false
        }
        else    // false
        {

            this.rectTransform.DORotate(new Vector3(0, 0, -120), 0.1f)
                              .OnComplete( () => CreateGearUI(uiOpen));

            Time.timeScale = 0.2f;

            uiOpen = !uiOpen;   // false -> true
        }
    }

    private void CreateGearUI(bool flag)
    {
        createGear.SetActive(flag);
    }
}

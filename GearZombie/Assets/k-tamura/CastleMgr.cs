using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;



public class CastleMgr : SingletonMonoBehaviour<CastleMgr>
{
    [SerializeField]
    private Image GaugeUi;
    [SerializeField]
    private float HpGauge;
    [SerializeField]
    private Text GameoverText;
    [SerializeField]
    private Text GameclearText;
    private float fadeSpeed = 2.5f;

    private float nowHp;
    private void Start()
    {
        nowHp = HpGauge;

        Color color = GameoverText.color;
        color.a = 0;
        Color color2 = GameclearText.color;
        color2.a = 0;

        GameoverText.color = color;
        GameclearText.color = color2;
    }

    public static void HpDecrease(float HpDec)
    {
        instance.nowHp -= HpDec;
        instance.GaugeUi.fillAmount = instance.nowHp / instance.HpGauge;

        if(instance.nowHp <= 0)
        {
            GameOver();
        }
    }

    private static void GameOver()
    {
        instance.GameoverText.DOFade(1.0f, instance.fadeSpeed)
                             .OnComplete( () => SceneLoadManager.LoadScene("Title") );        
    }
    public static void GameClear()
    {
        instance.GameclearText.DOFade(1.0f, instance.fadeSpeed)
                             .OnComplete(() => SceneLoadManager.LoadScene("Title"));
    }
}

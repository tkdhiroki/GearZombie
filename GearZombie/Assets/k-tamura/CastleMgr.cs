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
    private float nowHp;
    private void Start()
    {
        nowHp = HpGauge;
    }
    public static void HpDecrease(float HpDec)
    {
        instance.nowHp -= HpDec;
        instance.GaugeUi.fillAmount = instance.nowHp / instance.HpGauge;
    }
}

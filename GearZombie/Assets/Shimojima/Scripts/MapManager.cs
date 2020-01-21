using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    public bool IsChoice { get; set; }   //mapが選択されているか

    public GameObject targetObj;    //現在選択されているターゲットマップ
    private static bool firstTime, isMax = false;   //既に選択されているか,アルファ値が最大か
    private static float alpha = 0f;
    private static Color c, originColor;    //変更掛ける色,targetObjの元の色


    private void Update()
    {
        ColorFade();
    }

    /// <summary>
    /// カラーを黄色にしてオブジェクトを強調します。
    /// </summary>
    public void ColorFade()
    {
        if (MapManager.Instance.IsChoice)
        {
            if (!firstTime)
            {
                c = Color.yellow;
                firstTime = true;
            }

            //以下アルファ値の増加と減少
            if (alpha > 0 && isMax)
            {
                targetObj.GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, alpha);
                alpha -= 0.03f;
            }
            else if (alpha <= 0)
            {
                isMax = false;
            }

            if (alpha < 1 && !isMax)
            {
                MapManager.Instance.targetObj.GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, alpha);
                alpha += 0.03f;
            }
            else if (alpha >= 1)
            {
                isMax = true;
            }
        }
    }

    /// <summary>
    /// マップオブジェクトの選択
    /// </summary>
    /// <param name="obj"></param>
    public void ChoiceTarget(GameObject obj)
    {
        if (IsChoice)
        {
            if (TrapManager.Instance.hasTrap) { return; }

            IsChoice = false;
            targetObj.GetComponent<SpriteRenderer>().color = originColor;
            firstTime = false;

            if (targetObj != obj && obj.name != "nomap")
            {
                //既に選択されているものと違う場合はターゲットを変更する
                targetObj = obj;
                originColor = targetObj.GetComponent<SpriteRenderer>().color;
                IsChoice = true;
            }
            else
            {
                //既に選択されているものと同じ場合はターゲットをnullにする
                targetObj = null;
            }
        }
        else
        {
            //ターゲットがnullの場合は選択されたmapをターゲットにする
            if (targetObj == null)
            {
                targetObj = obj;
                originColor = targetObj.GetComponent<SpriteRenderer>().color;
            }
            IsChoice = true;
        }
        
    }
}

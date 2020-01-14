using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    private static bool isChoice = false;
    private static bool firstTime, isMax = false;
    private static float alpha = 0f;
    private static GameObject targetObj;
    private static Color c, originColor;


    private void Update()
    {
        ColorFade();
    }

    /// <summary>
    /// カラーを黄色にしてオブジェクトを強調します。
    /// </summary>
    public static void ColorFade()
    {
        if (isChoice)
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
                targetObj.GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, alpha);
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
    public static void IsChoice(GameObject obj)
    {
        if (isChoice)
        {
            isChoice = false;
            targetObj.GetComponent<SpriteRenderer>().color = originColor;
            firstTime = false;

            if (targetObj != obj)
            {
                targetObj = obj;
                originColor = targetObj.GetComponent<SpriteRenderer>().color;
                isChoice = true;
            }
            else if (targetObj == obj)
            {

                targetObj = null;
            }
        }
        else
        {
            if (targetObj == null)
            {
                targetObj = obj;
                originColor = targetObj.GetComponent<SpriteRenderer>().color;
            }
            isChoice = true;
        }
        
    }
}

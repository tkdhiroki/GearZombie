using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private bool isTarget = false;
    private bool isMax = true;
    private bool firstTime = false;
    private float alpha = 1;
    private Color c;

    void Start()
    {
        c = gameObject.GetComponent<SpriteRenderer>().color;
    }
    
    void Update()
    {
        ColorFade();
    }

    private void ColorFade()
    {
        if (isTarget)
        {
            if (!firstTime)
            {
                c = Color.yellow;
                firstTime = true;
            }

            if (alpha > 0 && isMax)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, alpha);
                alpha -= 0.03f;
            }
            else if (alpha <= 0)
            {
                isMax = false;
            }

            if (alpha < 1 && !isMax)
            {
                gameObject.GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, alpha);
                alpha += 0.03f;
            }
            else if (alpha >= 1)
            {
                isMax = true;
            }

        }
    }

    private void OnMouseDown()
    {
        if (!isTarget)
        {
            isTarget = true;
        }
        else
        {
            isTarget = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private bool isTarget = false;
    private bool isMax = true;
    private bool firstTime = false;
    private float alpha = 0;

    void Start()
    {
        
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
                gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                firstTime = true;
            }

            if (gameObject.GetComponent<SpriteRenderer>().color.a > alpha && isMax)
            {
                Color c = gameObject.GetComponent<SpriteRenderer>().color;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(c.r, c.b, c.g, c.a - 0.0001f);
            }
            else if (gameObject.GetComponent<SpriteRenderer>().color.a <= alpha)
            {
                isMax = false;
            }

            if (!isMax)
            {
                Color c = gameObject.GetComponent<SpriteRenderer>().color;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(c.r, c.b, c.g, c.a + 0.0001f);
            }
            else if (gameObject.GetComponent<SpriteRenderer>().color.a >= 1)
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

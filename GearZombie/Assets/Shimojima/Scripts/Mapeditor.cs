using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mapeditor : MonoBehaviour
{
    public Sprite[] mapObj;
    public Image preview;
    public float moveValue;
    private int defaultSize = 7;
    public int objSize;
    private int number;
    
    public Vector2 stageSize;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ImagePreview(number);
        MapObjChange();

        MovePos();

        if (Input.GetKeyDown(KeyCode.Return))
        {
            MapObjSet(number);
        }
    }

    private void MovePos()
    {

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 pos = transform.position;
            transform.position = new Vector3(pos.x - moveValue, pos.y, pos.z);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 pos = transform.position;
            transform.position = new Vector3(pos.x + moveValue, pos.y, pos.z);
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 pos = transform.position;
            transform.position = new Vector3(pos.x, pos.y + moveValue, pos.z);
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 pos = transform.position;
            transform.position = new Vector3(pos.x, pos.y - moveValue, pos.z);
        }
    }

    private void MapObjSet(int x)
    {
        Collider2D[] col2d = new Collider2D[5];
        bool b = false;
        gameObject.GetComponent<Collider2D>().OverlapCollider(new ContactFilter2D(), col2d);
        foreach (var c in col2d)
        {
            if(c != null && c.name == "map")
            {
                b = true;
            }
        }
        
        if (b)
        {
            Debug.Log("ここには置けません");
            return;
        }

        Vector3 pos = transform.position;
        GameObject obj = new GameObject();
        obj.name = "map";
        obj.AddComponent<SpriteRenderer>().sprite = mapObj[x];
        obj.transform.localScale = new Vector3(defaultSize * objSize, defaultSize * objSize, 1);
        if (objSize != 1)
        {
            obj.transform.localPosition = new Vector3(pos.x + 0.5f * (objSize - 1), pos.y + 0.5f * (objSize - 1), pos.z);
        }
        else
        {
            obj.transform.localPosition = new Vector3(pos.x, pos.y, pos.z);
        }
        Vector2 v = obj.AddComponent<BoxCollider2D>().size;
        obj.GetComponent<BoxCollider2D>().size = new Vector2(v.x - 0.03f, v.y - 0.03f);

    }

    private void MapObjChange()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (mapObj.Length - 1 == number)
            {
                number = 0;
            }
            else
            {
                number++;
            }
        }
    }

    private void ImagePreview(int x)
    {
        preview.sprite = mapObj[x];
    }
}

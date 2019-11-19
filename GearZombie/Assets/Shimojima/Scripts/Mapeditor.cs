using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.IO;

public class Mapeditor : MonoBehaviour
{
    public InputField name;
    public Button save;
    public Text text;
    public Dropdown inputSize;
    public Sprite[] mapObj;
    public Image preview;
    private GameObject root;
    public float moveValue;
    private int defaultSize = 7;
    private int number;
    public bool isEdit = true;
    
    public Vector2 stageSize;

    void Start()
    {
        name.interactable = false;
        save.interactable = false;
        root = new GameObject();
        root.name = "Root";
    }

    // Update is called once per frame
    void Update()
    {
        ImagePreview(number);

        if (!isEdit) return;

        MapObjChange();

        MovePos();

        if (Input.GetKeyDown(KeyCode.Return))
        {
            MapObjSet(number);
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            MapObjDestroy();
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

        int size = inputSize.value + 1;
        Vector3 pos = transform.position;
        GameObject obj = new GameObject();
        obj.name = "map";
        obj.AddComponent<SpriteRenderer>().sprite = mapObj[x];
        obj.transform.localScale = new Vector3(defaultSize * size, defaultSize * size, 1);
        if (size != 1)
        {
            obj.transform.localPosition = new Vector3(pos.x + 0.5f * (size - 1), pos.y + 0.5f * (size - 1), pos.z);
        }
        else
        {
            obj.transform.localPosition = new Vector3(pos.x, pos.y, pos.z);
        }
        Vector2 v = obj.AddComponent<BoxCollider2D>().size;
        obj.GetComponent<BoxCollider2D>().size = new Vector2(v.x - 0.03f, v.y - 0.03f);
        obj.transform.parent = root.transform;

    }

    private void MapObjDestroy()
    {
        Collider2D[] col2d = new Collider2D[5];
        gameObject.GetComponent<Collider2D>().OverlapCollider(new ContactFilter2D(), col2d);
        foreach (var c in col2d)
        {
            if (c != null && c.name == "map")
            {
                Debug.Log(c.name + "オブジェクトを削除しました");
                Destroy(c.gameObject);
                break;
            }
        }
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

    public void EditModeChange()
    {
        if (isEdit)
        {
            text.text = "SaveMode";
            name.interactable = true;
            save.interactable = true;
            isEdit = false;
        }
        else
        {
            text.text = "EditMode";
            name.interactable = false;
            save.interactable = false;
            isEdit = true;
        }
    }

    private void ImagePreview(int x)
    {
        preview.sprite = mapObj[x];
    }

    public void SetName()
    {
        root.name = name.text;
    }
    public void CreatePrefab()
    {
        string path = "Assets/Shimojima/Prefabs/" + root.name + ".prefab";
        PrefabUtility.SaveAsPrefabAsset(root, path);

        
    }
}

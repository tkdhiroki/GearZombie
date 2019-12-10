using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.UI;
using System.IO;

public class Mapeditor : MonoBehaviour
{
    [Header("-参照オブジェクト-")]
    [Tooltip("保存するプレハブ名")]
    public InputField stageName;
    [Tooltip("saveボタンオブジェクト")]
    public Button save;
    public Text text;
    [Tooltip("サイズメニューオブジェクト")]
    public Dropdown inputSize;
    [Tooltip("mapに使用するスプライト")]
    public Sprite[] mapObj;
    [Tooltip("スプライトカラー")]
    public Color spriteColor = Color.white;
    [Tooltip("保存されたスプライトカラー")]
    public List<Color> savedColor = new List<Color>();
    private Color changeColor = Color.white;
    [Tooltip("プレビューオブジェクト")]
    public Image preview;
    private GameObject root;
    public float moveValue;
    private readonly float defaultSize = 4f;
    private int number;
    [Tooltip("モード切替チェック")]
    public bool isEdit = true;
    
    //public Vector2 stageSize;

    void Start()
    {
#if UNITY_EDITOR
        root = new GameObject();
        stageName.interactable = false;
        save.interactable = false;
        root.name = "Root";
#endif
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
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

        if (Input.GetKeyDown(KeyCode.C))
        {
            SpriteColorSave();
        }
#endif
    }

    /// <summary>
    /// マップエディットオブジェクトの操作
    /// </summary>
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

    /// <summary>
    /// マップオブジェクトの設置
    /// <para>引数xはマップオブジェクトの番号</para>
    /// </summary>
    /// <param name="x">マップオブジェクトナンバー</param>
    private void MapObjSet(int x)
    {
        //既にマップオブジェクトが置かれているかの確認
        Collider2D[] col2d = new Collider2D[5];
        gameObject.GetComponent<Collider2D>().OverlapCollider(new ContactFilter2D(), col2d);
        foreach (var c in col2d)
        {
            if(c != null && c.name == "map")
            {
                c.GetComponent<SpriteRenderer>().color= changeColor;
                return;
            }
        }

        //マップオブジェクトの設置
        int size = inputSize.value + 1;
        Vector3 pos = transform.position;
        GameObject obj = new GameObject();
        obj.name = "map";
        obj.AddComponent<SpriteRenderer>().sprite = mapObj[0];
        obj.transform.localScale = new Vector3(defaultSize * size, defaultSize * size, 1);
        obj.GetComponent<SpriteRenderer>().color = changeColor;
        if (size != 1)
        {
            obj.transform.localPosition = new Vector3(pos.x + 0.56f * (size - 1), pos.y + 0.56f * (size - 1), pos.z);
        }
        else
        {
            obj.transform.localPosition = new Vector3(pos.x, pos.y, pos.z);
        }
        Vector2 v = obj.AddComponent<BoxCollider2D>().size;
        obj.GetComponent<BoxCollider2D>().size = new Vector2(v.x - 0.03f, v.y - 0.03f);
        obj.transform.parent = root.transform;

    }

    /// <summary>
    /// マップオブジェクトの削除
    /// </summary>
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

    /// <summary>
    /// 設置するオブジェクトの変更
    /// </summary>
    private void MapObjChange()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (savedColor.Count - 1 == number)
            {
                number = 0;
                changeColor = savedColor[number];
                preview.color = changeColor;
            }
            else
            {
                number++;
                changeColor = savedColor[number];
                preview.color = changeColor;
            }
        }
    }


    /// <summary>
    /// エディットモードの切り替え
    /// </summary>
    public void EditModeChange()
    {
#if UNITY_EDITOR
        if (isEdit)
        {
            text.text = "SaveMode";
            stageName.interactable = true;
            save.interactable = true;
            isEdit = false;
        }
        else
        {
            text.text = "EditMode";
            stageName.interactable = false;
            save.interactable = false;
            isEdit = true;
        }
#endif
    }

    /// <summary>
    /// イメージプレビュー
    /// <para>引数xはマップオブジェクトの番号</para>
    /// </summary>
    /// <param name="x">マップオブジェクトナンバー</param>
    private void ImagePreview(int x)
    {
        preview.sprite = mapObj[0];
    }


    /// <summary>
    /// スプライトのカラーの保存
    /// </summary>
    private void SpriteColorSave()
    {
#if UNITY_EDITOR
        savedColor.Add(spriteColor);
#endif
    }

    /// <summary>
    /// プレハブの名前を変更
    /// </summary>
    public void SetName()
    {
#if UNITY_EDITOR
        root.name = stageName.text;
#endif
    }

    /// <summary>
    /// プレハブを作成
    /// </summary>
    public void CreatePrefab()
    {
#if UNITY_EDITOR
        string path = "Assets/Shimojima/Prefabs/" + root.name + ".prefab";
        PrefabUtility.SaveAsPrefabAsset(root, path);
#endif
    }
}

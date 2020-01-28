using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : Singleton<TrapManager>
{
    [System.Serializable]
    public struct TrapList
    {
        public string name;
        public TrapData trap;
    }

    [Header("-参照データ-")]
    public TrapList[] tList;
    [Header("-所持トラップ-")]
    public int[] hasTrapes = new int[4];
    [Tooltip("現在設置するトラップを選択しているか")]
    public bool hasTrap = false;
    public float WorldTime;

    void Start()
    {
    }
    
    void Update()
    {
    }

    private void FixedUpdate()
    {
        WorldTime += Time.deltaTime;
    }

    /// <summary>
    /// トラップのストックを生成
    /// </summary>
    /// <param id="id"></param>
    public void TrapStack(int id)
    {
        hasTrapes[id]++;
    }

    /// <summary>
    /// トラップをマップに設置
    /// </summary>
    /// <param id="id"></param>
    public void TrapCreate(int id)
    {
        if (!hasTrap) { return; }

        if (!MapManager.Instance.IsChoice) { Debug.Log("Mapが選択されていません！！"); return; }

        GameObject obj = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
        if (hit.collider)
        {
            //mapのポジションを取得
            obj = hit.collider.gameObject;
            Debug.Log(obj == MapManager.Instance.targetObj);
            if (hasTrapes[id] != 0 && obj == MapManager.Instance.targetObj)
            {
                GameObject o = Instantiate(tList[id].trap.obj, obj.transform.position, Quaternion.identity);
                hasTrapes[id]--;
                hasTrap = false;
                MapManager.Instance.ChoiceTarget(obj);
            }
            else
            {
                hasTrap = false;
                MapManager.Instance.ChoiceTarget(obj);
                if (hasTrapes[id] == 0)
                {
                    Debug.Log("指定したトラップを所持していません！");
                    return;
                }
                Debug.Log("Map外が選択されました");
            }
        }
    }
}

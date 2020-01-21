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
    /// <param id="pos"></param>
    public void TrapCreate(int id, Vector2 pos)
    {
        if (hasTrapes[id] != 0)
        {
            GameObject obj = Instantiate(tList[id].trap.obj, pos, Quaternion.identity);
            hasTrapes[id]--;
        }
        else
        {
            Debug.Log("このトラップを持っていません！！");
        }
    }
}

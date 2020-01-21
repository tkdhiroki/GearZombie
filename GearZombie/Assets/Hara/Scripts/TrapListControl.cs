using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapListControl : SingletonMonoBehaviour<TrapListControl>
{

    [SerializeField, Header("トラップリスト")] private Image[] trapList = null;

    private int trapIndex = 0;    // 生成数カウンター

    /// <summary>
    /// 生成したトラップをリスト内に表示
    /// </summary>
    /// <param name="trapSprite"></param>
    public void OutputTrap(Sprite trapSprite, int trapID, int trapLevel)
    {
        if(trapIndex >= trapList.Length) { return; }
        trapList[trapIndex].sprite = trapSprite;
        trapList[trapIndex].enabled = true;
        string trapName;
        int baseTrapHp;
        switch(trapID)
        {
            case 0:
                trapName = "トラバサミ";
                baseTrapHp = 25;
                break;
            case 1:
                trapName = "弓矢";
                baseTrapHp = 20;
                break;
            case 2:
                trapName = "炎";
                baseTrapHp = 10;
                break;
            case 3:
                trapName = "爆弾";
                baseTrapHp = 0;
                break;
            default:
                Debug.Log(trapID);
                return;
        }
        TrapManager.Instance.tList[trapIndex].name = trapName;
        TrapManager.Instance.tList[trapIndex].trap.id = trapID;
        TrapManager.Instance.tList[trapIndex].trap.hp = baseTrapHp * trapLevel;
        trapIndex++;
    }

    /// <summary>
    /// トラップを使用したら実行
    /// </summary>
    public void TrapUse(int trapID)
    {
        if(trapID == trapList.Length || trapID < 0 || trapIndex - 1 < 0) { return; }

        if(trapID == trapIndex - 1)
        {
            trapList[trapID].enabled = false;
        }
        else
        {
            for(int i = trapID; i < trapIndex; i++)
            {
                if(i != trapIndex - 1)
                {
                    trapList[i].sprite = trapList[i + 1].sprite;
                }
                else
                {
                    trapList[i].enabled = false;
                }
            }
        }

        trapIndex--;
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Init()
    {
        foreach(Image trap in trapList)
        {
            trap.enabled = false;
        }
        TrapManager.Instance.tList = new TrapManager.TrapList[trapList.Length];
        for(int i = 0; i < TrapManager.Instance.tList.Length; i++)
        {
            TrapManager.Instance.tList[i].trap = ScriptableObject.CreateInstance<TrapData>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

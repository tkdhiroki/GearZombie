using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapListControl : MonoBehaviour
{
    [SerializeField] private Sprite fireSprite = null;
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
        //var script = trapList[trapIndex].GetComponent<GimmickButton>();
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
                //script.ChangeGimmickType(GimmickType.Fire);
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
        for(int i = 0; i< 3; i++)
        {
            trapList[trapIndex].sprite = fireSprite;
            trapList[trapIndex].enabled = true;
            trapIndex++;
        }
    }

    public void UseTrap()
    {
        trapIndex--;
        trapList[trapIndex].sprite = null;
        trapList[trapIndex].enabled = false;
    }
}

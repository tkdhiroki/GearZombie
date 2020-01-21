using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapListControl : MonoBehaviour
{

    [SerializeField, Header("トラップリスト")] private Image[] trapList = null;

    private int trapIndex = 0;    // 生成数カウンター

    /// <summary>
    /// 生成したトラップをリスト内に表示
    /// </summary>
    /// <param name="trapSprite"></param>
    public void OutputTrap(Sprite trapSprite)
    {
        if(trapIndex >= trapList.Length) { return; }
        trapList[trapIndex].sprite = trapSprite;
        trapList[trapIndex].enabled = true;
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

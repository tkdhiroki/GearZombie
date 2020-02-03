using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GimmickType
{
    None,
    Fire,
    Bomb,
    Trap,
    Arrow,
    Max
}
public class GimmickButton : MonoBehaviour
{
    //private GimmickType gimmickType;
    [SerializeField] private GameObject fire = null;
    private FireGimmick script = null;
    //public void ChangeGimmickType(GimmickType type)
    //{
    //    gimmickType = type;
    //}

    // Start is called before the first frame update
    void Start()
    {
        //parent = this.transform.parent.gameObject;
        //gimmickType = GimmickType.None;
        script = fire.GetComponent<FireGimmick>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetGimmickClass()
    {
        if (script.IsClick) return;

        script.IsClick = true;
        script.ColliderSwitch(true);
    }
}

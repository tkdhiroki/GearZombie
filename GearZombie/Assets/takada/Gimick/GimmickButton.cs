using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GimmickType
{
    Fire,
    Bomb,
    Trap,
    Arrow,
    Max
}
public class GimmickButton : MonoBehaviour
{
    private GameObject parent;
    [SerializeField] private GimmickType gimmickType;
    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void GetGimmickClass()
    {
        switch(gimmickType)
        {
            case GimmickType.Fire:
                var script = parent.GetComponent<FireGimmick>();
                script.IsClick = true;
                script.ColliderSwitch(true);
                break;
            case GimmickType.Bomb:
                
                break;
            case GimmickType.Trap:
                
                break;
            case GimmickType.Arrow:
                
                break;
        }
    }
}

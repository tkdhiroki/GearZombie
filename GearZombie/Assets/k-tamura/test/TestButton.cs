using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
   public void ButtonPush()
    {
        CastleMgr.HpDecrease(1.4f);
    }
}

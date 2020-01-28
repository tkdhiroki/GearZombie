using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearMasterView : MonoBehaviour
{
    [SerializeField, Header("GearViewスクリプト")] private GearView gearView;
    public GearView GetGearView { get { return gearView; } }
}

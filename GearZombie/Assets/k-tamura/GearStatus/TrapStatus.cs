using UnityEngine;
using System.Security;
[CreateAssetMenu(menuName = "Trap/TrapStatus", fileName = "TrapStat")]
public class TrapStatus : ScriptableObject
{
    public TrapStat trapstatus;
    
}
[System.Serializable]
public struct TrapStat
{
    [SerializeField, Header("TrapName")] public string _trapName;
    public string TrapName { get { return _trapName; } }

    [SerializeField, Header("Trap生成Num")] public int _trapNum;
    public int TrapNumber { get { return _trapNum; } }

    [SerializeField, Header("耐久値")] public int _endurance;
    public int Endurance { get { return _endurance; } }
}

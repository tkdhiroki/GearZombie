using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="TrapData", fileName ="TrapData")]
public class TrapData : ScriptableObject
{
    public int id;
    public float hp;
    public GameObject obj;
}

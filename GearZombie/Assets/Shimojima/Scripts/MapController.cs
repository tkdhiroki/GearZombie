using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private void OnMouseDown()
    {
        MapManager.Instance.ChoiceTarget(gameObject);
    }
}

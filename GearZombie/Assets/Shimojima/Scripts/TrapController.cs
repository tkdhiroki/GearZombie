using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TrapManager.Instance.hasTrap = true;
        }
        CreateTrap();
    }

    private void CreateTrap()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            TrapManager.Instance.TrapCreate(0);
        }
    }
}

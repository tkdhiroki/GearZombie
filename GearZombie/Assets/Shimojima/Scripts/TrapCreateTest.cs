﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCreateTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //CreateTrap();
    }

    private void CreateTrap()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            TrapManager.Instance.TrapCreate(0, screenPos);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class MainScript : SingletonMonoBehaviour<MainScript>
{
    public bool isOpen = true;

    // Gimmick の　UI
    [SerializeField] private RectTransform gimmickUIRect = null;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IsOPenFlagChange(bool flag)
    {
        if(flag)
        {
            isOpen = true;
            Time.timeScale = 1.0f;
        }
        else
        {
            isOpen = false;
            Time.timeScale = 0.2f;
        }
    }
}

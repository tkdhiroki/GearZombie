using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testkey : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    string sceneName;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
            SceneLoadManager.LoadScene(sceneName);
    }
}

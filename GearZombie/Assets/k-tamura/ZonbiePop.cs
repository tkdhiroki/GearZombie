using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonbiePop : Singleton<ZonbiePop>
{
	float _time;
    float timeSpan;
    GameObject zonbie;
    GameObject PopPoint;

    static bool Shot { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        Pop(); 
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if (Shot&&timeSpan<=_time)
        {
            Pop();
            Shot = false;
        }

    }
    static void Pop()
    {
        Instantiate(Instance.zonbie,Instance.PopPoint.transform.position,Quaternion.identity);
    }
}

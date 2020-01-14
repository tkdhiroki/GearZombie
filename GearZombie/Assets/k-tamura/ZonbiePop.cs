using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonbiePop : MonoBehaviour
{
	float _time;
    GameObject zonbie;
    GameObject PopPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

    }
    void Pop()
    {
        Instantiate(zonbie,PopPoint.transform.position,Quaternion.identity);
    }
}

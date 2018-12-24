using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPosition : MonoBehaviour
{

    Vector3 iniPos;
    // Use this for initialization
    void Start()
    {
        iniPos = transform.position;
    }
	
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = iniPos;
    }
}

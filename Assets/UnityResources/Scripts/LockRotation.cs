using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour
{

    Quaternion initialRot;
    // Use this for initialization
    void Start()
    {
        initialRot = transform.rotation;
    }
	
    // Update is called once per frame
    void Update()
    {
        transform.rotation = initialRot;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
	
    // Update is called once per frame
    void Update()
    {
        //100 is Canvas Plane Distance
        transform.position = Extensions.GetMouseWorldPos();
    }
}

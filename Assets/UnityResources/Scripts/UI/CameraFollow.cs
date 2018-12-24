using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject follow;
    void Start()
    {
        //follow = gameObject.GetComponent<PlayerInjector>().player;
    }
    void Update()
    {
        Camera.main.transform.position = new Vector3(follow.transform.position.x, follow.transform.position.y, Camera.main.transform.position.z);
    }
}

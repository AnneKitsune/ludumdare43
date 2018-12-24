using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RawImageUVScroller : MonoBehaviour
{
    public Vector2 speed;
    private RawImage ri;
    // Use this for initialization
    void Start()
    {
        ri = GetComponent<RawImage>();
    }
	
    // Update is called once per frame
    void Update()
    {
        var uv = ri.uvRect;

        uv.x += speed.x * Time.deltaTime;

        ri.uvRect = uv;
    }
}

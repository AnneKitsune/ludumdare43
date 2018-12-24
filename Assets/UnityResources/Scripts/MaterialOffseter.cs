using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialOffseter : MonoBehaviour
{
    public Vector2 offsetSpeed;
    public bool useShared;
    private Material m;

    // Use this for initialization
    void Start()
    {
        if (useShared)
            m = GetComponent<Renderer>().sharedMaterial;
        else
            m = GetComponent<Renderer>().material;
    }
	
    // Update is called once per frame
    void Update()
    {
        m.mainTextureOffset += offsetSpeed * Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalerAnimation : MonoBehaviour
{

    public Vector3 targetScale;
    public float speed;

    public bool useUnscaledTime;

    private Vector3 initialScale;


    // Use this for initialization
    void Start()
    {
        initialScale = transform.localScale;
        targetScale -= Vector3.one;
    }
	
    // Update is called once per frame
    void Update()
    {
        //transform.localScale = Vector3.Lerp(initialScale, Vector3.Scale(initialScale, targetScale), Mathf.PingPong(Time.time, 1f) * speed);
        //We must do 1 - targetScale

        if (!useUnscaledTime)
            transform.localScale = Vector3.Scale(initialScale, (targetScale * Mathf.Abs(Mathf.Sin(Time.time * speed)))) + initialScale;
        else
            transform.localScale = Vector3.Scale(initialScale, (targetScale * Mathf.Abs(Mathf.Sin(Time.unscaledTime * speed)))) + initialScale;
    }
}

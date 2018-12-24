using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSizeTrigger : MonoBehaviour
{
    public float newSize = 8f;
    public bool resetOnExit = false;
    public float smoothTime;

    float originalSize = 0f;

    float targetSize;

    void Start()
    {
        targetSize = Camera.main.orthographicSize;
    }

    void Update()
    {
        float f = 0f;
        Camera.main.orthographicSize = Mathf.SmoothDamp(Camera.main.orthographicSize, targetSize, ref f, smoothTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            originalSize = Camera.main.orthographicSize;
            targetSize = newSize;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Player") && resetOnExit)
        {
            targetSize = originalSize;
        }
    }
}

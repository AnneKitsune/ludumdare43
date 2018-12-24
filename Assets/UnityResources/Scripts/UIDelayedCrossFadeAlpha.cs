using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDelayedCrossFadeAlpha : MonoBehaviour
{
    public float targetAlpha;
    public float duration;
    public float timeDelay;
    public bool isUnscaled;
    public bool destroy;

    private Graphic g;
    // Use this for initialization
    void Start()
    {
        Invoke("Go", timeDelay);
        if (destroy)
            Destroy(gameObject, timeDelay + duration);
    }

    void Go()
    {
        if (this.gameObject && g != null)
            g.CrossFadeAlpha(targetAlpha, duration, isUnscaled);
    }
}

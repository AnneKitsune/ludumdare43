using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimedFader : MonoBehaviour {
    public GameObject fadeObject;
    [HideInInspector]
    public Image fade;

    bool fading = false;
    bool fadeInDir = false;
    float fadeStartTime = 0;
    float fadeDuration = 0;
    Action callback = null;
	void Start () {
        fade = fadeObject.GetComponent<Image>();
	}
	void Update () {
        if (!fading) return;
        //Fade switch color (delta/totaltimeabs) when done callback
        if (fadeInDir)
        {
            fade.color = new Color(0, 0, 0, (Time.time-fadeStartTime)/fadeDuration);
            if((Time.time - fadeStartTime) / fadeDuration >= 1)
            {
                fading = false;
                if (callback != null)
                {
                    callback.Invoke();
                    callback = null;
                }
            }
        }
	}
    public void FadeIn(float time,Action callback = null)
    {
        if (fading) return;
        fading = true;
        fadeInDir = true;
        fadeStartTime = Time.time;
        fadeDuration = time;
        this.callback = callback;
    }
    public void FadeOut(float time)
    {
        fading = true;
        fadeInDir = false;
        fadeStartTime = Time.time;
        fadeDuration = time;
    }
}

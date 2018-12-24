using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFadeDisable : MonoBehaviour
{
    public float time;
    public float wait;
    public bool setImageAlphaTo1;
    private Graphic g;

    // Use this for initialization
    void Start()
    {
        g = GetComponent<Graphic>();
        if (setImageAlphaTo1)
        {
            Image i = GetComponent<Image>();
            i.color = i.color.SetAlpha(1f);
        }
        Invoke("Go", wait);
    }

    void Go()
    {
        g.CrossFadeAlpha(0f, time, true);
        this.SetActiveDelayed(time, false);
    }
        

}

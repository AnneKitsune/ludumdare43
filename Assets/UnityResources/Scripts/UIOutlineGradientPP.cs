using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOutlineGradientPP : MonoBehaviour
{

    public Gradient gradient;
    public float speed;

    private Outline o;

    // Use this for initialization
    void Start()
    {
        o = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        o.effectColor = gradient.Evaluate(Mathf.PingPong(Time.unscaledTime * speed, 1f));
    }
}

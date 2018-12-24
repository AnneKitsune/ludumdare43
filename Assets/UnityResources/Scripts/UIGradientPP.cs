using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGradientPP : MonoBehaviour
{

    public Gradient gradient;
    public float speed;

    private Graphic g;

    // Use this for initialization
    void Start()
    {
        g = GetComponent<Graphic>();
    }
	
    // Update is called once per frame
    void Update()
    {
        g.color = gradient.Evaluate(Mathf.PingPong(Time.unscaledTime * speed, 1f));
    }
}

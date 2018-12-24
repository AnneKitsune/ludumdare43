using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteGradient : MonoBehaviour
{

    public Gradient gradient;
    public float speed;

    private SpriteRenderer sr;

    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
	
    // Update is called once per frame
    void Update()
    {
        sr.color = gradient.Evaluate(Mathf.PingPong(Time.unscaledTime * speed, 1f));
    }
}

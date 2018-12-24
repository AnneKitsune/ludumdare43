using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TimedFlicker : MonoBehaviour
{
    public float delay;
	private float randomOffset;

	public SpriteRenderer r;
	public BoxCollider2D c;

	private System.Random rand;
    // Use this for initialization
    public IEnumerator Start()
    {
		rand = new System.Random ();
		randomOffset = ((float)rand.NextDouble()) * delay;
		yield return new WaitForSecondsRealtime(randomOffset);
		while (true) {
			Disable();
			yield return new WaitForSecondsRealtime(delay);
			Enable();
			yield return new WaitForSecondsRealtime(delay);
		}
    }

    void Disable()
    {
        //gameObject.SetActive(false);
		r.enabled = false;
		c.enabled = false;
    }
	void Enable()
	{
		//gameObject.SetActive(true);
		r.enabled = true;
		c.enabled = true;
	}
}

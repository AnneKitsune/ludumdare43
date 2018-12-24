using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepulsionImpulse : MonoBehaviour {
	public float force = 5f;
	public float radius = 1f;
	public float upwardLift = 0.0f;
	public void Repulse(GameObject obj){
		var rb = obj.GetComponent<Rigidbody>();
		if(rb != null){
			rb.AddExplosionForce(force,transform.position,radius,upwardLift);
		}
	}
}

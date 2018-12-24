using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport3D : MonoBehaviour {
	public Transform target;
	public bool resetVelocity = false;
	public bool relative;
	public bool keepOffset;
	public LayerMask layers;

	void OnTriggerEnter(Collider coll){
		int layer = coll.gameObject.layer;
		bool confirmedLayer = layers == (layers | (1 << layer));
		if (confirmedLayer) {
			Vector3 offset = Vector3.zero;
			if (keepOffset) {
				offset = coll.transform.position - transform.position;
			}
			if (relative) {
				coll.transform.position = transform.position + target.position + offset;
			}else{
				coll.transform.position = target.position + offset;
			}
			if(resetVelocity){
				var rb = coll.gameObject.GetComponent<Rigidbody>();
				if(rb)
					rb.velocity = Vector3.zero;
			}
		}
	}
}

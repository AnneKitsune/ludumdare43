/*
 * 
 * Copyright Joël Lupien (Jojolepro) 2017
 * All right reserved
 * 
 * 
 */


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class ColliderTriggerCallback : UnityEvent<Collider>
{
}

public class ColliderTrigger : MonoBehaviour {
	public LayerMask layers;
	public List<Collider> ignored;
	public ColliderTriggerCallback onCollisionEnter;
	public ColliderTriggerCallback onCollisionStay;
	public ColliderTriggerCallback onCollisionExit;
	public ColliderTriggerCallback onTriggerEnter;
	public ColliderTriggerCallback onTriggerStay;
	public ColliderTriggerCallback onTriggerExit;

	void OnCollisionEnter(Collision other){
		if(!layers.IsIncluded(other.collider.gameObject.layer))
			return;
		if(ignored.Contains(other.collider))
			return;
		onCollisionEnter.Invoke(other.collider);
	}

	void OnCollisionStay(Collision other){
		if(!layers.IsIncluded(other.collider.gameObject.layer))
			return;
		if(ignored.Contains(other.collider))
			return;
		onCollisionStay.Invoke(other.collider);
	}

	void OnCollisionExit(Collision other){
		if(!layers.IsIncluded(other.collider.gameObject.layer))
			return;
		if(ignored.Contains(other.collider))
			return;
		onCollisionExit.Invoke(other.collider);
	}

	void OnTriggerEnter(Collider other) {
		if(!layers.IsIncluded(other.gameObject.layer))
			return;
		if(ignored.Contains(other))
			return;
		onTriggerEnter.Invoke(other);
	}
	void OnTriggerStay(Collider other){
		if(!layers.IsIncluded(other.gameObject.layer))
			return;
		if(ignored.Contains(other))
			return;
		onTriggerStay.Invoke(other);
	}
	void OnTriggerExit(Collider other) {
		if(!layers.IsIncluded(other.gameObject.layer))
			return;
		if(ignored.Contains(other))
			return;
		onTriggerExit.Invoke(other);
	}
}

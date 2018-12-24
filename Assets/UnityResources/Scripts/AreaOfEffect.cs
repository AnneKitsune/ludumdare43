using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffect : MonoBehaviour {
	[Tooltip("Do you need a direct line of sight from the center of the aoe to the target")]
	public bool directLineOfSight = false;
	[Tooltip("Which game objects are to be returned by the callback")]
	public LayerMask target;
	[Tooltip("What blocks the raycast to the target")]
	public LayerMask blocking;
	public GameObjectCallback callback;

	IList<GameObject> collisions = new List<GameObject>();

	public void DoCheck(){
		foreach(var go in collisions){
			if(!directLineOfSight){
				callback.Invoke(go);
			}else{
				var dir = go.transform.position - transform.position;
				var hits = Physics.RaycastAll(transform.position,dir.normalized,dir.magnitude,blocking,QueryTriggerInteraction.Ignore);
				var blocked = false;
				foreach(var h in hits){
					if(h.transform != go.transform){
						blocked = true;
						break;
					}
				}
				if(!blocked){
					callback.Invoke(go);
				}
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		var go = other.gameObject;
		if(target.IsIncluded(go.layer)){
			collisions.Add(go);
		}
	}
	void OnTriggerExit(Collider other) {
		var go = other.gameObject;
		if(target.IsIncluded(go.layer)){
			collisions.Remove(go);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LookAtCheck : MonoBehaviour {
	public bool checkTriggers = true;
	public float maxLength = 10000f;
	public LayerMask layers;
	private IList<LookAtTrigger> lookedAt = new List<LookAtTrigger>();
	void Update () {
		var hits = Physics.RaycastAll(transform.position,transform.forward,maxLength,layers,checkTriggers ? QueryTriggerInteraction.Collide : QueryTriggerInteraction.Ignore);
		var newList = new List<LookAtTrigger>();
		foreach(var h in hits){
			var l = h.collider.gameObject.GetComponent<LookAtTrigger>();
			if(l != null){
				newList.Add(l);
			}
		}

		// if in lookedAt but not newList, stopped looking
		// if in both, continued looking
		// if in newList but not lookedAt, started looking
		var inBoth = newList.Intersect(lookedAt);
		foreach(var l in inBoth){
			l.ContinueLookAt(gameObject);
		}
		var inNew = newList.Except(lookedAt);
		foreach(var l in inNew){
			l.StartLookAt(gameObject);
		}
		var inOld = lookedAt.Except(newList);
		foreach(var l in inOld){
			l.StopLookAt(gameObject);
		}
		lookedAt = newList;
	}
}

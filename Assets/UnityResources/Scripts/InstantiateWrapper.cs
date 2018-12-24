using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateWrapper : MonoBehaviour {
	public Vector3 offset = Vector3.zero;
	public void DoInstantiate(GameObject obj){
		var go = Instantiate(obj);
		go.transform.position = this.transform.position + offset;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBillboard : MonoBehaviour {
	Camera main;
	void Start () {
		main = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(transform.position+main.transform.rotation * Vector3.forward,main.transform.rotation * Vector3.up);
	}
}

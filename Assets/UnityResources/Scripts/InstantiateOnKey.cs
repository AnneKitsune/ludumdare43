using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateOnKey : MonoBehaviour {
    public KeyCode keyCode;
    public GameObject go;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(this.keyCode)) {
            Instantiate(go);
            go.transform.position = this.transform.TransformPoint(this.transform.localPosition + this.transform.forward);
            go.GetComponent<Rigidbody>().velocity = this.transform.forward;
        }
	}
}

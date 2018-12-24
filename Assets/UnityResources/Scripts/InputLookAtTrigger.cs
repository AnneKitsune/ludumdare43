using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputLookAtTrigger : MonoBehaviour {
	public string keyInputName;
	public bool holdRepeat = false;
	public GameObjectCallback action;
	public void Action(GameObject go){
		if(holdRepeat){
			if(Input.GetButton(keyInputName)){
				action.Invoke(go);
			}
		}else{
			if(Input.GetButtonDown(keyInputName)){
				action.Invoke(go);
			}
		}
	}
}

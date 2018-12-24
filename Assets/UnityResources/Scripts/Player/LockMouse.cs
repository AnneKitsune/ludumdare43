using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMouse : MonoBehaviour {
	public bool locked = true;
	void Start () {
		ToggleCursorLock (locked);
	}
	public void ToggleCursorLock(bool lockMouse){
		locked = lockMouse;
		if (locked) {
			Cursor.lockState = CursorLockMode.Locked;
		} else {
			Cursor.lockState = CursorLockMode.None;
		}
	}
}

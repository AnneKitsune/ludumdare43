using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMouse : MonoBehaviour {
	public bool hidden = true;
	void Start(){
		ToggleHideMouse (hidden);
	}
	public void ToggleHideMouse(bool hide){
		hidden = hide;
		Cursor.visible = !hide;
	}
}

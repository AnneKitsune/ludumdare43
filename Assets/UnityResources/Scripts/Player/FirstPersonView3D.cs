using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonView3D : MonoBehaviour {
	public Transform cam;
	public MovementBase3D movementBase;
	public float sensitivityX = 1;
	public float sensitivityY = 1;

    //Idea: Show mouse icon with bar underneath that shows left/right mouse movement speed

	private float xMouseAcum = 0f;
	private float yMouseAcum = 0f;
	void Update () {
		if (!movementBase.inputEnabled)
			return;

		var xMouse = Input.GetAxisRaw("Mouse X") * sensitivityX;
		xMouseAcum += xMouse;

		float rotationX = transform.localEulerAngles.y + xMouse * 1f;


		var yMouse = Input.GetAxisRaw("Mouse Y") * sensitivityY; ;
		yMouseAcum += yMouse;
		yMouseAcum = Mathf.Clamp (yMouseAcum, -90, 90);

		transform.localEulerAngles = new Vector3(0, rotationX, 0);
		cam.localEulerAngles = new Vector3 (-yMouseAcum,0,0);
	}
}

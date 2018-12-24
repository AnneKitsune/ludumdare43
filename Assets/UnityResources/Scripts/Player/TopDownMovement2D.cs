using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement2D : MonoBehaviour {
	public MovementBase2D movementBase;
    public float force = 10;
	public float forceSprint = 20;
	public float velocity = 3;
	public float velocitySprint = 6;
	public bool absolute = false;
	public bool smoothInput = false;
	public bool counterImpulse = false;
	public string sprintInputName = "Sprint";
	void Start(){
	}
	void Update () {
		if (!movementBase.inputEnabled) return;
        //var h = Input.GetAxis("Horizontal");
		var sprint = Input.GetButton (sprintInputName);
		var h = 0.0f;
		var v = 0.0f;
		if (!smoothInput) {
			h = Input.GetAxisRaw ("Horizontal");
			v = Input.GetAxisRaw ("Vertical");
		} else {
			h = MathUtils.Clamp (Input.GetAxis("Horizontal"), -1, 1);
			v = MathUtils.Clamp (Input.GetAxis("Vertical"), -1, 1);
		}
			
		if (absolute) {
			var vel = 0f;
			if (sprint) {
				vel = velocitySprint;
			} else {
				vel = velocity;
			}
			movementBase.RigidBody().velocity = new Vector2 (h * vel, v*vel);
		} else {
			if (counterImpulse) {
				if (h<0 && movementBase.RigidBody().velocity.x>0.001)
				{
					movementBase.RigidBody().velocity = new Vector2(0, movementBase.RigidBody().velocity.y);
				}
				else if (h>0 && movementBase.RigidBody().velocity.x < -0.001)
				{
					movementBase.RigidBody().velocity = new Vector2(0, movementBase.RigidBody().velocity.y);
				}

				if (v<0 && movementBase.RigidBody().velocity.y>0.001)
				{
					movementBase.RigidBody().velocity = new Vector2(movementBase.RigidBody().velocity.x, 0);
				}
				else if (v>0 && movementBase.RigidBody().velocity.y < -0.001)
				{
					movementBase.RigidBody().velocity = new Vector2(movementBase.RigidBody().velocity.x, 0);
				}
			}
			var f = 0f;
			if (sprint) {
				f = forceSprint;
			} else {
				f = force;
			}
			movementBase.RigidBody().AddForce(new Vector2(h * f * Time.deltaTime, v * f * Time.deltaTime));
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement2D : MonoBehaviour {
	public MovementBase2D movementBase;

    public float force = 10;
	public float forceSprint = 20;
	public float velocity = 3;
	public float velocitySprint = 6;
	public bool absolute = false;
	public bool smoothInput = false;
	public bool counterImpulse = false;
	public bool onlyOnGround = true;
	public string sprintInputName = "Sprint";
	void Start(){
	}
	void Update () {
		if (!movementBase.inputEnabled || (onlyOnGround && !movementBase.IsOnGround())) return;
        //var h = Input.GetAxis("Horizontal");
		var sprint = Input.GetButton (sprintInputName);
		var h = 0.0f;
		if (!smoothInput) {
			h = Input.GetAxisRaw ("Horizontal");
		} else {
			h = MathUtils.Clamp (Input.GetAxis("Horizontal"), -1, 1);
		}
			
		if (absolute) {
			var v = 0f;
			if (sprint) {
				v = velocitySprint;
			} else {
				v = velocity;
			}
			movementBase.RigidBody().velocity = new Vector2 (h * v, movementBase.RigidBody().velocity.y);
		} else {
			if (counterImpulse) {
				if (h<0 && movementBase.RigidBody().velocity.x>0.001)
				{
					movementBase.RigidBody().velocity = new Vector2(0, movementBase.RigidBody().velocity.y);
					//movementBase.RigidBody().AddForce(new Vector2(h * force * Time.deltaTime * 5, 0));
				}
				else if (h>0 && movementBase.RigidBody().velocity.x < -0.001)
				{
					movementBase.RigidBody().velocity = new Vector2(0, movementBase.RigidBody().velocity.y);
					//movementBase.RigidBody().AddForce(new Vector2(h * force * Time.deltaTime * 5, 0));
				}
			}
			var f = 0f;
			if (sprint) {
				f = forceSprint;
			} else {
				f = force;
			}
			movementBase.RigidBody().AddForce(new Vector2(h * f * Time.deltaTime, 0));
		}
	}
}

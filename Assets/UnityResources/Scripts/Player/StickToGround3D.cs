using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToGround3D : MonoBehaviour {
    public MovementBase3D movementBase;
    public GroundCheck3D groundChecker;
    public float stickForce = 5f;
	void Start () {
		
	}
	void Update () {
        if (!movementBase.inputEnabled)
            return;
        if (!groundChecker.IsGrounded())
            return;
        movementBase.RigidBody().velocity = new Vector3(movementBase.RigidBody().velocity.x, -stickForce, movementBase.RigidBody().velocity.z);
	}
}

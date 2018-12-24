using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FrictionMode{
    Linear,
    Percent
}

public class Friction3D : MonoBehaviour {
	public MovementBase3D movementBase;
    public GroundCheck3D groundChecker;

	[Tooltip("The amount of friction speed loss by second.")]
    public float friction = 0.1f;
    [Tooltip("The way friction is applied.")]
    public FrictionMode frictionMode = FrictionMode.Percent;
    [Tooltip("The number of ticks to wait after touching the ground before applying the friction.")]
    public float waitTimeBeforeApply;

	void FixedUpdate(){
		Friction();
	}
	public void Friction(){
        if(groundChecker.IsGrounded() && groundChecker.GroundedTime() > waitTimeBeforeApply){
            if(frictionMode == FrictionMode.Linear){
                float slowdown = friction * Time.deltaTime;
                movementBase.RigidBody().velocity = new Vector3(ApplyFrictionSingle(movementBase.RigidBody().velocity.x, slowdown),movementBase.RigidBody().velocity.y,ApplyFrictionSingle(movementBase.RigidBody().velocity.z, slowdown));
            }else if(frictionMode == FrictionMode.Percent){
                var vel = movementBase.RigidBody().velocity;
                float coef = friction * Time.deltaTime;
                movementBase.RigidBody().velocity = new Vector3(ApplyFrictionSingle(vel.x, vel.x*coef),vel.y,ApplyFrictionSingle(vel.z, vel.z*coef));
            }
        }
    }

    float ApplyFrictionSingle(float v,float friction){
        if(Mathf.Abs(v) <= friction){
            return 0;
        }
        return v - friction;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirMovement3D : MonoBehaviour {
	public MovementBase3D movementBase;
    public GroundCheck3D groundChecker;

    [Tooltip("False = Forces, True = Velocity")]
	public bool absolute;
    [Tooltip("Use world coordinates XYZ.")]
	public bool absoluteAxis;
    [Tooltip("Uses Unity's built-in input smoothing. Can make controls feel slow or laggy.")]
	public bool smoothInput;
    [Tooltip("Negates the velocity when pressing the key opposite to the current velocity.")]
	public bool counterImpulse;
    [Tooltip("Allows accelerating over the maximum velocity by strafing. Only works in non-absolute mode")]
    public bool allowProjectionAcceleration = true;
    [Tooltip("Acceleration in unit/s²")]
    public float accelerate = 10f;
    [Tooltip("The maximum velocity.")]
    public float maxVelocity = 10f;
    public string sprintInputName = "Sprint";
	void Start(){
        
	}
	void FixedUpdate () {
		if (!movementBase.inputEnabled || groundChecker.IsGrounded()) return;
		var sprint = Input.GetButton (sprintInputName);
        var input = GroundMovement3D.CheckInput(smoothInput);
        
		Vector3 rel = transform.InverseTransformDirection(movementBase.RigidBody().velocity);

        if (absolute) {
			movementBase.RigidBody ().velocity = transform.TransformDirection (new Vector3 (input.x, rel.y, input.y));
		} else {
			var wishVel = rel;
            if(counterImpulse)
                wishVel = GroundMovement3D.CounterImpulse(input,wishVel);

            wishVel = Accelerate(input,wishVel,accelerate);
            if(!allowProjectionAcceleration){
            	wishVel = GroundMovement3D.LimitVelocity(wishVel,maxVelocity);
            }
            movementBase.RigidBody().velocity = transform.TransformDirection(wishVel);
        }
	}
    
    public Vector3 Accelerate(Vector2 input,Vector3 rel,float force)
    {
    	var o = rel;
        var input3 = new Vector3(input.x, 0, input.y);
        var relFlat = new Vector3(rel.x, 0, rel.z);
        if(input3.magnitude > 0){
            float proj = Vector3.Dot(relFlat,input3.normalized);
            float accelVelocity = force * Time.deltaTime;
            if(proj + accelVelocity > maxVelocity)
                accelVelocity = maxVelocity - proj;
            if(accelVelocity > 0){
                var addSpeed = input3 * accelVelocity;
                o += addSpeed;
            }
        }
        return o;
    }
}

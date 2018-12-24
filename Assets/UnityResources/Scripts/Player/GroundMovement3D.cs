using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GroundMovement3D : MonoBehaviour {
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
    [Tooltip("Acceleration in unit/s²")]
    public float accelerate = 10f;
    [Tooltip("Acceleration when sprinting in unit/s²")]
    public float accelerateSprint = 10f;
    [Tooltip("The maximum velocity.")]
    public float maxVelocity = 10f;
    public string sprintInputName = "Sprint";
	void Start(){
        
	}
	void FixedUpdate () {
		if (!movementBase.inputEnabled || !groundChecker.IsGrounded()) return;
		var sprint = Input.GetButton (sprintInputName);
        var input = CheckInput(smoothInput);
        
		Vector3 rel = transform.InverseTransformDirection(movementBase.RigidBody().velocity);

        var f = sprint ? accelerateSprint : accelerate;
        if (absolute) {
			movementBase.RigidBody ().velocity = transform.TransformDirection (new Vector3 (input.x, rel.y, input.y));
		} else {
            var wishVel = rel;
            if(counterImpulse)
                wishVel = GroundMovement3D.CounterImpulse(input,wishVel);

            wishVel = Accelerate(input,wishVel,f);
            /*if(groundChecker.GroundedTicks() >= minimumFrameFrictionDelay){
                wishVel = LimitVelocity(wishVel,maxVelocity);
            }*/
            movementBase.RigidBody().velocity = transform.TransformDirection(wishVel);
        }
	}

    public Vector3 Accelerate(Vector2 input,Vector3 rel,float force)
    {
        /*var o = rel;
        o.Scale(new Vector3(input.x,1,input.y));
        o *= force * Time.deltaTime;*/
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

    public static Vector3 CounterImpulse(Vector2 input,Vector3 relVelocity)
    {
        var o = relVelocity;
        if (input.x < 0 && relVelocity.x > 0.001)
        {
            o = new Vector3(0, relVelocity.y, relVelocity.z);
            //movementBase.RigidBody().velocity = transform.TransformDirection(new Vector3(0, relVelocity.y, relVelocity.z));
        }
        else if (input.x > 0 && relVelocity.x < -0.001)
        {
            o = new Vector3(0, relVelocity.y, relVelocity.z);
            //movementBase.RigidBody().velocity = transform.TransformDirection(new Vector3(0, relVelocity.y, relVelocity.z));
        }
        if (input.y < 0 && relVelocity.z > 0.001)
        {
            o = new Vector3(relVelocity.x, relVelocity.y, 0);
            //movementBase.RigidBody().velocity = transform.TransformDirection(new Vector3(relVelocity.x, relVelocity.y, 0));
        }
        else if (input.y > 0 && relVelocity.z < -0.001)
        {
            o = new Vector3(relVelocity.x, relVelocity.y, 0);
            //movementBase.RigidBody().velocity = transform.TransformDirection(new Vector3(relVelocity.x, relVelocity.y, 0));
        }
        return o;
    }

    public static Vector2 CheckInput(bool smooth)
    {
        var h = 0.0f;
        var v = 0.0f;
        if (!smooth)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");
        }
        else
        {
            h = MathUtils.Clamp(Input.GetAxis("Horizontal"), -1, 1);
            v = MathUtils.Clamp(Input.GetAxis("Vertical"), -1, 1);
        }
        return new Vector2(h, v);
    }

    public static Vector3 LimitVelocity(Vector3 vec, float maximumVelocity){
        var v = new Vector2(vec.x,vec.z).magnitude;
        if(v > maximumVelocity && maximumVelocity != 0){
            var ratio = maximumVelocity / v;
            return new Vector3(vec.x * ratio,vec.y,vec.z * ratio);
        }
        return vec;
    }
}

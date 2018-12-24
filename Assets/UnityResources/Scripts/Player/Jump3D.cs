using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump3D : MonoBehaviour {
	public MovementBase3D movementBase;
    public GroundCheck3D groundChecker;
    public bool checkGround = true;
    public float jumpForce = 15;
	public float jumpCooldown = 0.1f;
    public bool absoluteVelocity = true;

    public bool holdJump = false;

    public bool inputLimiter = false;
    public float inputCooldown;

    [Tooltip("Gives a bonus jump height if you hit the jump key in a specific time window when touching the ground.")]
    public bool jumpTimingBoost = false;
    [Tooltip("The bonus jump height(multiplier from base force) for the timing precision in seconds(x).")]
    public AnimationCurve jumpTimingBoostCurve;

	float lastJump = 0;
    float lastInput = 0;
    float lastActualPress = 0;
    bool inputHold = false;
    float lastJumpOffset = 0;
	void Start(){
	}
	void FixedUpdate () {
		if (!movementBase.inputEnabled) return;
        var v = Input.GetAxisRaw("Jump");
        if (v > 0)
        {
            if (!holdJump && inputHold)
                return;
            if(!inputHold)
                lastActualPress = Time.time;
            inputHold = true;
            if (inputLimiter && Time.time - lastInput < inputCooldown)
                return;
            lastInput = Time.time;
            //player radius + 1
            //RaycastHit2D hit = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, playercoll.bounds.max.y), Vector2.down,(playercoll.bounds.extents.y)*1.5f,groundMask);
            bool hit = true;
            if (checkGround)
            {
                hit = groundChecker.IsGrounded();
            }
            if (hit && Time.time - lastJump > jumpCooldown)
            {
                lastJump = Time.time;
                lastJumpOffset = groundChecker.GroundedAt() - lastActualPress;
                //float calcOffset = 1 / Math.Max(1, Math.Abs(lastOffset)) * jumpTimingMultiplier;
                float calcOffset = Mathf.Abs(lastJumpOffset);
                float forceMult = jumpTimingBoostCurve.Evaluate(calcOffset);
                float jumpF = jumpTimingBoost ? jumpForce + jumpForce * forceMult : jumpForce;
                if (absoluteVelocity)
                {
                    movementBase.RigidBody().velocity = new Vector3(movementBase.RigidBody().velocity.x,jumpF, movementBase.RigidBody().velocity.z);
                }
                else
                {
                    movementBase.RigidBody().AddForce(new Vector3(0, jumpF, 0), ForceMode.Impulse);
                }
            }
        }
        else
        {
            inputHold = false;
        }
	}

    public float LastJumpOffset(){
        return lastJumpOffset;
    }

}

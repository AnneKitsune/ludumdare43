using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck3D : MonoBehaviour {
	public MovementBase3D movementBase;
	public LayerMask ignored;

    [HideInInspector]
    bool onGround = false;
    float groundedSince = 0;
    int groundedAtTick = 0;
    int collisionCount = 0; //May fail pretty hard, but need more testing to find corner cases
    private void OnTriggerEnter(Collider other)
    {
        if (!ignored.IsIncluded(other.gameObject.layer) && !other.isTrigger)
        {
            collisionCount++;
            UpdateOnGround();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!ignored.IsIncluded(other.gameObject.layer) && !other.isTrigger)
        {
            collisionCount--;
            UpdateOnGround();
        }
    }

    void UpdateOnGround()
    {
        bool wasOnGround = onGround;
        onGround = collisionCount > 0;

        if(!wasOnGround && onGround)
        {
            groundedSince = Time.time;
            groundedAtTick = Time.frameCount;
        }
    }

    public bool IsGrounded()
    {
        return onGround;
    }

    public float GroundedAt(){
        if (onGround)
        {
            return groundedSince;
        }
        else
        {
            return 0f;
        }
    }

    public float GroundedTime()
    {
        if (onGround)
        {
            return Time.time - groundedSince;
        }
        else
        {
            return 0f;
        }
    }
    public int GroundedTicks(){
        if(onGround){
            return Time.frameCount - groundedAtTick;
        }else{
            return 0;
        }
    }
}

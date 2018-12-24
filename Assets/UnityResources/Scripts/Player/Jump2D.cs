using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump2D : MonoBehaviour {
	public MovementBase2D movementBase;
    public float jumpForce = 15;
	public float jumpCooldown = 0.1f;
    
	private float lastJump = 0;
	void Start(){
	}
	void Update () {
		if (!movementBase.inputEnabled) return;
        var v = Input.GetAxis("Vertical");
        if (v > 0)
        {
            //player radius + 1
            //RaycastHit2D hit = Physics2D.Raycast(new Vector2(gameObject.transform.position.x, playercoll.bounds.max.y), Vector2.down,(playercoll.bounds.extents.y)*1.5f,groundMask);
			bool hit = movementBase.IsOnGround();
            if (hit && Time.time - lastJump > jumpCooldown)
            {
                lastJump = Time.time;
				movementBase.RigidBody().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirMovement2D : MonoBehaviour {
	public MovementBase2D movementBase;
    public float force = 10;

    void Update()
    {
		if (!movementBase.inputEnabled || movementBase.IsOnGround()) return;
        var h = Input.GetAxis("Horizontal");
		movementBase.RigidBody().AddForce(new Vector2(MathUtils.Clamp(h, -1, 1) * force*Time.deltaTime, 0));
    }
}

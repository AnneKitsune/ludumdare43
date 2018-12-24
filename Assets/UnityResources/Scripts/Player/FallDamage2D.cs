using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage2D : MonoBehaviour {
	public MovementBase2D movementBase;
	public HealthData health;
    public float minimumFallVelocity = 0.1f;
    public float dmgPerUnit = 1f;


    private bool groundLastTick;
    private float velLastTick = 0;
	void Start(){
	}
	void Update () {
        //if !nofallupgrade && !wasonground && nowonground
		if(!groundLastTick && movementBase.IsOnGround() && (-velLastTick > minimumFallVelocity))
        {
            //damage via ratio
            health.Damage(-velLastTick * dmgPerUnit);
            Debug.Log("Damage: " + (-velLastTick * dmgPerUnit));
        }
		groundLastTick = movementBase.IsOnGround();
		velLastTick = movementBase.RigidBody().velocity.y;
	}
}

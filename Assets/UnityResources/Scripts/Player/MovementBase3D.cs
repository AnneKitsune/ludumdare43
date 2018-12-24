using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBase3D : MonoBehaviour {
    public bool inputEnabled = true;
	public Rigidbody playerrb;
	public LayerMask collisionMask;
	public float heightCheck;
	//protected BoxCollider2D playercoll;
    //protected HealthData health;

    private static bool isOnGround = false;
    private static float isOnGroundCheckTime=0;
	//private float heightCheck;
	void Start () {
		//playercoll = gameObject.GetComponent<BoxCollider2D>();
        //health = gameObject.GetComponent<HealthData>();
		//heightCheck = playercoll.bounds.size.y / 2 + 0.1f;
    }
    public bool IsOnGround()
    {
		//Caching to avoid doing multiple raycasts per frame.
        if(Time.time == isOnGroundCheckTime)
        {
            return isOnGround;
        }
        isOnGroundCheckTime = Time.time;
		isOnGround = Physics.Raycast(gameObject.transform.position, Vector3.down, heightCheck, collisionMask.value);
		return isOnGround;
    }
	public Rigidbody RigidBody(){
		return playerrb;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBase2D : MonoBehaviour {
    public bool inputEnabled = true;
	public Rigidbody2D playerrb;
	public LayerMask collisionMask;
	public float heightCheck;
    public bool groundRaycastCheck = true;
	//protected BoxCollider2D playercoll;
    //protected HealthData health;

    [HideInInspector]
    public bool isOnGround = false;
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

        if (groundRaycastCheck) {
            isOnGroundCheckTime = Time.time;
            //RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector2.down, 1f, groundMask);
            RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector2.down, heightCheck, collisionMask);
            isOnGround = hit;
            return hit;
        } else {
            return isOnGround;
        }
    }
	public Rigidbody2D RigidBody(){
		return playerrb;
	}
}

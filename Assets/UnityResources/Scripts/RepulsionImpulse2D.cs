using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepulsionImpulse2D : MonoBehaviour {
    public float force = 5f;
    public float radius = 1f;
    public float upwardLift = 0.0f;
    public void Repulse(GameObject obj){
        var rb = obj.GetComponent<Rigidbody2D>();
        if(rb != null){
            var dir = obj.transform.position - transform.position;
            var dir2 = new Vector2(dir.x, dir.y);
            var dist = dir2.magnitude;
            if(dist <= radius) {
                dir2.Normalize();
                var mult = force * Mathf.Min(radius/dist, 0.3f);
                rb.AddForce(dir2 * mult, ForceMode2D.Impulse);
                Debug.Log("force of "+mult+" towards "+ dir2);
            }
        }
    }
}
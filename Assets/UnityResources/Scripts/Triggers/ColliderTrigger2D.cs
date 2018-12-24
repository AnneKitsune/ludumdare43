using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Linq;

[System.Serializable]
public class ColliderTriggerCallback2D : UnityEvent<Collider2D>
{
}

public class ColliderTrigger2D : MonoBehaviour {
    public LayerMask layers;
    public List<Collider2D> ignored;
    public ColliderTriggerCallback2D onCollisionEnter;
    public ColliderTriggerCallback2D onCollisionStay;
    public ColliderTriggerCallback2D onCollisionExit;
    public ColliderTriggerCallback2D onTriggerEnter;
    public ColliderTriggerCallback2D onTriggerStay;
    public ColliderTriggerCallback2D onTriggerExit;

    void OnCollisionEnter2D(Collision2D other){
        if(!layers.IsIncluded(other.collider.gameObject.layer))
            return;
        if(ignored.Contains(other.collider))
            return;
        onCollisionEnter.Invoke(other.collider);
    }

    void OnCollisionStay2D(Collision2D other){
        if(!layers.IsIncluded(other.collider.gameObject.layer))
            return;
        if(ignored.Contains(other.collider))
            return;
        onCollisionStay.Invoke(other.collider);
    }

    void OnCollisionExit2D(Collision2D other){
        if(!layers.IsIncluded(other.collider.gameObject.layer))
            return;
        if(ignored.Contains(other.collider))
            return;
        onCollisionExit.Invoke(other.collider);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(!layers.IsIncluded(other.gameObject.layer))
            return;
        if(ignored.Contains(other))
            return;
        onTriggerEnter.Invoke(other);
    }
    void OnTriggerStay2D(Collider2D other){
        if(!layers.IsIncluded(other.gameObject.layer))
            return;
        if(ignored.Contains(other))
            return;
        onTriggerStay.Invoke(other);
    }
    void OnTriggerExit2D(Collider2D other) {
        if(!layers.IsIncluded(other.gameObject.layer))
            return;
        if(ignored.Contains(other))
            return;
        onTriggerExit.Invoke(other);
    }
}
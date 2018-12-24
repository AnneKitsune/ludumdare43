using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanTrigger : MonoBehaviour {
    public float force = 40f;
    public bool isInside;
    Rigidbody2D player;
    void Start()
    {
    }
    void Update()
    {
        if (isInside)
        {
            player.AddForce(gameObject.transform.up * force * Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            isInside = true;
            player = other.gameObject.GetComponent<Rigidbody2D>();
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            isInside = false;
        }
    }
}

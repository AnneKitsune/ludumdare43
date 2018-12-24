using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrapTrigger : MonoBehaviour {
    public float damageRate = 15f;
    bool isInside;
    HealthData player;
    void Update()
    {
        if (isInside)
        {
            player.Damage(damageRate*Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            isInside = true;
            player = other.gameObject.GetComponent<HealthData>();
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

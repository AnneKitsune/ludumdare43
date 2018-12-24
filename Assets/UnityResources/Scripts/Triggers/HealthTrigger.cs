using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTrigger : MonoBehaviour {
    public float healAmount = 15f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            other.gameObject.GetComponent<HealthData>().Heal(healAmount);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDamage : MonoBehaviour
{
    [HideInInspector]
    public bool isDamaging = true;
    public float hitDamage = 15f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDamaging && collision.collider.gameObject.name.Contains("Player"))
        {
            collision.collider.gameObject.GetComponent<HealthData>().Damage(hitDamage);
        }
    }
}

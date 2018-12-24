using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChronoStopTrigger : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            Chrono.ChronoStop();
        }
    }
}

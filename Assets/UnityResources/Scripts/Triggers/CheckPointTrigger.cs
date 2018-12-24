using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointTrigger : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        /*if (other.gameObject.name.Contains("Player"))
        {
            InjectorAccessor.GetInjected().GetComponent<CheckPointManager>().lastCheckPoint = gameObject;
        }*/
    }
}

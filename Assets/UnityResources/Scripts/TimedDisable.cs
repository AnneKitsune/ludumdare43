using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDisable : MonoBehaviour
{
    public float delay;

    // Use this for initialization
    public IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(delay);
        Disable();
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }
}

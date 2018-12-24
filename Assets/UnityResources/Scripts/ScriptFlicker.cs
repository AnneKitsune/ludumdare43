using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptFlicker : MonoBehaviour
{

    public MonoBehaviour script;
    public bool running = true;
    public Range timeRange;

    // Use this for initialization
    IEnumerator Start()
    {
        while (running)
        {
            script.enabled = !script.enabled;
            yield return new WaitForSeconds(timeRange.RandomNumberInRange());
        }
    }

}

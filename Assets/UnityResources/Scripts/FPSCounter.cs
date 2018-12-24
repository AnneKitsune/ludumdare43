using UnityEngine;
using System.Collections;

public class FPSCounter : MonoBehaviour
{

    public float capFPS;
    public float delay;

    string label = "";
    float count;

    IEnumerator Start()
    {
        if (capFPS > 0f)
        {
            Application.targetFrameRate = (int)capFPS;
        }

        GUI.depth = 2;
        while (true)
        {
            if (Time.timeScale == 1)
            {
                yield return new WaitForSeconds(delay);
                count = (1 / Time.deltaTime);
                label = (Mathf.Round(count)) + " fps";
            }
            else
            {
                label = "";
            }
            yield return new WaitForSeconds(1f);
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(5, 40, 100, 25), label);
    }
}
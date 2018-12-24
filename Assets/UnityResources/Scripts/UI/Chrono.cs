using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;

public class Chrono : MonoBehaviour
{
    static Stopwatch s = new Stopwatch();

    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = s.Elapsed.TotalSeconds > 0d ? ChronoGetString() : string.Empty;
    }

    public static void ChronoStart()
    {
        s.Reset();
        s.Start();
    }

    public static void ChronoStop()
    {
        s.Stop();
    }

    public static double ChronoGetTime()
    {
        return s.Elapsed.TotalSeconds;
    }

    public static string ChronoGetString()
    {
        return s.Elapsed.Minutes + ":" + s.Elapsed.Seconds + ":" + s.Elapsed.Milliseconds;
    }
}

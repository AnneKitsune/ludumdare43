using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    public float time;

    public float elapsedTime = 0f;

    public float remainingTime{ get { return time - elapsedTime; } }

    public float fractionCompleted{ get { return elapsedTime / time; } }

    public float clampedFractionCompleted{ get { return Mathf.Clamp01(elapsedTime / time); } }

    public bool isFinished;

    public int indexCompleted;

    public bool autoReset;

    public bool autoStop;

    public bool isPlaying;

    public bool useUnscaledTime;

    public Timer(float time, bool autoReset = false, bool startNow = true, bool autoStop = false)
    {
        this.time = time;
        isPlaying = startNow;
        this.autoReset = autoReset;
        this.autoStop = autoStop;
    }

    public void Update(float timeScale = 1f)
    {
        isFinished = false;
        if (isPlaying)
        {
            elapsedTime += (useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime) * timeScale;
            if (remainingTime <= 0f)
            {
                indexCompleted++;
                isFinished = true;
                if (autoReset)
                    elapsedTime = 0f;
                if (autoStop)
                    Stop();
            }
        }
    }

    public void Start()
    {
        isPlaying = true;
    }

    public void Pause()
    {
        isPlaying = false;
    }

    public void Stop()
    {
        isPlaying = false;
        elapsedTime = 0f;
    }

    public void Reset()
    {
        elapsedTime = 0f;
    }

    public void ClampTime()
    {
        elapsedTime = Mathf.Clamp(elapsedTime, 0f, time);
    }

    public void Terminate()
    {
        //To finish the timer instantly
        elapsedTime = time;
        isFinished = true;
    }

    public void AddTime(float time)
    {
        this.time += time;
    }

    public void SimulateTimeProgress(float purcent)
    {
        elapsedTime += time * purcent;
    }
}

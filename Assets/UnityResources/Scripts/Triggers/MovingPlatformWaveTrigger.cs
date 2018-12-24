using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MovingPlatformWaveTrigger : WaveActivableBase {
    public float travelTime = 3f;
    public Transform end;
    public ParticleSystem particles;

    bool running = true;
    Vector2 endVec;
    Vector2 iniPos;
    float timeFromStart = 0;
    public override void Start () {
        base.Start();
        iniPos = transform.position;
        endVec = end.position;
        if (!OnByDefault) OnDeactivate();
	}
	void Update () {
        if (running)
        {
            timeFromStart += Time.deltaTime;
            transform.position = Vector2.LerpUnclamped(iniPos, endVec, Mathf.PingPong((1 / travelTime) * timeFromStart, 1));
        }
	}
    public override void OnActivate()
    {
        running = true;
        particles.Play();
    }

    public override void OnDeactivate()
    {
        running = false;
        particles.Stop();
    }
}

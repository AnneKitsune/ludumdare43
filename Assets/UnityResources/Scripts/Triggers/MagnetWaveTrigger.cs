using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MagnetWaveTrigger : WaveActivableBase
{
    public float travelTime = 3f;
    public ParticleSystem particles;
    public ParticleSystem particles2;
    public PointEffector2D effector;
    public SpriteRenderer rail;

    bool running = true;
    Vector2 iniPos;
    Vector2 endVec;
    float timeFromStart = 0;
    public override void Start()
    {
        base.Start();
        iniPos = new Vector2(rail.bounds.min.x, transform.position.y);
        endVec = new Vector2(rail.bounds.max.x, transform.position.y);
        timeFromStart = travelTime / 2;
        if (!OnByDefault) OnDeactivate();
    }
    void Update()
    {
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
        particles2.Play();
        effector.enabled = true;
    }

    public override void OnDeactivate()
    {
        running = false;
        particles.Stop();
        particles2.Stop();
        effector.enabled = false;
    }
}
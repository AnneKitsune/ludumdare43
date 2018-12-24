using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FanWaveTrigger : WaveActivableBase
{
    public FanTrigger fan;
    public ParticleSystem activeVFX;
    public ParticleSystem windVFX;

    public override void Start()
    {
        base.Start();
        if (!OnByDefault)
            OnDeactivate();
    }

    public override void OnActivate()
    {
        fan.enabled = true;
        activeVFX.Play();
        windVFX.Play();
        //var c = Physics2D.IsTouching(gameObject.GetComponent<BoxCollider2D>(), InjectorAccessor.GetInjected().GetComponent<PlayerInjector>().player.GetComponent<CircleCollider2D>());
        //fan.isInside = c;
    }

    public override void OnDeactivate()
    {
        fan.enabled = false;
        activeVFX.Stop();
        windVFX.Stop();
    }
}

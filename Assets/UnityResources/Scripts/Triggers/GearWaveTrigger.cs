using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GearWaveTrigger : WaveActivableBase
{
    public HitDamage[] hd;
    public Rotate rotate;
    public ParticleSystem center;

    public override void Start()
    {
        base.Start();
        if (!OnByDefault)
            OnDeactivate();
    }

    public override void OnActivate()
    {
        rotate.enabled = true;
        foreach (HitDamage h in hd)
            h.isDamaging = true;

        center.Play();
    }

    public override void OnDeactivate()
    {
        rotate.enabled = false;
        foreach (HitDamage h in hd)
            h.isDamaging = false;
        center.Stop();
    }
}

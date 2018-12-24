using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WaveActivableBase : MonoBehaviour
{
    public bool OnByDefault = true;
    [HideInInspector]
    public bool activated;
    [HideInInspector]
    public bool isAlreadyToggledThisFrame;

    public virtual void Start()
    {
        activated = OnByDefault;
    }

    public void Toggle()
    {
        if (!isAlreadyToggledThisFrame)
        {
            activated = !activated;
            if (activated)
            {
                OnActivate();
            }
            else
            {
                OnDeactivate();
            }
        }
        isAlreadyToggledThisFrame = true;
    }

    public virtual void LateUpdate()
    {
        isAlreadyToggledThisFrame = false;
    }

    public abstract void OnActivate();

    public abstract void OnDeactivate();
}

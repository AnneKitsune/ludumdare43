using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthData : MonoBehaviour {
    protected float Health = 100;

    protected GameUIManager ui;

    void Start()
    {
        ui = InjectorAccessor.GetInjected().GetComponent<GameUIManager>();
    }
    public void Damage(float amount)
    {
        Health -= amount;
        //Update UI
        //ui.UpdateHealth(Health);
        if(Health < 0)
        {
            Health = 0;
            Kill();
            //Start hit anim
            //Start hit sound
        }
    }
    public void Kill()
    {
		Health = 0;
        //Disable Input
        //MovementBase.inputEnabled = false;
        //Show Death Screen
        //InjectorAccessor.GetInjected().GetComponent<GameUIManager>().fader.FadeIn(3f, OnFadeDone);
    }
    void OnFadeDone()
    {
        Respawn();
    }
    public void Respawn()
    {
        //MovementBase.inputEnabled = true;
        //SceneUtils.LoadMap(SceneUtils.GetCurrentMap());
    }
    public void Heal(float amount)
    {
        Health += amount;
        //ui.UpdateHealth(Health);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager : MonoBehaviour {
    public GameObject canvasPrefab;
    [HideInInspector]
    public GameObject canvas;
    [HideInInspector]
    public CanvasAccessor canvasAccessor;
    [HideInInspector]
    public TimedFader fader;
    void Start () {
        canvas = GameObject.Instantiate(canvasPrefab);
        canvasAccessor = canvas.GetComponent<CanvasAccessor>();
        fader = canvas.GetComponent<TimedFader>();
    }
    /*public void UpdateHealth(float amount)
    {
        canvasAccessor.healthSlider.fillAmount = (amount / CharStats.maxOrganicHealth);
    }
    public void UpdateEnergy(float amount)
    {
        canvasAccessor.energySlider.fillAmount = (amount / CharStats.maxEnergy);
    }*/
    public void SetFade(float amount)
    {
        canvasAccessor.fade.color = new Color(0, 0, 0, amount);
    }
}

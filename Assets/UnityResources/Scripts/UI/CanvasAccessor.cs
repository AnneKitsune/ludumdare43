using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasAccessor : MonoBehaviour {
    public GameObject healthSliderObject;
    public GameObject energySliderObject;
    public GameObject fadeObject;
    public GameObject bunnyText;
    [HideInInspector]
    public Image healthSlider;
    [HideInInspector]
    public Image energySlider;
    [HideInInspector]
    public Image fade;
    void Start () {
        healthSlider = healthSliderObject.GetComponent<Image>();
        energySlider = energySliderObject.GetComponent<Image>();
        fade = fadeObject.GetComponent<Image>();
    }
}

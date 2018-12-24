using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    public GameObject Player;
    public List<Step> steps;
    public bool enableTutorial;

    public int currentStep = 0;

	// Use this for initialization
	void Start () {
        Player.GetComponent<MovementBase3D>().inputEnabled = false;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;

        List<Step> SortedSteps = steps.OrderBy(o => o.step).ToList();

        foreach (Step step in SortedSteps){
            
        }
    }

    // Update is called once per frame
    void Update () {
        if(enableTutorial){
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                switch (currentStep + 1)
                {
                    case 1:

                        break;

                    default:
                        Player.GetComponent<MovementBase3D>().inputEnabled = true;
                        Time.timeScale = 1f;
                        Cursor.lockState = CursorLockMode.Locked;
                        break;
                }
            }
        }
    }

}

[System.Serializable]
public class Step
{
    public int step;
    public GameObject Panel;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchapDetector : MonoBehaviour
{
    public CanvasGroup mainMenu;

    bool triggered;
    // Use this for initialization
    void Start()
    {
		
    }
	
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            triggered = true;
            mainMenu.gameObject.SetActive(true);
        }

        if (triggered)
        {
            mainMenu.alpha += Time.deltaTime * 2f;
        }

    }
}

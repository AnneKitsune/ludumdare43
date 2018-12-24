using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour {

    public GameObject Player;
    public GameObject MenuPanel;
    public bool menuOpened = false;
    
	// Use this for initialization
	void Start () {
        menuOpened = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)){
            Player.gameObject.GetComponent<KillPlayer>().enabled = false;
            if (menuOpened)
                ClosePauseMenu();
            else
                OpenPauseMenu();
            Timer(2f, EnableKillPlayer);
        }
    }

    public void EnableKillPlayer(){
        Player.gameObject.GetComponent<KillPlayer>().enabled = true;
    }

    public void ReloadScene()
    {
        ClosePauseMenu();
        EnableKillPlayer();
        SceneUtils.LoadMap(SceneUtils.GetCurrentMap());
    }

    public void Timer(float TimeLeft, Action callback)
    {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft < 0)
        {
            callback();
        }
    }

    public void OpenPauseMenu(){
        Debug.Log("MenuOpen");
        menuOpened = true;
        MenuPanel.gameObject.SetActive(true);
        Player.GetComponent<MovementBase3D>().inputEnabled = false;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ClosePauseMenu(){
        menuOpened = false;
        MenuPanel.gameObject.SetActive(false);
        Player.GetComponent<MovementBase3D>().inputEnabled = true;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

}

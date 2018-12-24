using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircularUI : MonoBehaviour
{
    private Vector2 Mouseposition;
    private Vector2 fromVector2M = new Vector2(0.5f, 1.0f);
    private Vector2 centercircle = new Vector2(0.5f, 0.5f);
    private Vector2 toVector2M;

    [Header("Menu buttons")]
    public List<MenuButton> menuButtons = new List<MenuButton>();

    [Header("Button colors")]
    public Color NormalColor;
    public Color HighlightColor;
    public Color PressedColor;

    [Header("Linked objects")]
    public GameObject Parrent;
    public GameObject Player;
    public Image Image;
    public Image Arrow;

    [Header("Variables")]
    public bool menuOpened = false;
    public int CurrentMenuItem;
    public int OldMenuItem;



    // Use this for initialization
    void Start()
    {
        UpdateButtons();
        CurrentMenuItem = -1;
        OldMenuItem = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            OpenMenu();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!menuOpened)
            {
                Debug.Log("Closed menu click");
                if (CurrentMenuItem < 0)
                {
                    Debug.Log("No Block Selected, Open Menu");
                    OpenMenu();
                }
                else
                {
                    Debug.Log("Place block: " + CurrentMenuItem);
                    Player.gameObject.GetComponent<KillPlayer>().OnSelected(menuButtons[CurrentMenuItem].block);
                }
            }else{
                ButtonAction();
            }
        }

        if (menuOpened)
        {
            GetCurrentMenuItem();
        }
    }

    public void Timer(float TimeLeft, Action callback)
    {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft < 0)
        {
            callback();
        }
    }

    public void OpenMenu()
    {
        Cursor.visible = true;
        Time.timeScale = 0f;
        Parrent.gameObject.SetActive(true);
        Player.GetComponent<MovementBase3D>().inputEnabled = false;
        Cursor.lockState = CursorLockMode.None;
        menuOpened = true;
        Debug.Log("OpenCircularMenu");
    }
    public void CloseMenu()
    {
        Cursor.visible = false;
        menuOpened = false;
        Parrent.gameObject.SetActive(false);
        Player.GetComponent<MovementBase3D>().inputEnabled = true;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("CloseCircularMenu");
    }


    public void UpdateButtons()
    {
        float percent = (-(360f / menuButtons.Count)) * (menuButtons.Count / 2);
        if (menuButtons.Count % 2 != 0)
        {
            percent -= (360f / menuButtons.Count) / 2;
        }
        
        
        float fill = ((360f / menuButtons.Count) / 360f);
        
        foreach (MenuButton button in menuButtons)
        {
            Image image = (Image)Instantiate(Image);
            image.gameObject.SetActive(true);
            image.transform.SetParent(Parrent.transform, false);
            image.color = NormalColor;
            
            var r = image.transform.rotation;
            image.transform.rotation = Quaternion.Euler(r.x, r.y, percent);
            image.fillAmount = fill;

            var img2 = image.transform.GetChild(0);
            img2.GetComponent<Image>().sprite = button.icon;

            button.sceneImage = image;
            percent -= (360f / menuButtons.Count);
        }
        Image.enabled = false;
    }
    
    public void GetCurrentMenuItem()
    {
        Mouseposition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        
        toVector2M = new Vector2(Mouseposition.x / Screen.width, Mouseposition.y / Screen.height);
        
        float angle = (Mathf.Atan2(fromVector2M.y - centercircle.y, fromVector2M.x - centercircle.x) - Mathf.Atan2(toVector2M.y - centercircle.y, toVector2M.x - centercircle.x)) * Mathf.Rad2Deg;
        
        Quaternion r = Arrow.transform.rotation;
        Arrow.transform.rotation = Quaternion.Euler(r.x, r.y, -angle);
        
        if (angle < 0)
            angle += 360;
        CurrentMenuItem = (int)(angle / (360 / menuButtons.Count));
        
        if (CurrentMenuItem != OldMenuItem)
        {
            menuButtons[OldMenuItem].sceneImage.color = NormalColor;
            OldMenuItem = CurrentMenuItem;
            menuButtons[CurrentMenuItem].sceneImage.color = HighlightColor;
        }
    }
    
    public void ButtonAction()
    {
        menuButtons[CurrentMenuItem].sceneImage.color = PressedColor;
        CloseMenu();
    }
}

[System.Serializable]
public class MenuButton
{
    [HideInInspector]
    public Image sceneImage; 
    public Sprite icon;
    public GameObject block;
}
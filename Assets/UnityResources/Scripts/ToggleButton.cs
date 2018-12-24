using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Skill
{
    Jump,
    Aerial,
    NoFall,
    Brake
}

public class ToggleButton : MonoBehaviour
{
    public Skill skill;
    public Color activeColor;
    public Color disabledColor;
    public bool active;

    Button b;
    // Use this for initialization
    void Start()
    {
        b = GetComponent<Button>();
        b.onClick.AddListener(OnClick);
    }
	
    // Update is called once per frame
    void Update()
    {
		
    }

    void OnClick()
    {
        active = !active;
        ColorBlock cb = b.colors;
        cb.normalColor = active ? activeColor : disabledColor;
        b.colors = cb;
    }
}

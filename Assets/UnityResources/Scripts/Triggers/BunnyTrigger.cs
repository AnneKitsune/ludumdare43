using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BunnyTrigger : MonoBehaviour {
    GameObject txt;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            txt.SetActive(true);
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    void Start()
    {
        txt = InjectorAccessor.GetInjected().GetComponent<GameUIManager>().canvasAccessor.bunnyText;
    }
    void Update()
    {
        txt.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }
}

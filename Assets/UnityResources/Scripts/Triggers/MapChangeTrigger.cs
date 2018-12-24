using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChangeTrigger : MonoBehaviour {
    public string MapTarget;
    [HideInInspector]
    public bool startedTransition = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.name.Contains("Player")) return;
        startedTransition = true;
        InjectorAccessor.GetInjected().GetComponent<GameUIManager>().fader.FadeIn(2f, OnFadeDone);
    }
    void OnFadeDone()
    {
        //InjectorAccessor.GetInjected().GetComponent<CheckPointManager>().lastCheckPoint = null;
        if(MapTarget == "MainMenu")
            SceneUtils.LoadMap(MapTarget,true);
        else
            SceneUtils.LoadMap(MapTarget);
    }
}

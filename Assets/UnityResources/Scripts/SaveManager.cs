using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {
    [HideInInspector]
    public float lastSave = 0f;
    public static readonly float saveDelay = 20f;
	void Start () {
        SaveHelper.Load();
        lastSave = Time.time;
        DontDestroyOnLoad(this);
	}
	void Update () {
		if(lastSave - Time.time > saveDelay)
        {
            lastSave = Time.time;
            SaveHelper.Save();
        }
	}
    void OnApplicationQuit()
    {
        SaveHelper.Save();
    }
}

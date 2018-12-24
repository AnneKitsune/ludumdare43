using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInjector{
    public static List<GameObject> injectPrefabs = new List<GameObject>();
    public static void DoInject()
    {
        foreach(var go in injectPrefabs)
        {
            GameObject.Instantiate(go);
        }
    }
}

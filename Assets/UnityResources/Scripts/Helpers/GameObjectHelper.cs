using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectHelper {
    public static List<GameObject> GetPartialName(string name)
    {
        List<GameObject> o = new List<GameObject>();
        var gos = GameObject.FindObjectsOfType<GameObject>();
        foreach (var g in gos)
        {
            if (g.activeInHierarchy)
            {
                if (g.name.Contains(name))
                {
                    o.Add(g);
                }
            }
        }
        return o;
    }
    public static GameObject GetFirstPartialName(string name)
    {
        var gos = GameObject.FindObjectsOfType<GameObject>();
        foreach (var g in gos)
        {
            if (g.activeInHierarchy)
            {
                if (g.name.Contains(name))
                {
                    return g;
                }
            }
        }
        return null;
    }
	public static T GetComponentFirstTag<T>(string tag){
		foreach(var go in GameObject.FindGameObjectsWithTag(tag)){
			var c = go.GetComponent<T> ();
			if (c != null) {
				return c;
			}
		}
		return default(T);
	}
}

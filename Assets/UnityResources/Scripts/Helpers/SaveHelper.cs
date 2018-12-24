using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHelper {
    public static void Load()
    {
		
    }
    public static void Save()
    {

        PlayerPrefs.Save();
    }
    static int s(bool v)
    {
        return v ? 1 : 0;
    }
    static bool l(int v)
    {
        return v==1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    static bool alreadySpawned;
    // Use this for initialization
    void Start()
    {
        if (alreadySpawned)
        {
            Destroy(gameObject);
            return;
        }
        alreadySpawned = true;
        DontDestroyOnLoad(gameObject);


    }

}

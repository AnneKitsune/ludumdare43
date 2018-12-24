using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUtils : MonoBehaviour {
    private static bool _init = false;
    private static bool injectDisabled = false;
    public static void LoadMap(string mapName,bool disableInject = false)
    {
        injectDisabled = disableInject;
        if (!_init)
        {
            SceneManager.sceneLoaded += OnLevelFinishLoading;
            _init = true;
        }

        SceneManager.LoadScene(mapName, LoadSceneMode.Single);

    }
    public void LoadMapWrapper(string mapName) {
        SceneUtils.LoadMap(mapName, true);
    }
    public static void OnLevelFinishLoading(Scene scene, LoadSceneMode mode)
    {
        if (injectDisabled) return;
        MapInjector.DoInject();
    }
    public void ReloadScene(){
        Debug.Log("Reloading scene..");
        SceneUtils.LoadMap(SceneUtils.GetCurrentMap());
    }
    public static string GetCurrentMap()
    {
        return SceneManager.GetActiveScene().name;
    }
}

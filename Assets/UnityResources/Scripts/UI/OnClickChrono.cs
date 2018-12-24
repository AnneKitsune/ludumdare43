using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickChrono : MonoBehaviour {
    public void OnClick()
    {
        //GameplaySessionSettings.SetSpeedRun();
        Chrono.ChronoStart();
        SceneUtils.LoadMap("Level1");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathUtils  {
    public static float Clamp(float val, float min, float max)
    {
        float o = val;
        if(val < min)
        {
            o = min;
        }else if(val > max)
        {
            o = max;
        }
        return o;
    }
}

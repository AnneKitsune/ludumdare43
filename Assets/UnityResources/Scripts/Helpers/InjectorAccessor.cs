using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InjectorAccessor {
    public static GameObject GetInjected()
    {
        return GameObjectHelper.GetFirstPartialName("Injection");
    }
}

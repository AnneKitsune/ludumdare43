using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{

    public Vector2 velocity;
    public bool isLocal;

    // Update is called once per frame
    void Update()
    {
        if (!isLocal)
            transform.Translate(velocity * Time.unscaledDeltaTime);
        else
            transform.Translate(velocity * Time.unscaledDeltaTime, Space.Self);
    }
}

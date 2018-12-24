using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{

    [Tooltip("Vector which defines at which velocity (°/s) the transform should be rotated")]
    public Vector3 angularSpeed;

    [Tooltip("Defines if the transform should be rotated within the orbit of another transform")]
    public Transform around;

    [Tooltip("Defines the cosine factor that alter the speed of the rotation. Leave this to 0 if you don't want it.")]
    public float cosFactor;

    public bool unscaledTime;
    	
    // Update is called once per frame
    void Update()
    {
        if (around == null)
            transform.Rotate(angularSpeed * (unscaledTime ? Time.unscaledDeltaTime : Time.deltaTime) * (Mathf.Abs(Mathf.Cos(cosFactor * Time.time)) + cosFactor));
        else
            transform.RotateAround(around.position, angularSpeed.normalized, angularSpeed.magnitude * (unscaledTime ? Time.unscaledDeltaTime : Time.deltaTime) * (Mathf.Abs(Mathf.Cos(cosFactor * Time.time)) + cosFactor));
    }
}

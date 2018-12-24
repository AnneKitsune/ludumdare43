using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour
{

    public Transform toFollow;

    public bool x;
    public bool y;
    public bool z;


    public Range xRange;
    public Range yRange;
    public Range zRange;

    void Start()
    {
        
    }
	
    // Update is called once per frame
    void Update()
    {     
        if (toFollow != null)
        {
            float xpos = transform.position.x;
            float ypos = transform.position.y;
            float zpos = transform.position.z;

            if (x)
            {
                if (xRange.Length > 0f)
                    xpos = Mathf.Clamp(toFollow.position.x, xRange.min, xRange.max);
                else
                    xpos = toFollow.position.x;
            }
            if (y)
            {
                if (yRange.Length > 0f)
                    ypos = Mathf.Clamp(toFollow.position.y, yRange.min, yRange.max);
                else
                    ypos = toFollow.position.y;
            }
            if (z)
            {
                if (zRange.Length > 0f)
                    zpos = Mathf.Clamp(toFollow.position.z, zRange.min, zRange.max);
                else
                    zpos = toFollow.position.z;
            }

            transform.position = new Vector3(xpos, ypos, zpos);
        }
    }
}

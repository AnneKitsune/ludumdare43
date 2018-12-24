using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    public int MaxBlocks = 10;
    public Canvas CircularMenu;

    private GameObject PlayerObject;
    private List<GameObject> blocks = new List<GameObject>();


	//// Use this for initialization
	void Start () {
        PlayerObject = gameObject;
	}
	
    public void OnSelected(GameObject block){
        if (blocks.Count > MaxBlocks)
        {
            GameObject blk = blocks.First();
            blocks.Remove(blk);
            Destroy(blk);
        }
        Vector3 loc = PlayerObject.transform.position;
        GameObject newblock = Instantiate(block, new Vector3(loc.x, loc.y - .5f, loc.z), PlayerObject.transform.rotation);
        blocks.Add(newblock);
        PlayerObject.transform.position = Vector3.zero;
        PlayerObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}

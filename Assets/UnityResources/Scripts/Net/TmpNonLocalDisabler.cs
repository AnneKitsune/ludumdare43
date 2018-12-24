using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TmpNonLocalDisabler : NetworkBehaviour {
	public NetworkIdentity networkIdentity;
	public List<GameObject> toDisable;
	public GroundMovement3D g;
	public FirstPersonView3D v;
	void Start(){
		Debug.Log("networkIdentity.localPlayerAuthority = "+hasAuthority);
		if(!hasAuthority && !isServer){
			foreach(var o in toDisable){
				o.SetActive(false);
			}
			g.enabled = false;
			v.enabled = false;
		}
	}
}

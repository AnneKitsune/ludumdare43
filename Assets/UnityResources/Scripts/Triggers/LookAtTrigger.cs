using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GameObjectCallback : UnityEvent<GameObject>
{
}

public class LookAtTrigger : MonoBehaviour {
	public GameObjectCallback onStart;
	public GameObjectCallback onStay;
	public GameObjectCallback onStop;
	public void StartLookAt(GameObject obj){
		onStart.Invoke(obj);
	}
	public void ContinueLookAt(GameObject obj){
		onStay.Invoke(obj);
	}
	public void StopLookAt(GameObject obj){
		onStop.Invoke(obj);
	}
}

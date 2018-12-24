using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class NetManagerClient : MonoBehaviour {

	public NetworkClient net;
	
	void Start () {
		foreach(var p in gameObject.GetComponent<NetManager>().prefabs)
			ClientScene.RegisterPrefab(p);

		net = new NetworkClient();
		net.RegisterHandler(MsgType.Connect,OnConnected);
		//net.RegisterHandler(NetTypes.SideSet,OnSideSet);
		//net.Connect("raidable.ddns.net",28015);
		net.Connect("127.0.0.1",28015);
		//ClientScene.Ready(net.connection);
		//ClientScene.AddPlayer(net.connection, 0);
	}

	public void Init(){
		/*ClientScene.RegisterPrefab(gameObject.GetComponent<NetManager>().paddlePrefab);
		ClientScene.RegisterPrefab(gameObject.GetComponent<NetManager>().ballPrefab);
		net = new NetworkClient();
		net.RegisterHandler(MsgType.Connect,OnConnected);
		net.RegisterHandler(NetTypes.SideSet,OnSideSet);
		net.Connect("raidable.ddns.net",28015);*/
		//net.Connect("127.0.0.1",28015);
	}

	void OnConnected(NetworkMessage netMsg){
		Debug.Log("Client connected with success");
		ClientScene.AddPlayer(net.connection, 0);
	}

	void OnSideSet(NetworkMessage msg){
		/*var m = msg.ReadMessage<NetMsgSideSet>();
		side = m.side;*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

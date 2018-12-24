#if SERVER
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;
using System.Threading;

public class NetManagerServer : MonoBehaviour {
	GameObject last;
	void Start () {
		var success = NetworkServer.Listen("127.0.0.1",28015);
		NetworkServer.RegisterHandler(MsgType.Connect,OnConnected);
		NetworkServer.RegisterHandler(MsgType.AddPlayer, AddPlayer);
		Debug.Log("Created net server success? = "+success);
	}

	public static void SendMessage<T> (T msg) where T: MessageBase{
		if(msg is WithQos){
			
		}else{
			
		}
	}
	void AddPlayer(NetworkMessage netMsg){

		Debug.Log("Setting Client Ready");
		var conn = NetworkServer.connections[NetworkServer.connections.Count-1];
		NetworkServer.SetClientReady(conn);

		Debug.Log("Instanciating prefab to client #"+(NetworkServer.connections.Count-1));
		var o = (GameObject)Instantiate(gameObject.GetComponent<NetManager>().prefabs[1]);
		//NetworkServer.SpawnWithClientAuthority(o, conn);
		NetworkServer.AddPlayerForConnection(conn, o, 0);
		last = o;
	}
	void OnConnected(NetworkMessage netMsg){
		Debug.Log("Someone connected!! yay");
		//NetworkServer.Spawn(o);

		/*var count = NetworkServer.connections.Count;
		var conn = NetworkServer.connections[count-1];
		NetworkServer.SetClientReady(conn);
		var last = conn.connectionId;
		var msg = new NetMsgSideSet();
		msg.side = first ? Side.Left : Side.Right;
		NetworkServer.SendToClient(last,NetTypes.SideSet,msg);

		if(count >= 2){
			var ball = (GameObject)Instantiate(gameObject.GetComponent<NetManager>().ballPrefab);
			ball.transform.position = new Vector2(0,0.5f);
			var b = ball.GetComponent<Ball>();
			b.paddle1 = paddle1;
			b.paddle2 = paddle2;
			NetworkServer.Spawn(ball);
		}
		var paddle = (GameObject)Instantiate(gameObject.GetComponent<NetManager>().paddlePrefab, transform.position, Quaternion.identity);
		var paddlep = paddle.GetComponent<Player>();
		paddlep.side = msg.side;
		NetworkServer.SpawnWithClientAuthority(paddle, conn);
		if(count == 1){
			paddle1 = paddlep;
		}else if (count == 2){
			paddle2 = paddlep;
		}

		first = false;*/
	}
	// Update is called once per frame
	void Update () {
		if(last != null)
		Debug.Log("Last pos: "+last.transform.position);
	}
}
#endif
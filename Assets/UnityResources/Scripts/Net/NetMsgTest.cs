using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetMsgTest : MessageBase, WithQos{
	public string msg;
	public NetMsgTest(string msg){
		this.msg = msg;
	}
}
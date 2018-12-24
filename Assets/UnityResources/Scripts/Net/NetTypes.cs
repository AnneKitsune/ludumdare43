using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;
using System;

public enum NetTypes {
    Test,
}

public static class NetTypesHelper{
	public static short getCode(NetTypes t){
		return (short)(MsgType.Highest + 1 + (short)t);
	}
}
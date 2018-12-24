using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading;
using System.Diagnostics;

public class NetManager : MonoBehaviour {

	public static bool Server = false;

	public static bool host = false;
	public static Process hostProcess = null;

	public List<GameObject> prefabs;

	#if SERVER
	public static NetManagerServer srv;
	#endif
	public static NetManagerClient cl;
	void Start () {
		#if SERVER
			if(System.Environment.GetCommandLineArgs().Contains("-server")){
				Server = true;
				BootstrapServer();
			}
			else if(System.Environment.GetCommandLineArgs().Contains("-host")){
				BootstrapHost();
			}else{
				BootstrapClient();
			}
		#else
		BootstrapClient();
		#endif
	}

	void BootstrapHost(){
		host = true;
		hostProcess = Process.Start(System.Environment.GetCommandLineArgs()[0],"-batchmode -nographics -server -logFile serverlog.txt");
		UnityEngine.Debug.Log("proc started");
		StartClientDelayed();
	}

	void StartClientDelayed(){
		Thread.Sleep(5000);
		BootstrapClient();
	}

	void OnApplicationQuit(){
		if(host && hostProcess != null){
			hostProcess.CloseMainWindow();
			hostProcess.Close();
			UnityEngine.Debug.Log("proc ended");
		}
	}

	#if SERVER
	void BootstrapServer(){
		srv = gameObject.AddComponent<NetManagerServer>();
	}
	#endif
	void BootstrapClient(){
		cl = gameObject.AddComponent<NetManagerClient>();
		cl.Init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

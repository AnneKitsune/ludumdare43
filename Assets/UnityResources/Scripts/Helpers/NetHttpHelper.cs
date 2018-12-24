using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetHttpHelper : MonoBehaviour {
	void Start () {
		//StartCoroutine(GetBestScores("floortiles"));
		//StartCoroutine(PostScore("floortiles",13.5f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static UnityWebRequest JsonPost(string url, string json){
		var data = System.Text.Encoding.UTF8.GetBytes(json);
		UnityWebRequest r = UnityWebRequest.Post(url,json);
		r.SetRequestHeader("Content-Type", "application/json");
		UploadHandlerRaw uhr = new UploadHandlerRaw(data);
		uhr.contentType = "application/json";
		r.uploadHandler = uhr;
		DownloadHandler dh = new DownloadHandler();
		r.downloadHandler = dh;
		return r;
	}

	public static string GetResult(UnityWebRequest r){
		if(r.isNetworkError || r.isHttpError){
			Debug.LogError("Network Web Request Error: "+r.error);
		}else{
			//Debug.Log("Answer from web request: "+r.downloadHandler.text);
			return r.downloadHandler.text;
		}
		return "";
	}
}
class DownloadHandler: DownloadHandlerScript {
   public delegate void Finished();
   public event Finished onFinished;

   protected override void CompleteContent ()
   {
      base.CompleteContent ();
      if (onFinished!= null) {
       	onFinished();
      }
   }
}
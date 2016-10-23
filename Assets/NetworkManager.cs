using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkManager: MonoBehaviour {
	void Start() {
		StartCoroutine(GetText());

	}

	public string ImagePath = "";
	IEnumerator GetText() {
		while (true) {
			UnityWebRequest www = UnityWebRequest.Get ("http://localhost:8000/text.txt");
			yield return www.Send ();

			if (www.isError) {
				Debug.Log (www.error);
			} else {
				// Show results as text
				ImagePath = (www.downloadHandler.text);
				Debug.Log (ImagePath);
				// Or retrieve results as binary data
				byte[] results = www.downloadHandler.data;
			}
			yield return new WaitForSeconds (5);
		}
	}
		
}
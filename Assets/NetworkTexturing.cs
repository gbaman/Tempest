using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkTexturing: MonoBehaviour {


	void Start() {

		StartCoroutine(GetTexture());
	}

	IEnumerator GetTexture() {
		while (true) {
			UnityWebRequest WWW = UnityWebRequest.GetTexture (ImagePath);
			yield return www.Send ();

			if (www.isError) {
				Debug.Log (www.error);
			} else {
				Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
				this.GetComponent <MeshRenderer> ().sharedMaterial.SetTexture ("_MainTex", myTexture);
			}
		}
	}
}
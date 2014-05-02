using UnityEngine;
using System.Collections;

public class startup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.skin.button.fontSize = 20;
		if (GUI.Button (new Rect (100, 100, 100, 50), "START")) {
			Debug.Log ("hello");
			Application.LoadLevel (1);
		}
	}
}

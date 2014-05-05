using UnityEngine;
using System.Collections;

public class death_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.skin.label.fontSize = 50;
		GUI.Label (new Rect (Screen.width/2 -152, 0, 304, 100), "GAME OVER");
		GUI.skin.label.fontSize = 25;
		GUI.Label (new Rect (Screen.width/2 - 135, 60, 270, 100), "This is how we get ants.");

	}
}
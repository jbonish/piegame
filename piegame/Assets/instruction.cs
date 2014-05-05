using UnityEngine;
using System.Collections;

public class instruction : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.color = Color.black;
		GUI.skin.label.fontSize = 40;
		GUI.Label (new Rect (350, 180, 500, 100), "Swipe the Flies");
		GUI.Label (new Rect (350, 400, 500, 100), "Hit the Mice");
		
	}
}

using UnityEngine;
using System.Collections;

public class scorekeeper : MonoBehaviour {
	private float current_time;
	private float start_time;
	private int font_size = 30;
	private string last_state;
	private string timeText;

	// Use this for initialization
	void Start () {
		start_time = Time.time;
		DontDestroyOnLoad (this.gameObject);
		last_state = "game_over";
	}
	
	// Update is called once per frame
	void Update () {
		/*string current_state = Application.loadedLevelName;
		if (current_state == "game" && last_state == "start") {
			start_time = 0;
			last_state = current_state;
		} else if (last_state != current_state) {
			last_state = current_state;
		}
*/
	}

	void OnGUI() {
		if (Application.loadedLevelName == "game") {
			current_time = Time.time - start_time;
			GUI.color = Color.black;
			GUI.skin.label.fontSize = font_size;
			System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(current_time);
			string timeText = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
			GUI.Label (new Rect (Screen.width-200, 0, 200, 100), timeText);
			
		} else if ( Application.loadedLevelName == "game_over") {
			GUI.color = Color.white;
			System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(current_time);
			timeText = string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
			Debug.Log (timeText);
			GUI.Label (new Rect (Screen.width/2 -150, 170, 300, 100), "You protected the pie for");
			GUI.Label (new Rect (Screen.width/2 -50, 200, 100, 100), timeText);
	
			GUI.skin.button.fontSize = 15;
			if (GUI.Button (new Rect (Screen.width/2 -100, Screen.height - 100, 200, 40), "RETURN TO MENU")) {
				Debug.Log ("button press");
				start_time = Time.time;
				Destroy (this.gameObject);
				Application.LoadLevel (0);
			}

		} else if ( Application.loadedLevelName == "start") {
			GUI.skin.button.fontSize = 40;
			if (GUI.Button (new Rect (Screen.width/2-100, Screen.height-200, 200, 100), "START")) {
				start_time = Time.time;
				Application.LoadLevel (1);
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class ant_controller : MonoBehaviour {
	public float turn_speed;
	private float start_time;
	public int font_size = 20;
	public Color color;
	public Font font;

	// Use this for initialization
	void Start () {
		turn_speed = 5;
		start_time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 mouse_pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		float targetAngle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
		transform.rotation = 
			Quaternion.Slerp( transform.rotation, 
			                 Quaternion.Euler( 0, 0, targetAngle +90), 
			                 turn_speed * Time.deltaTime );
	}

	void OnGUI() {
		float t = Time.time - start_time;
		GUI.color = color;
		GUI.skin.label.fontSize = font_size;
		GUI.Label (new Rect (350, 0, 100, 100), t.ToString ("F2"));
	}
}

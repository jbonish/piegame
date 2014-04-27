using UnityEngine;
using System.Collections;

public class ant_controller : MonoBehaviour {
	public float turn_speed;

	// Use this for initialization
	void Start () {
		turn_speed = 5;
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
}

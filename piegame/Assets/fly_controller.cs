using UnityEngine;
using System.Collections;

public class fly_controller : MonoBehaviour {
	public float move_speed;
	private Vector3 move_dir;
	public Vector3 move_toward;
	
	// Use this for initialization
	void Start () {
		move_toward.x = 0;
		move_toward.y = 0;
		move_toward.z = 0;
	
		// make 
		Vector3 current_pos = transform.position;
		if (current_pos.x > 0) {
			Vector3 old_scale = transform.localScale;
			Vector3 new_scale =  new Vector3(old_scale.x, -1, old_scale.z);
			transform.localScale = new_scale;
		}				
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 current_pos = transform.position;

		// set direction of movement (unit vector)
		move_dir = move_toward - current_pos;
		move_dir.z = 0;
		move_dir.Normalize ();


		// new spot to draw the image?
		Vector3 target = move_dir * move_speed + current_pos;
		transform.position = Vector3.Lerp (current_pos, target, Time.deltaTime);
	
		// rotates fly so it faces center
		float targetAngle = Mathf.Atan2(move_dir.y, move_dir.x) * Mathf.Rad2Deg;
		transform.rotation = 
			Quaternion.Slerp( transform.rotation, 
			                 Quaternion.Euler( 0, 0, targetAngle ), 
			                 10 * Time.deltaTime );
		
	}

	void OnMouseDown() {
		Destroy (this.gameObject);
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.name == "pie_prefab"){
			Debug.Log ("hit pie");
		}
	}

}


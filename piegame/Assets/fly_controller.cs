﻿using UnityEngine;
using System.Collections;

public class fly_controller : MonoBehaviour {
	public float move_speed;
	private Vector3 move_dir;
	public Vector3 move_toward;
	private bool on_pie = false;
	public int fuse_length;  // number of iterations while touching pie before BANG
	private int current_fuse;
	private GameObject pie;
	public float damage = .9f;  //  reduces size to damage * old size

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
		
		if (on_pie == true) {
			if (current_fuse >= fuse_length) {
				Debug.Log ("BANG");
				Destroy (this.gameObject);

				Vector3 temp = pie.transform.localScale;
				temp.x *= damage;
				temp.y *= damage;
				pie.transform.localScale = temp;
			}
			current_fuse += 1;
		}
	
	}

	void OnMouseDown() {
		Destroy (this.gameObject);
		Debug.Log ("boom");
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "pie_prefab") {
			pie = col.gameObject;
			Debug.Log ("fly hit pie");
			on_pie = true;
			current_fuse = 0;
		}

	}

}


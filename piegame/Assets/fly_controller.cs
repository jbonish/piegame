using UnityEngine;
using System.Collections;

public class fly_controller : MonoBehaviour {
	public float move_speed;
	private Vector3 move_dir;
	public Vector3 move_toward;
	private bool on_pie = false;
	private int fuse_length = 50;  // number of iterations while touching pie before BANG
	private int current_fuse;
	private GameObject pie;
	public float damage = 0.9f;  
	public GameObject explosion;
	public GameObject swat;

	private bool moved = false;
	private bool tapped = false;
	private bool to_explode = false;

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
		if (on_pie == true) {
			if (current_fuse >= fuse_length) {
				to_explode = true;
			}
			current_fuse += 1;
		} else {
			current_fuse = 0;
		} 

		for (int i = 0; i < Input.touchCount; i++) {
			if (Input.GetTouch (i).phase == TouchPhase.Began) {
				moved = false;
			} else if (Input.GetTouch (i).phase == TouchPhase.Moved) {
				moved = true;
			} else if (Input.GetTouch (i).phase == TouchPhase.Ended) {
				if (moved == true && tapped == true) {
					GameObject swt = (GameObject)Instantiate (swat, transform.position, transform.rotation);
					Destroy (swt, 0.2f);
					Destroy (this.gameObject);
				} else if (tapped == true && moved == false) {
					to_explode = true;
					GetComponent<SpriteRenderer>().color = Color.red;
					move_speed = 3;
				}
				tapped = false;
			}
		}

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



		if (to_explode == true) {
			explode ();
		}
	}

	void explode() {
		Vector3 temp = pie.transform.localScale;
		temp.x *= damage;
		temp.y *= damage;
		pie.transform.localScale = temp;
		
		GameObject exp = (GameObject)Instantiate (explosion, transform.position, transform.rotation);
		Destroy (exp, 1.333f);
		Destroy (this.gameObject);
		to_explode = false;
	}

	void OnMouseDown() {
		tapped = true;
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "pie_prefab") {
			pie = col.gameObject;
			on_pie = true;
		}
	}

}


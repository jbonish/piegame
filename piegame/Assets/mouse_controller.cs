using UnityEngine;
using System.Collections;

public class mouse_controller : MonoBehaviour {
	public float move_speed;
	private Vector3 move_dir;
	public Vector3 move_toward;
	private GameObject pie;
	private float damage = .999f;
	private bool on_pie = false;
	public GameObject squeak;

	private bool moved;
	private bool tapped;
	
	// Use this for initialization
	void Start () {
		move_toward.x = 0;
		move_toward.y = 0;
		move_toward.z = 0;
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < Input.touchCount; i++) {
			if (Input.GetTouch (i).phase == TouchPhase.Began) {
				moved = false;
			} else if (Input.GetTouch (i).phase == TouchPhase.Moved) {
				moved = true;
			} else if (Input.GetTouch (i).phase == TouchPhase.Ended) {
				if (moved == true && tapped == true) {
					GetComponent<SpriteRenderer>().color = Color.red;
					move_speed = 2;
					damage = .9994f;
				} else if (tapped == true && moved == false) {
					GameObject swt = (GameObject)Instantiate (squeak, transform.position, transform.rotation);
					Destroy (swt, 0.5f);
					Destroy (this.gameObject);
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
			                 Quaternion.Euler( 0, 0, targetAngle + 90 ), 
			                 10 * Time.deltaTime );


		if (on_pie == true) {
			Vector3 temp = pie.transform.localScale;
			temp.x *= damage;
			temp.y *= damage;
			pie.transform.localScale = temp;
		}
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


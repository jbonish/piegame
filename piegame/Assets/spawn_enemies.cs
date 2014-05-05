using UnityEngine;
using System.Collections;

public class spawn_enemies : MonoBehaviour {

	public GameObject[] enemies;
	public float delay = 0f;
	public float rate = 5f;
	private float start_time;	
	private float last_time;

	// Use this for initialization
	void Start () {
		//InvokeRepeating ("spawn_enemy", delay, rate);
		start_time = Time.time;
	}

	void Update() {
		float current_time = (Time.time - start_time);
		rate = 3 - current_time/60;
		if (rate <= .3) {
			rate = .3f;
		}		
		if ((current_time - last_time) >= rate) {
			spawn_enemy ();
			last_time = current_time;
		}
	}

	Vector3 rand_location () {
		int x = 0;
		int y = 0;
		int side = Random.Range (0, 4);

		if (side == 0) {
			x = -8;
			y = Random.Range (-5, 5);
		}
		if (side == 1) {
			y = 5;
			x = Random.Range (-8, 8);
		}
		if (side == 2) {
			x = 8;
			y = Random.Range (-5, 5);
		}
		if (side == 3) {
			y = -5;
			x = Random.Range (-8, 8);
		}

		Vector3 pos = new Vector3 (x, y, 0);
		return pos;
	}	

	void spawn_enemy() {	
		transform.position = rand_location ();
		int ind = Random.Range (0, enemies.Length);
		Instantiate( enemies[ind], transform.position, transform.rotation);

	}
}
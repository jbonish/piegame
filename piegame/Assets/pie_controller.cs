using UnityEngine;
using System.Collections;

public class pie_controller : MonoBehaviour {
	public float death = .25f;
	private float start_time;
	private float current_time;
	public Color color;
	private int font_size = 30;

	// Use this for initialization
	void Start () {
		start_time = Time.time;
	//	DontDestroyOnLoad (this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localScale.x <= death) {
			Application.LoadLevel (2);
		}
	
	}
}

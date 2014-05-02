using UnityEngine;
using System.Collections;

public class pie_controller : MonoBehaviour {
	public float death = .25f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localScale.x <= death) {
			Application.LoadLevel (2);
		}
	}
}

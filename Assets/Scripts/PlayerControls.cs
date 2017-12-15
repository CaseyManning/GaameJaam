using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour {
	public Rigidbody2D rb;
	public float Speed = 10.0f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Movement ();
	}

	void Movement () {
		float Horizontal = Input.GetAxis ("Horizontal");
		float Vertical = Input.GetAxis ("Vertical");
		rb.velocity = new Vector2 (Horizontal * Speed, Vertical * Speed);
	}

	void Update() {

	}
}

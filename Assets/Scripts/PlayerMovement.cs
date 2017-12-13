using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public Rigidbody2D rb;
	public float Speed = 10.0f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.velocity = new Vector2 (Input.GetAxis("Horizontal") * Speed, Input.GetAxis("Vertical") * Speed);
	}
}

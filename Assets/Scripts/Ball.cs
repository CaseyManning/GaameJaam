using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Ball : MonoBehaviour {
	public Rigidbody2D rb;
	public float Speed = 1.0f;
	public float LifeSpan = 0.5f;
	private String OwnerName;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		Destroy (this.gameObject, LifeSpan);

	}

	void FixedUpdate () {
		float Dir = transform.localEulerAngles.z;
		float XDir = Mathf.Cos (Dir * Mathf.Deg2Rad);
		float YDir = Mathf.Sin (Dir * Mathf.Deg2Rad);
		rb.velocity = new Vector2 (XDir, YDir) * Speed;
	}
}
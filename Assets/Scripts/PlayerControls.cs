using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
	public Rigidbody2D rb;
	public float Speed = 10.0f;
	private Vector3 PlayerRotation;
	public GameObject Prefab;
	public static GameObject BallPrefab;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		BallPrefab = Prefab;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float Horizontal = Input.GetAxis ("Horizontal");
		float Vertical = Input.GetAxis ("Vertical");

		Movement (Horizontal, Vertical);
		if (Input.GetKeyDown("space")) ThrowBall (this.transform.position, this.transform.rotation); 
	}

	void Movement (float Horizontal, float Vertical) {
		//move the player
		rb.velocity = new Vector2 (Horizontal * Speed, Vertical * Speed);

		//change rotation of player
		if (Horizontal > 0) {
			PlayerRotation.z = 0.0f;
		} else if (Horizontal < 0) {
			PlayerRotation.z = 180.0f;
		}
		if (Vertical > 0) {
			PlayerRotation.z = 90.0f;
		} else if (Vertical < 0) {
			PlayerRotation.z = -90.0f;
		}
		this.transform.eulerAngles = PlayerRotation;
	}

	public static void ThrowBall (Vector3 Position, Quaternion Rotation) {
		Instantiate (BallPrefab, Position, Rotation);
	}


}
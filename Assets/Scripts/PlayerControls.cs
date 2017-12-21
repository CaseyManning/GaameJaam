using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour {
	public Rigidbody2D rb;
	public float Speed = 10.0f;
	public int levelNum = 1;
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

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.name == "Diamond")
		{
			levelNum++;
			Destroy (col.gameObject);
			//if (levelNum == 2 && SceneManager.GetActiveScene().name=="GameScene") {
				SceneManager.LoadScene ("Level2");
			//}
		}
	}	
}

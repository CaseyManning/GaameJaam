using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearch : Enemy {
	//Make sure their is a rigidbody2d on enemy to ensure collisions.
	//If you get an error, it may because there is a sphere collider instead of circle collider on the enemy.
	public float moveFrequency = 0.5f; //in seconds
	bool searching = false;
	Vector3 startPos;
	Vector3 target;

	void Start () {
		StartSearch ();
	}

	void Update () {
		if (searching == true && transform.position != target) {
			moveTowards (target, speed);
		}
	}

	public void StartSearch () {
		startPos = transform.position;
		searching = true;
		StartCoroutine(SearchUpdate ());
	}

	public void EndSearch () {
		searching = false;
	}
		
	public IEnumerator SearchUpdate () {
		print (searching);
		while (searching == true) {
			int dir = UnityEngine.Random.Range (0, 360);
			yield return new WaitForSeconds (moveFrequency);
			target = new Vector3 ((Mathf.Cos (Mathf.Deg2Rad * dir) * speed / 10) + transform.position.x,
				(Mathf.Sin (Mathf.Deg2Rad * dir) * speed / 10) + transform.position.y, 0.0f);
		}
	}
}

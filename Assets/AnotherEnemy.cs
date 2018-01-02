using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherEnemy : Enemy {

	// Use this for initialization
	void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();

		if (state == "idle") {

		}

		if (state == "attacking") {
			moveTowards(GameObject.FindGameObjectWithTag ("Player").transform.position, speed);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : Enemy {

	// Use this for initialization
	void Start () {
		base.Start ();
		visionAngle = 40;
	}
	
	// Update is called once per frame
	void Update () {
		base.Update ();


		if (state == "attacking") {
			moveTowards(GameObject.FindGameObjectWithTag ("Player").transform.position, speed);
		}
	}
}

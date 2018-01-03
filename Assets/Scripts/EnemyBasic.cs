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

		if (state == "alerting") {
			moveTowards (GameObject.Find ("Alert").transform.position, speed);
		} else if (state == "attacking") {
			moveTowards(GameObject.FindGameObjectWithTag ("Player").transform.position, speed);
		}

		if (Vector3.Distance(transform.position, GameObject.Find ("Alert").transform.position) < 3.5f && state == "alerting") {
			Alert.alerted = true;
			state = "idle";
			print ("Alert: " + Alert.alerted);
		}
//		print(Vector3.Distance(transform.position, GameObject.Find ("Alert").transform.position));
	}
}

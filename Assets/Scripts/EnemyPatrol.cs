using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : Enemy {


	Vector3[] waypoints = new Vector3[2];

	int currentWaypoint = 1; //the index in waypoints that the unit is currently moving to

	// Use this for initialization
	void Start () {
		waypoints [0] = transform.position;
		waypoints [1] = new Vector3 (10, 10, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (state == "idle") {
			goToNextWaypoint();
		}
	}

	void goToNextWaypoint() {
		print (currentWaypoint);
		if(transform.position == waypoints[1]) {
			currentWaypoint++;
			if (currentWaypoint > waypoints.Length - 1) {
				currentWaypoint = 1;
			}
		}
		moveTowards(waypoints[currentWaypoint]);
	}
}

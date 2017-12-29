using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : Enemy {


	public Vector3[] waypoints = new Vector3[2];

	int currentWaypoint = 1; //the index in waypoints that the unit is currently moving to
	int patrolSpeed = 4;

	// Use this for initialization
	void Start () {


		waypoints [0] = transform.position;
		//waypoints [1] = new Vector3 (13.5f, 11.5f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (state == "idle") {
			goToNextWaypoint();
		}
		if (state == "attacking") {
			moveTowards(GameObject.FindGameObjectWithTag ("Player").transform.position, speed);
		}
	}

	void goToNextWaypoint() {
		print (currentWaypoint);
		if(Vector3.Distance(transform.position, waypoints[currentWaypoint]) < 0.1) {
			currentWaypoint++;
			if (currentWaypoint > waypoints.Length - 1) {
				currentWaypoint = 0;
			}
		}
		moveTowards(waypoints[currentWaypoint], patrolSpeed);
	}
}

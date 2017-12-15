using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	float attackRange = 8f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (CanSeeTarget()) {
			print ("I can see the player?");
		}
	}

//	bool CanSeePlayer() {
//		GameObject player = GameObject.FindGameObjectWithTag ("Player");
//		Vector3 playerPos = player.transform.position;
//		float distanceToPlayer = Vector3.Distance (playerPos, transform.position);
//
//		//RaycastHit hit;
//
//
//		Vector3 rayDirection = transform.TransformDirection (Vector3.forward);
//
//
//		if(Physics.Raycast (transform.position, rayDirection)) { // If the player is very close behind the player and in view the enemy will detect the player
//				print ("harrumph!");
//				return true;
//		}
//		//print (hit.transform.tag);
//		return false;
//	}

	bool CanSeeTarget () {

		Transform target = GameObject.FindGameObjectWithTag ("Player").transform;

		if (Vector3.Distance(transform.position, target.position) > attackRange) {
			print("Target out-of-range");
			return false;          
		}



		Vector2 targetPosition = new Vector2 (target.position.x, target.position.y);
		Vector2 myPosition = new Vector2 (transform.position.x, transform.position.y);

		RaycastHit2D hit = Physics2D.Raycast (myPosition, targetPosition-myPosition, attackRange);

		if (Physics2D.Raycast (myPosition, targetPosition-myPosition, attackRange)) {
			if (hit.transform.position == target.position) {
				print("Target Acquired");
			} else {
				print("Lost line-of-sight");
			}
			return hit.transform.position == target.position;
		}
		return false;
	}

}

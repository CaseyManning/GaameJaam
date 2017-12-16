using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

	public float attackRange = 8f;

	public int visionAngle = 90; //can see 90 to each side of the direction it is facing

	public string state = "idle";

	public int speed = 10;

	// Use this for initialization
	public void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {

		if(Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 0.2) {
			SceneManager.LoadScene("GameOver");
		}

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

	public bool CanSeeTarget () {

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

				Vector3 dir = GameObject.FindGameObjectWithTag ("Player").transform.position - transform.position;
				float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;

				//print (angle - transform.eulerAngles.z);

				if (Mathf.Abs (angle - transform.eulerAngles.z) < visionAngle || Mathf.Abs (angle - transform.eulerAngles.z) > 360 - visionAngle) {
					print("Target Acquired");
					state = "attacking";
				}
			} else {
				if (state == "attacking") {
					print("Lost line of sight");
					state = "idle";
				}
			}
			return hit.transform.position == target.position;
		}
		return false;
	}

	public void moveTowards(Vector3 target) {
		Vector3 dir = target - transform.position;
		float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
		transform.eulerAngles = new Vector3(0, 0, angle);
		Vector3 playerPosition = target;
		transform.position = Vector2.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
	}
}

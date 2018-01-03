using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherEnemy : Enemy {
	
	// Update is called once per frame
	void Update () {
		base.Update ();

		if (state == EnemyState.idle) {

		}

		if (state == EnemyState.attacking) {
			moveTowards(GameObject.FindGameObjectWithTag ("Player").transform.position, speed);
		}
	}
}

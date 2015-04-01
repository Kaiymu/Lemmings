using UnityEngine;
using System.Collections;

public class PoisonArea : CollisionManager {

	protected override void EnterLPoisonCollision (GameObject Lemmings) {
		Destroy(gameObject);
	}
}

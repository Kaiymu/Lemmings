using UnityEngine;
using System.Collections;

public class CollisionPoison : CollisionManager {

	protected override void EnterLPoisonCollision (GameObject Lemmings) {
		Debug.Log ("toto");
	}
}

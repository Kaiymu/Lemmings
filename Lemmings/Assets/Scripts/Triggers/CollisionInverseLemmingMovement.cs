using UnityEngine;
using System.Collections;

public class CollisionInverseLemmingMovement : CollisionManager {

	protected override void EnterLAllCollision(GameObject lemmings) {

		float move = lemmings.GetComponent<Lemmings>().moveSpeed;
		lemmings.GetComponent<Lemmings>().moveSpeed = -move;
        lemmings.GetComponent<Lemmings>().Flip();
	}
}

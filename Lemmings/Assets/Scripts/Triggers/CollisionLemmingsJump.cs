using UnityEngine;
using System.Collections;

public class CollisionLemmingsJump : CollisionManager {
	
	public float jumpSpeed;
	protected override void EnterLAllCollision(GameObject lemmings) {
		Lemmings _lemmings = lemmings.GetComponent<Lemmings>();

		_lemmings.jumpSpeed = jumpSpeed;
		_lemmings.fsm.ChangeState(BounceState.Instance);
    }
}
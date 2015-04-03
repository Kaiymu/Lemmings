using UnityEngine;
using System.Collections;

public class CollisionInverseLemmingMovement : CollisionManager {

	private void Start() {
		_animatorTrigger = GetComponent<Animator>();
	}

	protected override void EnterLAllCollision(GameObject lemmings) {

		float move = lemmings.GetComponent<Lemmings>().moveSpeed;
		lemmings.GetComponent<Lemmings>().moveSpeed = -move;
        lemmings.GetComponent<Lemmings>().Flip();

        if(_animatorTrigger != null)
		     _animatorTrigger.SetInteger("TriggerAnimation", 1);
	}
}

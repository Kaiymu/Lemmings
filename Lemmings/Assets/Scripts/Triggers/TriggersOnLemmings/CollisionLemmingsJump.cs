using UnityEngine;
using System.Collections;

public class CollisionLemmingsJump : CollisionManager {

    private void Start() {
        _animatorTrigger = GetComponent<Animator>();
    }
	
	public float jumpHeight;
    public float jumpSpeed;
	protected override void EnterLAllCollision(GameObject lemmings) {
		Lemmings _lemmings = lemmings.GetComponent<Lemmings>();

        _lemmings.jumpHeight = jumpHeight;
		_lemmings.jumpSpeed = jumpSpeed;
		_lemmings.fsm.ChangeState(BounceState.Instance);
        _animatorTrigger.SetInteger("TriggerAnimation", 1);
    }

    protected override void ExitLAllCollision(GameObject lemmings) {
        _animatorTrigger.SetInteger("TriggerAnimation", 0);
    }
}
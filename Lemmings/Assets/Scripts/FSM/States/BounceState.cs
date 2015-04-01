using UnityEngine;
using System.Collections;

public class BounceState : FSMState<Lemmings> {
	
	private static readonly BounceState instance = new BounceState();
	
	public static BounceState Instance
	{
		get { return instance; }
	}
	
	// Appelée une fois au changement de state
	public override void Begin (Lemmings o, FSM<Lemmings> fsm) {
		o.m_rigidbody2D.velocity = new Vector2(o.jumpSpeed, o.jumpHeight);
		fsm.ChangeState(MovingState.Instance);
	}
	
	// Appelée comme un update
	public override void Execute(Lemmings o, FSM<Lemmings> fsm) {
	}
	
	// Utilosée pour effectuer la transition chaque seconde, appelée comme un update
	public override void Transition(Lemmings o, FSM<Lemmings> fsm) {
	}
	
	// Appelée une fois lorsque la state est quitée
	public override void End(Lemmings o, FSM<Lemmings> fsm) {
		
	}
}

using UnityEngine;
using System.Collections;

public class PauseState : FSMState<Lemmings> {

    private static readonly PauseState instance = new PauseState();

    private float speedAnimation;
    public static PauseState Instance
    {
        get { return instance; }
    }

    public override void Begin(Lemmings o, FSM<Lemmings> fsm)
    {
        //o.animatorLemmings.SetInteger("Lemmings", 0);
        speedAnimation = o.animatorLemmings.speed;
        o.animatorLemmings.speed = 0f;
    }

	public override void Execute(Lemmings o, FSM<Lemmings> fsm) {

    }

	public override void Transition(Lemmings o, FSM<Lemmings> fsm)
    {
        o.animatorLemmings.speed = speedAnimation;
    }
}

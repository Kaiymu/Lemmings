using UnityEngine;
using System.Collections;

public class PauseState : FSMState<Lemmings> {

    private static readonly PauseState instance = new PauseState();

    public static PauseState Instance
    {
        get { return instance; }
    }

    public override void Begin(Lemmings o, FSM<Lemmings> fsm)
    {
        //o.animatorLemmings.SetInteger("Lemmings", 0);
        o.animatorLemmings.enabled = false;
    }

	public override void Execute(Lemmings o, FSM<Lemmings> fsm) {

    }

	public override void Transition(Lemmings o, FSM<Lemmings> fsm)
    {
        o.animatorLemmings.enabled = true;
    }
}

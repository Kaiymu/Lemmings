using UnityEngine;
using System.Collections;

public class EmptyState : FSMState<Lemmings> {

    private static readonly EmptyState instance = new EmptyState();

    public static EmptyState Instance
    {
        get { return instance; }
    }

	public override void Execute(Lemmings o, FSM<Lemmings> fsm)
    {
        o.bag -= o.emptySpeed * Time.deltaTime;
        o.home.GetComponent<Home>().Minerals += o.emptySpeed * Time.deltaTime;
    }

	public override void Transition(Lemmings o, FSM<Lemmings> fsm)
    {
        if (o.bag <= 0)
        {
            o.bag = 0;
            fsm.ChangeState(EmptyState.Instance);
            o.rendererLemmings.material.color = Color.green;
        }
    }
}

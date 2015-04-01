﻿using UnityEngine;
using System.Collections;

public class PauseState : FSMState<Lemmings> {

    private static readonly PauseState instance = new PauseState();

    private float speedAnimation;
    private float gravityScale;
    public static PauseState Instance
    {
        get { return instance; }
    }

    public override void Begin(Lemmings o, FSM<Lemmings> fsm)
    {
        speedAnimation = o.animatorLemmings.speed;
        gravityScale = o.m_rigidbody2D.gravityScale;

        o.animatorLemmings.speed = 0f;
        o.m_rigidbody2D.gravityScale = 0f;
    }

	public override void Execute(Lemmings o, FSM<Lemmings> fsm) {

    }

	public override void Transition(Lemmings o, FSM<Lemmings> fsm)
    {
        o.animatorLemmings.speed = speedAnimation;
    }

    public override void End(Lemmings o, FSM<Lemmings> fsm) {
        o.animatorLemmings.speed = speedAnimation;
        o.m_rigidbody2D.gravityScale = gravityScale;
    }
}

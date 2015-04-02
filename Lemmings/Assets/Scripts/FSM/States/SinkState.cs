using UnityEngine;
using System.Collections;

public class SinkState : FSMState<Lemmings> {
    
    private static readonly SinkState instance = new SinkState();

    private Vector2 velocityPlayer;
    private float gravityScale;
    public static SinkState Instance
    {
        get { return instance; }
    }
    
    public override void Begin(Lemmings o, FSM<Lemmings> fsm)
    {
        o.m_rigidbody2D.gravityScale = 0f;
        o.m_rigidbody2D.velocity = Vector2.zero;
        o.animatorLemmings.SetInteger("Lemmings", 5);
    }
    
    public override void Execute(Lemmings o, FSM<Lemmings> fsm) {
        
    }
    
    public override void Transition(Lemmings o, FSM<Lemmings> fsm) {
        
    }
    
    public override void End(Lemmings o, FSM<Lemmings> fsm) {
    }
}

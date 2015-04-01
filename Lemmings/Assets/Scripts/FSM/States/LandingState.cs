using UnityEngine;
using System.Collections;

public class LandingState : FSMState<Lemmings> {
    
    private static readonly LandingState instance = new LandingState();
    
    public static LandingState Instance
    {
        get { return instance; }
    }
    
    // Appelée une fois au changement de state
    public override void Begin (Lemmings o, FSM<Lemmings> fsm) {
        o.animatorLemmings.SetInteger("Lemmings", 3);
    }
    
    // Appelée comme un update
    public override void Execute(Lemmings o, FSM<Lemmings> fsm) {
    }

    public override void Transition(Lemmings o, FSM<Lemmings> fsm) {
        if(o.IsFalling())
            fsm.ChangeState(MovingState.Instance);
    }
    
    // Appelée une fois lorsque la state est quitée
    public override void End(Lemmings o, FSM<Lemmings> fsm) {
        
    }
}

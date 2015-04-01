using UnityEngine;
using System.Collections;

public class DeadFallState : FSMState<Lemmings> {
    
    private static readonly DeadFallState instance = new DeadFallState();
    
    public static DeadFallState Instance
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
    
    // Utilosée pour effectuer la transition chaque seconde, appelée comme un update
    public override void Transition(Lemmings o, FSM<Lemmings> fsm) {
        if(!o.IsFalling() && o.IsOnGround())
            fsm.ChangeState(MovingState.Instance);
    }
    
    // Appelée une fois lorsque la state est quitée
    public override void End(Lemmings o, FSM<Lemmings> fsm) {
        
    }
}

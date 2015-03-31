using UnityEngine;
using System.Collections;

public class StoneState : FSMState<Lemmings> {
    
    private static readonly StoneState instance = new StoneState();
    
    public static StoneState Instance
    {
        get { return instance; }
    }
    
    // Appelée une fois au changement de state
    public override void Begin (Lemmings o, FSM<Lemmings> fsm) {
        
    }
    
    // Appelée comme un update
    public override void Execute(Lemmings o, FSM<Lemmings> fsm) {
        // si je suis touché par la souris je meurs ici.
    }
    
    // Utilosée pour effectuer la transition chaque seconde, appelée comme un update
    public override void Transition(Lemmings o, FSM<Lemmings> fsm) {
    }
    
    // Appelée une fois lorsque la state est quitée
    public override void End(Lemmings o, FSM<Lemmings> fsm) {
        
    }
}

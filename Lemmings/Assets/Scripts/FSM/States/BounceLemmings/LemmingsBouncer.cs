using UnityEngine;
using System.Collections;

public class LemmingsBouncer : FSMState<Lemmings> {
    
    private static readonly LemmingsBouncer instance = new LemmingsBouncer();
    
    public static LemmingsBouncer Instance
    {
        get { return instance; }
    }
    
    // Appelée une fois au changement de state
    public override void Begin (Lemmings o, FSM<Lemmings> fsm) {
        if(o.m_Lemming.GetComponent<CollisionLemmingsJump>() == null) {

        }
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

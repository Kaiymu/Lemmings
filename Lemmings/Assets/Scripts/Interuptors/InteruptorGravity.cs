using UnityEngine;
using System.Collections;

public class InteruptorGravity : InteruptorArea {

    protected override void EnterLGravityCollision(GameObject Lemmings){
        base.PlatformToActivate();
    }
}

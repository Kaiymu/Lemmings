using UnityEngine;
using System.Collections;

public class InteruptorStone : InteruptorArea {

    protected override void EnterLStoneCollision(GameObject Lemmings){
        base.PlatformToActivate();
    }
}

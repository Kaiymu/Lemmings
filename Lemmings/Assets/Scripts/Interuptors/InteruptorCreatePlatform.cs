using UnityEngine;
using System.Collections;

public class InteruptorCreatePlatform : InteruptorArea {

    protected override void EnterLPlatformCollision(GameObject Lemmings){
        base.PlatformToActivate();
    }
}

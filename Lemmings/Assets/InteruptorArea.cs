using UnityEngine;
using System.Collections;

public class InteruptorArea : CollisionManager {

    public Transform _platformToActivate;

    protected override void EnterLGravityCollision(GameObject Lemmings){
        Debug.Log("toto");
    }
}

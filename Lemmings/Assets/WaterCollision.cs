using UnityEngine;
using System.Collections;

public class WaterCollision : CollisionManager {

	protected override void EnterLAllCollision(GameObject Lemmings) {
        Lemmings.GetComponent<Animator>().SetInteger("Lemmings", 5);

    }
}

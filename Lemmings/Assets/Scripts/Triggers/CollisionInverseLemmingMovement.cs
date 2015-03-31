using UnityEngine;
using System.Collections;

public class CollisionInverseLemmingMovement : CollisionManager {

	protected override void EnterLAllCollision(GameObject lemmings) {
		float move = lemmings.GetComponent<Lemmings>().moveSpeed;
		lemmings.GetComponent<Lemmings>().moveSpeed = -move;

       // if( -move < 0)

       // else 
        if(lemmings.GetComponent<Animator>() != null)
            lemmings.GetComponent<Animator>().SetInteger("Lemmings", 1);

	}
}

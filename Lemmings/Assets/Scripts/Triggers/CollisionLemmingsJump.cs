using UnityEngine;
using System.Collections;

public class CollisionLemmingsJump : CollisionManager {

    protected override void LemmingsCollision(GameObject lemmings)
    {

    }

    protected override void LemmingsJumpCollision(GameObject lemmings)
    {
        float move = lemmings.GetComponent<Lemmings>().moveSpeed;
        lemmings.GetComponent<Lemmings>().moveSpeed = -move;
    }
}
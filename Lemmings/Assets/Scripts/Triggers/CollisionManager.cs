using UnityEngine;
using System.Collections;

public abstract class CollisionManager : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
    {
         if(collider.gameObject.tag == "Player") {
            if(collider.gameObject.GetComponent<Lemmings>().enumLemmings == EnumLemmings.LEMMINGS)
                LemmingsJumpCollision(collider.gameObject);
        }
    }

    protected abstract void LemmingsCollision(GameObject Lemmings);
    protected abstract void LemmingsJumpCollision(GameObject Lemmings);
}

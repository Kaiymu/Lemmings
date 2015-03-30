using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class CollisionManager : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
    {
         if(collider.gameObject.tag == "Lemming") {

			EnterLAllCollision(collider.gameObject);

            if(collider.gameObject.GetComponent<Lemmings>().enumLemmings == EnumLemmings.NEUTRAL)
				EnterLNeutralCollision(collider.gameObject);

			if(collider.gameObject.GetComponent<Lemmings>().enumLemmings == EnumLemmings.BOUNCE)
				EnterLGravityCollision(collider.gameObject);

			if(collider.gameObject.GetComponent<Lemmings>().enumLemmings == EnumLemmings.GRAVITY)
				EnterLGravityCollision(collider.gameObject);

			if(collider.gameObject.GetComponent<Lemmings>().enumLemmings == EnumLemmings.STONE)
				EnterLStoneCollision(collider.gameObject);

			if(collider.gameObject.GetComponent<Lemmings>().enumLemmings == EnumLemmings.PLATFORM)
				EnterLPlatformCollision(collider.gameObject);

			if(collider.gameObject.GetComponent<Lemmings>().enumLemmings == EnumLemmings.POISON)
				EnterLPoisonCollision(collider.gameObject);

			if(collider.gameObject.GetComponent<Lemmings>().enumLemmings == EnumLemmings.LOVE)
				EnterLLoveCollision(collider.gameObject);
        }
    }
	
	protected virtual void EnterLAllCollision(GameObject Lemmings){}
	protected virtual void EnterLNeutralCollision(GameObject Lemmings){}
	protected virtual void EnterLGravityCollision(GameObject Lemmings){}
	protected virtual void EnterLStoneCollision(GameObject Lemmings){}
	protected virtual void EnterLPlatformCollision(GameObject Lemmings){}
	protected virtual void EnterLPoisonCollision(GameObject Lemmings){}
	protected virtual void EnterLLoveCollision(GameObject Lemmings){}
}

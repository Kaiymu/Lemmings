using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class CollisionManager : MonoBehaviour {

	protected Animator _animatorTrigger;

	void OnTriggerEnter2D(Collider2D collider)
    {
         if(collider.gameObject.tag == "Lemming") {

			EnterLAllCollision(collider.gameObject);

            if(collider.gameObject.GetComponent<Lemmings>().enumLemmings == EnumLemmings.NEUTRAL)
				EnterLNeutralCollision(collider.gameObject);

			if(collider.gameObject.GetComponent<Lemmings>().enumLemmings == EnumLemmings.BOUNCE)
                EnterLBouncerCollision(collider.gameObject);

			if(collider.gameObject.GetComponent<Lemmings>().enumLemmings == EnumLemmings.LOVE)
				EnterLLoveCollision(collider.gameObject);
        }

		if(collider.gameObject.tag == "LemmingsTriggers") {
			if(collider.gameObject.GetComponent<LemmingsTriggers>().lemmingsTransformedType == EnumLemmingsTransformed.POISON)
				EnterLPoisonCollision(collider.gameObject);


            if(collider.gameObject.GetComponent<LemmingsTriggers>().lemmingsTransformedType == EnumLemmingsTransformed.GRAVITY) {
                EnterLGravityCollision(collider.gameObject);
            }

            if(collider.gameObject.GetComponent<LemmingsTriggers>().lemmingsTransformedType == EnumLemmingsTransformed.STONE)
                EnterLStoneCollision(collider.gameObject);

            if(collider.gameObject.GetComponent<LemmingsTriggers>().lemmingsTransformedType == EnumLemmingsTransformed.CREATE_PLATFORM)
                EnterLPlatformCollision(collider.gameObject);
		}
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Lemming") {
         
            ExitLAllCollision(collider.gameObject);
        };
    }

	protected virtual void EnterLAllCollision(GameObject Lemmings){}
	protected virtual void EnterLNeutralCollision(GameObject Lemmings){}
    protected virtual void EnterLBouncerCollision(GameObject Lemmings){}
	protected virtual void EnterLGravityCollision(GameObject Lemmings){}
	protected virtual void EnterLStoneCollision(GameObject Lemmings){}
	protected virtual void EnterLPlatformCollision(GameObject Lemmings){}
	protected virtual void EnterLPoisonCollision(GameObject Lemmings){}
	protected virtual void EnterLLoveCollision(GameObject Lemmings){}

    protected virtual void ExitLAllCollision(GameObject Lemmings){}
	
	protected virtual void EndAnimation(int animation) {
		_animatorTrigger.SetInteger("TriggerAnimation", animation);
	}

    protected virtual void DeathAnimation() {
    }
}

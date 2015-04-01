using UnityEngine;
using System.Collections;

public abstract class InteruptorArea : CollisionManager {

    [Header("La plateforme à activé lors de la collision")]
    public GameObject platformToActivate;
    // Activé ici une plateforme qui fais des allez retour entre points A et points B.

    protected override void EnterLGravityCollision(GameObject Lemmings){
        PlatformToActivate();
    }

    protected override void EnterLStoneCollision(GameObject Lemmings){

    }

    protected override void EnterLPlatformCollision(GameObject Lemmings){

    }

    protected void PlatformToActivate() {
        if(platformToActivate != null) {
            platformToActivate.SetActive(true);
            if(platformToActivate.GetComponent<MovingPlatform>() != null) {
                platformToActivate.GetComponent<MovingPlatform>().canMove = true;
            }
        }
    }

}

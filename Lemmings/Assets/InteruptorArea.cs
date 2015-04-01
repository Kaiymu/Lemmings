using UnityEngine;
using System.Collections;

public class InteruptorArea : CollisionManager {

    [Header("La plateforme à activé lors de la collision")]
    public GameObject platformToActivate;
    // Activé ici une plateforme qui fais des allez retour entre points A et points B.

    protected override void EnterLGravityCollision(GameObject Lemmings){
        if(platformToActivate.GetComponent<MovingPlatform>() != null) {
            platformToActivate.GetComponent<MovingPlatform>().canMove = true;
        }
    }

    protected override void EnterLStoneCollision(GameObject Lemmings){
        if(platformToActivate.GetComponent<MovingPlatform>() != null) {
            platformToActivate.GetComponent<MovingPlatform>().canMove = true;
        }
    }

}

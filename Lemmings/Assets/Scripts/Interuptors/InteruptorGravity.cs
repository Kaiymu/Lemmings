using UnityEngine;
using System.Collections;

public class InteruptorGravity : CollisionManager {

    [Header("La plateforme à activé lors de la collision")]
    public GameObject platformToActivate;

    protected override void EnterLGravityCollision(GameObject Lemmings){
        Debug.Log("toto");
        PlatformToActivate();
    }

    protected void PlatformToActivate() {
        Debug.Log("toto");
        if(platformToActivate != null) {
            platformToActivate.SetActive(true);
            if(platformToActivate.GetComponent<MovingPlatform>() != null) {
                platformToActivate.GetComponent<MovingPlatform>().canMove = true;
            }
        }
    }

}

using UnityEngine;
using System.Collections;

public class InteruptorStone : CollisionManager {

    [Header("La plateforme à activé lors de la collision")]
    public GameObject platformToActivate;


    protected override void EnterLStoneCollision(GameObject Lemmings){
        PlatformToActivate();
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

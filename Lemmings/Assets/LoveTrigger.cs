using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoveTrigger : CollisionManager {

    public GameObject hearthAnimation;
    private List<GameObject> listLemmngsInLove = new List<GameObject>();
	protected override void EnterLAllCollision(GameObject Lemmings) {
        listLemmngsInLove.Add(Lemmings);
    }

    // J'instancie les coeurs, et j'enlève la capacités sur tous, et je détruit le lemmings.
    private void FeatureLove() {

    }
}

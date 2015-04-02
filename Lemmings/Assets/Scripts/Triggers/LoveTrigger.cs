using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoveTrigger : CollisionManager {

    public GameObject hearthAnimation;
    private List<GameObject> listLemmingsInLove = new List<GameObject>();
	protected override void EnterLAllCollision(GameObject Lemmings) {
        listLemmingsInLove.Add(Lemmings);
    }

    // J'instancie les coeurs, et j'enlève la capacités sur tous, et je détruit le lemmings.
    protected override void DeathAnimation() {
        Instantiate(hearthAnimation, transform.position, Quaternion.identity);

		for(int i = 0; i < listLemmingsInLove.Count; i++)  {
			listLemmingsInLove[i].GetComponent<Lemmings>().activateLove = true;
		}
        Destroy(gameObject, 0.1f);
    }
}
using UnityEngine;
using System.Collections;


[RequireComponent(typeof(BoxCollider2D))]
public class BloppingSurvivors : CollisionManager {

    public string levelToLoad;
    private int survivorsLemmings = 0;
    protected override void EnterLAllCollision(GameObject Lemmings) {

        survivorsLemmings++;

        LemmingsManager.instance.RemoveLemmings(Lemmings);

        if(LemmingsManager.instance.lemmings.Count == survivorsLemmings) {
            Application.LoadLevel(levelToLoad);
        }
    }
}

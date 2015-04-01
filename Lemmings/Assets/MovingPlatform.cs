using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

    [HideInInspector]
    public bool canMove = false;

    [Header("Tu met ici le plateform to reach mis sur ta scène")]
    public GameObject pointToReach;
    public float speed;

    private  Vector3 target ;
  
	private  void Update () {
        if(canMove) {
            target = pointToReach.transform.position;
            target.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, target, speed  * Time.deltaTime);
        }
	}

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "MovingPlatform") {
            canMove = false;
        }
    }

}

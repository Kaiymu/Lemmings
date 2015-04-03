using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoveTrigger : CollisionManager {

    public GameObject hearthAnimation;
    private int i = 0;

    private Animator _animator;

    private void Start() {
        _animator = GetComponent<Animator>();
    }

	protected override void EnterLAllCollision(GameObject Lemmings) {
       
        _animator.SetInteger("TriggerAnimation", 1);
        Lemmings.GetComponent<Lemmings>().activateLove = true;
        Instantiate(hearthAnimation, transform.position, Quaternion.identity);
        /*i++;
        if(i == 5) {
            i = 0;
            Instantiate(hearthAnimation, transform.position, Quaternion.identity);
        }*/
    }

    protected override void ExitLAllCollision(GameObject Lemmings) {
        _animator.SetInteger("TriggerAnimation", 0);
    }
}
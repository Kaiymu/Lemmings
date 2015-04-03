using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {

    private GameManager _gameManager;
    private LemmingsManager _lemmingsManager;

    private void Awake() {
        SetManager();
    }

    private void SetManager() {
        _gameManager = GameManager.instance;
        _lemmingsManager = LemmingsManager.instance;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Lemming") {
            _gameManager.numberOfLemmingsSaved++;

            _lemmingsManager.RemoveLemming(collider.gameObject, "saved");

            if(_gameManager.allLemmings.Count == 0) {
                _gameManager.state = GameManager.STATE.WIN;
                _gameManager.StateMachine();
            }
        }
           
    }
}

using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {

    private int numberOfLemmingsSaved;

    private GameManager _gameManager;
    private LemmingsManager _lemmingsManager;

    private void Awake() {
        SetManager();
        numberOfLemmingsSaved = 0;
    }

    private void SetManager() {
        _gameManager = GameManager.instance;
        _lemmingsManager = LemmingsManager.instance;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Lemming") {
            numberOfLemmingsSaved++;

            _lemmingsManager.RemoveLemming(collider.gameObject);

            if(_gameManager.allLemmings.Count == 0) {
                Debug.Log("Il n'y a plus de lemmings");
            }
        }
           
    }
}

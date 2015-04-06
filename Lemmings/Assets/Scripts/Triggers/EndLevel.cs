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
            _gameManager.lemmingsSaved++;

            _lemmingsManager.RemoveLemming(collider.gameObject, "saved");

            if(_gameManager.lemmingsSaved >= _gameManager.savedLemmingsToWin) {
                _gameManager.state = GameManager.STATE.WIN;
                _gameManager.StateMachine();
                
                _gameManager.isPaused = true;
                
                for(int i = 0 ; i < _gameManager.allLemmings.Count; i++) {
                    if(_gameManager.allLemmings[i].GetComponent<Lemmings>() != null)
                        _gameManager.allLemmings[i].GetComponent<Lemmings>().fsm.ChangeState(PauseState.Instance);
                }
            }

            if(_gameManager.numberOfLemmingsSaved >= (_gameManager.numberMaxOfLemmings - _gameManager.numberMaxOfLemmingsToLoose)) {
                _gameManager.state = GameManager.STATE.WIN;
                _gameManager.StateMachine();

                _gameManager.isPaused = true;
                
                for(int i = 0 ; i < _gameManager.allLemmings.Count; i++) {
                    if(_gameManager.allLemmings[i].GetComponent<Lemmings>() != null)
                        _gameManager.allLemmings[i].GetComponent<Lemmings>().fsm.ChangeState(PauseState.Instance);
                }
            }

            if(_gameManager.allLemmings.Count == 0) {
                _gameManager.state = GameManager.STATE.WIN;
                _gameManager.StateMachine();

                for(int i = 0 ; i < _gameManager.allLemmings.Count; i++) {
                    if(_gameManager.allLemmings[i].GetComponent<Lemmings>() != null)
                        _gameManager.allLemmings[i].GetComponent<Lemmings>().fsm.ChangeState(PauseState.Instance);
                }
            }
        }
           
    }
}

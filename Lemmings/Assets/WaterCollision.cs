using UnityEngine;
using System.Collections;

public class WaterCollision : CollisionManager {

    private GameManager _gameManager;

    private void Start() {
        _gameManager = GameManager.instance;
    }

	protected override void EnterLAllCollision(GameObject Lemmings) {
        Lemmings.GetComponent<Lemmings>().fsm.ChangeState(SinkState.Instance);
        _gameManager.lemmingsDead++;

        if(_gameManager.lemmingsDead >= _gameManager.deadLemmingsToGameOver) {
            _gameManager.state = GameManager.STATE.GAMEOVER;
            _gameManager.StateMachine();
            _gameManager.isPaused = true;
            
            for(int i = 0 ; i < _gameManager.allLemmings.Count; i++) {
                if(_gameManager.allLemmings[i].GetComponent<Lemmings>() != null)
                    _gameManager.allLemmings[i].GetComponent<Lemmings>().fsm.ChangeState(PauseState.Instance);
            }
        }
    }
}

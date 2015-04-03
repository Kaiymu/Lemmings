using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : SingleBehaviour<GameManager> {

	[HideInInspector]
    public List<GameObject> allLemmings = new List<GameObject>();
    [HideInInspector]
    public int numberOfLemmings;

    [HideInInspector]
    public bool isPaused;

    [HideInInspector]
    public int numberMaxOfLemmings;
    [HideInInspector]
    public float numberMaxOfLemmingsToLoose;
    [HideInInspector]
    public int deadLemmings;
    [HideInInspector]
    public int numberOfLemmingsSaved;

    public Transform endLevel;
    public Transform gameOver;

	private GUIManager _GUIManager;
    private LemmingsManager _lemmingManager;

    [HideInInspector]
    public enum STATE{GAMEOVER, PAUSE, INGAME, WIN, SHAMAN};
    public STATE state;

	private void Awake() {
		SetManager();
        state = STATE.INGAME;
	}

    private void Update() {
        IsVisible();
    }

    public void StateMachine() {
        switch(state) {
            case STATE.GAMEOVER:
                SetActive(gameOver, endLevel);
                break;
            case STATE.INGAME:
                break;
            case STATE.PAUSE:
                break;
            case STATE.SHAMAN:
                break;
            case STATE.WIN:
                _GUIManager.SetNumberOfLemmingsSaved(numberOfLemmingsSaved);
                SetActive(endLevel, gameOver);
                break;
        }
    }

    private void SetActive(Transform toActive, Transform toHide) {
        toActive.gameObject.SetActive(true);
        toHide.gameObject.SetActive(false);
    }

    private IEnumerator IsVisible() {
        for(int i = 0; i < allLemmings.Count; i++) {
            if(allLemmings[i].GetComponent<Renderer>().isVisible == false) { 
                yield return new WaitForSeconds(5);
                if(allLemmings[i].GetComponent<Renderer>().isVisible == false) {
                    _lemmingManager.RemoveLemming(allLemmings[i], "other");
                }
            }
        }
    }

	private void SetManager() {
		_GUIManager = GUIManager.instance;
        _lemmingManager = LemmingsManager.instance;
	}

	public void SetNumberOfLemmings(int number, string isDeadOrSaved) {
		numberOfLemmings += number;
		_GUIManager.SetNumberOfLemmings(numberOfLemmings);

        if(number < 0 && isDeadOrSaved == "dead") {
            deadLemmings++;
            if(deadLemmings > numberMaxOfLemmingsToLoose && numberOfLemmingsSaved > 0) {
                isPaused = true;
                state = STATE.GAMEOVER;
                StateMachine();
            }
        }
	}

    public void SetNumberMaxOfLemmings(int number) {
        numberMaxOfLemmings = number;
        numberMaxOfLemmingsToLoose = Mathf.Round(number / 4);
    }
}
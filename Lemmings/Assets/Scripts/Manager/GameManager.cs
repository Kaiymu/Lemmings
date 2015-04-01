using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : SingleBehaviour<GameManager> {

	[HideInInspector]
	public List<GameObject> allLemmings;
    public int numberOfLemmings;

    [HideInInspector]
    public bool isPaused;

	private GUIManager _GUIManager;
    private LemmingsManager _lemmingManager;

	private void Awake() {
		SetManager();
		SetList();
	}

    private void Update() {
        IsVisible();
    }

    private IEnumerator IsVisible() {
        for(int i = 0; i < allLemmings.Count; i++) {
            if(allLemmings[i].GetComponent<Renderer>().isVisible == false) { 
                yield return new WaitForSeconds(5);
                if(allLemmings[i].GetComponent<Renderer>().isVisible == false) {
                    _lemmingManager.RemoveLemming(allLemmings[i]);
                }
            }
        }
    }

	private void SetManager() {
		_GUIManager = GUIManager.instance;
        _lemmingManager = LemmingsManager.instance;
	}

    private void SetList() {
		allLemmings = new List<GameObject>();
    }

	public void SetNumberOfLemmings(int number) {
		numberOfLemmings += number;
		_GUIManager.SetNumberOfLemmings(numberOfLemmings);
	}
}
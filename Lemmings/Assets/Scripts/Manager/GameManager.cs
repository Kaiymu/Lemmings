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

	private void Awake() {
		SetManager();
		GetAllLemmings();
	}

    private void IsVisible() {

    }

	private void SetManager() {
		_GUIManager = GUIManager.instance;
	}

	private void GetAllLemmings() {
		allLemmings = new List<GameObject>();
    }

	public void SetNumberOfLemmings(int number) {
		numberOfLemmings += number;
		_GUIManager.SetNumberOfLemmings(numberOfLemmings);
	}
}
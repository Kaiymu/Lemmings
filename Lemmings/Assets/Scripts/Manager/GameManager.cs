using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : SingleBehaviour<GameManager> {

	[HideInInspector]
	public List<GameObject> allLemmings;
	public int numberOfLemmings;

	private GUIManager _GUIManager;

	private void Awake() {
		SetManager();
		GetAllLemmings();
	}

	private void SetManager() {
		_GUIManager = GUIManager.instance;
	}

	private void GetAllLemmings() {
		allLemmings = new List<GameObject>();
		
		GameObject[] gos = GameObject.FindGameObjectsWithTag("Lemming");
		
		foreach(GameObject lemming in gos) {
			allLemmings.Add(lemming);
		}
		
		numberOfLemmings = allLemmings.Count;

		_GUIManager.SetNumberOfLemmings(numberOfLemmings);
	}

	public void SetNumberOfLemmings(int number) {
		numberOfLemmings += number;
		_GUIManager.SetNumberOfLemmings(numberOfLemmings);
	}
}
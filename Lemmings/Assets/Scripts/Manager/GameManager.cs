using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : SingleBehaviour<GameManager> {

	public List<GameObject> allLemmings;

	private void Awake() {
		allLemmings = new List<GameObject>();

		GameObject[] gos = GameObject.FindGameObjectsWithTag("Lemming");
		
		foreach(GameObject lemming in gos) {
			allLemmings.Add(lemming);
		}
	}
}
using UnityEngine;
using System.Collections;

public class GUIManager : SingleBehaviour<GUIManager> {

	public Transform numberOfLemmingsText;

	private GUIText _numberOfLemmingsText;
	private int numberMaxOfLemmings;

	private void Start() {
		numberMaxOfLemmings = 3;
		_numberOfLemmingsText = numberOfLemmingsText.GetComponent<GUIText>();
	}

	public void NumberOfLemmings(int number) {
		_numberOfLemmingsText.text = "Number of Lemmings : " + number.ToString();
	}

}
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManager : SingleBehaviour<GUIManager> {

	public Text numberOfLemmings;

	public void SetNumberOfLemmings(int number) {
		numberOfLemmings.text = number.ToString();
	}
}
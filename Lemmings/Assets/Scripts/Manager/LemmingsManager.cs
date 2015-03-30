using UnityEngine;
using System.Collections;

public class LemmingsManager : MonoBehaviour {

	private bool _leftMouseButton;

	private InputManager _inputManager;

	private GameObject _lemming;

	private void Start() {
		_inputManager = InputManager.instance;
	}
	
	private void Update() {
		GetMousePressed();

		if(_leftMouseButton == true) {

			_lemming = _inputManager.GetGameObjectClicked();

			if(_lemming != null) {
				SaveClickedLemming();
			}
		}
	}
	
	private void GetMousePressed() {
		_leftMouseButton = _inputManager.LeftMouseButton();
	}

	private void SaveClickedLemming() {

	}
}
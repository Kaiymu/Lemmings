using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CauldronManager : SingleBehaviour<CauldronManager> {

	private bool _leftMouseButton,
				 _canCombineLemming;
	
	private InputManager _inputManager;
	private LemmingsManager _lemmingManager;

	private GameObject _selectedCauldron;

	private List<GameObject> _lemmings;
	
	private void Start() {
		_inputManager = InputManager.instance;
		_lemmingManager = LemmingsManager.instance;

		_lemmings = new List<GameObject>();

		_canCombineLemming = false;
	}

	private void Update() {
		GetMousePressed();

		if(_leftMouseButton == true && _canCombineLemming == true) {
			_canCombineLemming = false;
			_selectedCauldron = _inputManager.GetGameObjectClicked();
			
			if(_selectedCauldron != null && _selectedCauldron.tag == "Cauldron" && _lemmingManager.canCombineLemmings == true) {
				CombineLemmings();
			}
		} if(_leftMouseButton == false && _canCombineLemming == false) {
			_canCombineLemming = true;
		}
	}
	
	private void GetMousePressed() {
		_leftMouseButton = _inputManager.LeftMouseButton();
	}

	private void CombineLemmings() {
		_lemmings = _lemmingManager.lemmings;
		Debug.Log("NEW LEMMING");
	}
}
using UnityEngine;
using System.Collections;

public class CauldronManager : SingleBehaviour<CauldronManager> {

	private bool _leftMouseButton,
				 _canCombineLemming;
	
	private InputManager _inputManager;
	private LemmingsManager _lemmingManager;
	private GameManager _gameManager;
	private CombinationManager _combinationManager;

	private GameObject _selectedCauldron;

	private void Start() {
		SetManager();
		_canCombineLemming = false;
	}

	private void SetManager() {
		_inputManager = InputManager.instance;
		_lemmingManager = LemmingsManager.instance;
		_gameManager = GameManager.instance;
		_combinationManager = CombinationManager.instance;
	}

	private void Update() {
		GetMousePressed();
		CheckIfClickOnCauldron();
	}
	
	private void GetMousePressed() {
		_leftMouseButton = _inputManager.LeftMouseButton();
	}

	private void CheckIfClickOnCauldron() {
		if(_leftMouseButton == true && _canCombineLemming == true) {
			_canCombineLemming = false;
			_selectedCauldron = _inputManager.GetGameObjectClicked();

            if(_selectedCauldron != null) {
                if(_lemmingManager.canCombineLemmings == true && _selectedCauldron.tag == "CAULDRON_BEHAVIOR"  || _selectedCauldron.tag == "CAULDRON_ENVIRONMENT") {
                    CombineLemmings();
                }
            }
			
		} if(_leftMouseButton == false && _canCombineLemming == false) {
			_canCombineLemming = true;
		}
	}

	private void CombineLemmings() {
		_combinationManager.CombineTwoLemmings(_lemmingManager.lemmings[0], _lemmingManager.lemmings[1], _selectedCauldron.tag);

		foreach(GameObject _lemming in _lemmingManager.lemmings) {
			if(_gameManager.allLemmings.Contains(_lemming)) {
				_gameManager.allLemmings.Remove(_lemming);
				_gameManager.SetNumberOfLemmings(-1, "dead");
			}
			Destroy(_lemming);
		}

		_lemmingManager.lemmings.Clear();
	}
}
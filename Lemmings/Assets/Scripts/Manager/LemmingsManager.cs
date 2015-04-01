using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LemmingsManager : SingleBehaviour<LemmingsManager> {

	private bool _leftMouseButton,
				 _canSaveLemming;

	[HideInInspector]
	public bool canCombineLemmings;

	private InputManager _inputManager;

	public List<GameObject> lemmings;

	private GameObject _selectedLemming;

	private void Start() {
		_inputManager = InputManager.instance;

		lemmings = new List<GameObject>();

		_canSaveLemming = true;
		canCombineLemmings = false;
	}
	
	private void Update() {
		GetMousePressed();
        CheckIfLemmingIsSelected();
        RetrieveLemmingsClicked();
	}
	
	private void GetMousePressed() {
		_leftMouseButton = _inputManager.LeftMouseButton();
	}

	private void CheckIfLemmingIsSelected() {
		if(_leftMouseButton == true && _canSaveLemming == true) {
			_canSaveLemming = false;
			_selectedLemming = _inputManager.GetGameObjectClicked();
			
			if(_selectedLemming != null && _selectedLemming.tag == "Lemming") {
				SaveClickedLemming();
			}
		} if(_leftMouseButton == false && _canSaveLemming == false) {
			_canSaveLemming = true;
		}
	}

	private void SaveClickedLemming() {
		if(lemmings.Contains(_selectedLemming)) {
			canCombineLemmings = false;
			lemmings.Remove(_selectedLemming);
			_selectedLemming.GetComponent<Renderer>().material.color = Color.grey;
		} else if(lemmings.Count > 1) {
			Debug.Log("Two lemmings already selected");
		} else {
			if(lemmings.Count == 1) {
				canCombineLemmings = true;
				lemmings.Add(_selectedLemming);

				_selectedLemming.GetComponent<Renderer>().material.color = Color.red;
			} else {
				canCombineLemmings = false;
				lemmings.Add(_selectedLemming);
				
				_selectedLemming.GetComponent<Renderer>().material.color = Color.red;
			}
		}
	}
    
    public void RetrieveLemmingsClicked() {
        GameObject gameobjectClicked = _inputManager.GetOnClickedObject();
	
		if(InputManager.instance.LeftMouseButtonDown()) {
	        if(gameobjectClicked != null) {
	            if(gameobjectClicked.tag == "Lemming") {
	                gameobjectClicked.GetComponent<Lemmings>().AnimatorList();
	            }
	        }
		}
    }

    public void RemoveLemmings(GameObject lemmingsToDelete) {
    	Destroy(lemmingsToDelete, 0.1f);
    }
}
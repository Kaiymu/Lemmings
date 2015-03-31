using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManager : SingleBehaviour<InputManager> {

	public bool LeftMouseButton() {
		if(Input.GetMouseButton(0)) {
			return true;
		} else {
			return false;
		}
	}

	public bool RightMouseButton() {
		if(Input.GetMouseButton(1)) {
			return true;
		} else {
			return false;
		}
	}

	public GameObject GetGameObjectClicked()
	{
		Vector3 _pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		RaycastHit2D _hit = Physics2D.Raycast(_pos, Vector2.zero);
		
		if(_hit.collider != null)
		{
			//Debug.Log (_hit.collider.gameObject.transform.position);
			return _hit.collider.gameObject;
		} else {
			return null;
		}
	}

    public GameObject GetOnClickedObject() {
        if(Input.GetMouseButton(0)) {
            return GetGameObjectClicked();
        }
        return null;

    }

}
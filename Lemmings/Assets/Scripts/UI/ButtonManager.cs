using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour {

    void OnMouseEnter() {
        this.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }

    void OnMouseExit() {
        this.transform.localScale = new Vector3(1, 1, 1);
    }

    void OnMouseDown() {
        if(this.gameObject.name == "Play") {
            Application.LoadLevel(1);
        } else {
            Application.LoadLevel(5);
        }
        if(this.gameObject.name == "Replay") {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}

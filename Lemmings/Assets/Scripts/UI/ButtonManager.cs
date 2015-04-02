using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour {

    void OnMouseEnter() {
        this.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    void OnMouseExit() {
        this.gameObject.GetComponent<Renderer>().material.color = new Color(1,1,1,1);
    }

    void OnMouseDown() {
        if(this.gameObject.name == "Play") {
            Application.LoadLevel("samya");
        } else {
            Application.LoadLevel("credits");
        }
        if(this.gameObject.name == "Replay") {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}

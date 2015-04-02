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
            Application.LoadLevel("samya");
        } else {
            Application.LoadLevel("credits");
        }
        if(this.gameObject.name == "Replay") {
            Application.LoadLevel(Application.loadedLevel);
        }
    }


    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    void Update() {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
}

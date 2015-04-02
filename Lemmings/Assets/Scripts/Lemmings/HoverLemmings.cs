using UnityEngine;
using System.Collections;

public class HoverLemmings : MonoBehaviour {

    void OnMouseEnter() {
        this.transform.GetComponent<Renderer>().material.color = new Color(1f,1f,1f, 0.7f);
    }
    
    void OnMouseExit() {
        this.transform.GetComponent<Renderer>().material.color = new Color(1f,1f,1f, 1f);
    }
}

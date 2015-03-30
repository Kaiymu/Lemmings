using UnityEngine;
using System.Collections;

public class Home : MonoBehaviour {

    public GameObject peonPrefab;
    public float Minerals { get; set; }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 40), "Create peon"))
        {
            Instantiate(peonPrefab, transform.position, Quaternion.identity);
        }

        GUI.Label(new Rect(Screen.width - 110, 10, 100, 40), "Minerals : " + Mathf.Floor(Minerals).ToString());
    }
}
using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public void ReloadLevel() {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void NextLevel() {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void LoadLevel(string levelToLoad) {
        Application.LoadLevel(levelToLoad);
    }
}

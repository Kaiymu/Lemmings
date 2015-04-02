using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManager : SingleBehaviour<GUIManager> {

	public Text numberOfLemmings;
    public Text timer;

    private float _timer;

    private string _minutes,
                  _seconds;

    private GameManager _gameManager;

    private void Start() {
        _gameManager = GameManager.instance;
    }

    private void Update() {
        CountTime();
    }

    public void CountTime() {
        _timer += Time.deltaTime;

        _minutes = Mathf.Floor(_timer / 60).ToString("00");
        _seconds = Mathf.Floor(_timer % 60).ToString("00");

        timer.text = _minutes + " : " + _seconds;
    }

    public void SetNumberOfLemmings(int number) {
        numberOfLemmings.GetComponent<Text>().text = number.ToString() + " / " + _gameManager.numberMaxOfLemmings;
    }
}
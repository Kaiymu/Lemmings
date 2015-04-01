using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombinationManager : SingleBehaviour<CombinationManager> {

	[System.Serializable]
	public class ColorCombination {
		public string name;

		public enum LEMMINGCOLOR {BLUE, YELLOW, RED};
		public LEMMINGCOLOR color1;
		public LEMMINGCOLOR color2;

		public enum CAULDRON {CAULDRON_ENVIRONMENT, CAULDRON_BEHAVIOR};
		public CAULDRON cauldron;

		public enum NEWLEMMING {POISON, STONE, BOUNCE, PLATFORM, GRAVITY, LOVE, NEUTRAL};
		public NEWLEMMING newLemming;
	}

	public List<ColorCombination> combinations;
    private GameObject[] lemmingsPrefabs = new GameObject[7];

    private GameManager _gameManager;
    private LemmingsManager _lemmingsManager;

    private void Start() {
        SetManager();
        LoadLemmings();
    }

    private void SetManager() {
        _gameManager = GameManager.instance;
        _lemmingsManager = LemmingsManager.instance;
    }

    private void LoadLemmings() { 
        lemmingsPrefabs[0] = Resources.Load("Prefabs/Lemmings/LemmingsNeutral") as GameObject;
        lemmingsPrefabs[1] = Resources.Load("Prefabs/Lemmings/LemmingsBounce") as GameObject;
        lemmingsPrefabs[2] = Resources.Load("Prefabs/Lemmings/LemmingsLove") as GameObject;
        lemmingsPrefabs[3] = Resources.Load("Prefabs/Lemmings/LemmingsPlatform") as GameObject;
        lemmingsPrefabs[4] = Resources.Load("Prefabs/Lemmings/LemmingsPoison") as GameObject;
        lemmingsPrefabs[5] = Resources.Load("Prefabs/Lemmings/LemmingsStone") as GameObject;
        lemmingsPrefabs[6] = Resources.Load("Prefabs/Lemmings/LemmingsGravity") as GameObject;
    }

	public void CombineTwoLemmings(GameObject firstLemming, GameObject secondLemming, string selectedCauldron) {
		string firstLemmingColor = firstLemming.GetComponent<Lemmings>().lemmingColor;
		string secondLemmingColor = secondLemming.GetComponent<Lemmings>().lemmingColor;

		for(int i = 0; i < combinations.Count; i++) {
			if(combinations[i].color1.ToString() == firstLemmingColor || combinations[i].color1.ToString() == secondLemmingColor) {
				if(combinations[i].color2.ToString() == firstLemmingColor || combinations[i].color2.ToString() == secondLemmingColor) {
					if(combinations[i].cauldron.ToString() == selectedCauldron) {
                        if(RetrieveLemmingsFromType(combinations[i].newLemming.ToString()) != null) {
                            GameObject newLemming = Instantiate(RetrieveLemmingsFromType(combinations[i].newLemming.ToString())) as GameObject;
                            newLemming.transform.parent = GameObject.FindGameObjectWithTag("Lemmings").transform;

                            _gameManager.SetNumberOfLemmings(1);
                            _gameManager.allLemmings.Add(newLemming);
                            
                            newLemming.transform.position = _lemmingsManager.lemmings[0].transform.position;
                            newLemming.transform.parent = GameObject.FindGameObjectWithTag("Lemmings").transform;

                            Debug.Log(newLemming);
                        }
					}
				}
			}
		}
	}

    private GameObject RetrieveLemmingsFromType(string type)
    {
        switch(type)
        {
            case "NEUTRAL" :
                return lemmingsPrefabs[0];
            case "BOUNCE" : 
                return lemmingsPrefabs[1];
            case "LOVE" :
                return lemmingsPrefabs[2];
            case "PLATFORM" : 
                return lemmingsPrefabs[3];
            case "POISON" : 
                return lemmingsPrefabs[4];
            case "STONE" : 
                return lemmingsPrefabs[5];
            case "GRAVITY" : 
                return lemmingsPrefabs[6];
        }
        return null;
    }
}
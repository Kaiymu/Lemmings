using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class LemmingSpawner : MonoBehaviour {
    
    public TextAsset xmlLDSetup;
    private GameObject[] lemmingsPrefabs = new GameObject[7];
    private XmlNodeList lemmings;

    private Color _blue = Color.blue;
    private Color _red = Color.red;
    private Color _green = Color.green;

    private int i = 0;
    private float spawnDeltaTime = 0f;

    private GameManager _gameManager;

    private void LoadLemmings() { 
        lemmingsPrefabs[0] = Resources.Load("Prefabs/Lemmings/LemmingsNeutral") as GameObject;
        lemmingsPrefabs[1] = Resources.Load("Prefabs/Lemmings/LemmingsBounce") as GameObject;
		lemmingsPrefabs[2] = Resources.Load("Prefabs/Lemmings/LemmingsLove") as GameObject;
		lemmingsPrefabs[3] = Resources.Load("Prefabs/Lemmings/LemmingsPlatform") as GameObject;
		lemmingsPrefabs[4] = Resources.Load("Prefabs/Lemmings/LemmingsPoison") as GameObject;
		lemmingsPrefabs[5] = Resources.Load("Prefabs/Lemmings/LemmingsStone") as GameObject;
		lemmingsPrefabs[6] = Resources.Load("Prefabs/Lemmings/LemmingsGravity") as GameObject;
    }
    
    private void Start() {
        SetManager();
        SetXML();
        LoadLemmings();
    }
    
    private void Update() {
        LemmingsToSpawn();
    }

    private void SetManager() {
        _gameManager = GameManager.instance;
    }

    private void SetXML() {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlLDSetup.text);
        lemmings = xmlDoc.GetElementsByTagName("Lemming");
        _gameManager.SetNumberMaxOfLemmings(lemmings.Count);
    }

    private float deltatimeCustom = 0f;
    private void LemmingsToSpawn() {

        if(!GameManager.instance.isPaused) {
            if(i < lemmings.Count) {
                deltatimeCustom += Time.deltaTime;
                XmlNode lemming = lemmings[i];

                float ancienSpawnDeltaTime = spawnDeltaTime;
                spawnDeltaTime = float.Parse(lemming.Attributes["spawnDeltaTime"].Value);

                if ((spawnDeltaTime + ancienSpawnDeltaTime) < deltatimeCustom) {
                    i++;
                    string type = lemming.Attributes["type"].Value.ToString();
    				string color = lemming.Attributes["color"].Value.ToString();

    				if(RetrieveLemmingsFromType(type) != null) {
    					GameObject newLemming = Instantiate(RetrieveLemmingsFromType(type), transform.position, transform.rotation) as GameObject;
    					newLemming.transform.parent = GameObject.FindGameObjectWithTag("Lemmings").transform;
    					newLemming.GetComponent<Lemmings>().lemmingColor = color;
                        newLemming.GetComponent<SpriteRenderer>().color = ColorParser(color);
                        _gameManager.allLemmings.Add(newLemming);
                        _gameManager.SetNumberOfLemmings(1);
    				}             
                }
            }
        }
    }

    private Color ColorParser(string color) {
        switch(color)
        {
            case "BLUE" :
                return Color.blue;
            case "RED" : 
                return Color.red;
            case "YELLOW" :
                return Color.yellow;
        }
        return Color.white;

    }
    
    private GameObject RetrieveLemmingsFromType(string type)
    {
        switch(type)
        {
            case "lemmingNeutral" :
                return lemmingsPrefabs[0];
            case "lemmingBounce" : 
                return lemmingsPrefabs[1];
			case "lemmingLove" :
				return lemmingsPrefabs[2];
			case "lemmingPlatform" : 
				return lemmingsPrefabs[3];
			case "lemmingPoison" : 
				return lemmingsPrefabs[4];
			case "lemmingStone" : 
				return lemmingsPrefabs[5];
			case "lemmingGravity" : 
				return lemmingsPrefabs[6];
        }
        return null;
    }
}

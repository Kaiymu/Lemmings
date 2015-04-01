using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class LemmingSpawner : MonoBehaviour {
    
    public TextAsset xmlLDSetup;
    private GameObject[] lemmingsPrefabs = new GameObject[6];
    private XmlNodeList lemmings;

    private int i = 0;
    private float spawnDeltaTime = 0f;

    private void LoadLemmings() { 
        lemmingsPrefabs[0] = Resources.Load("Prefabs/Lemmings/LemmingsNeutral") as GameObject;
        lemmingsPrefabs[1] = Resources.Load("Prefabs/Lemmings/LemmingsBounce") as GameObject;
		lemmingsPrefabs[2] = Resources.Load("Prefabs/Lemmings/LemmingsPoison") as GameObject;
		lemmingsPrefabs[3] = Resources.Load("Prefabs/Lemmings/LemmingsStone") as GameObject;
    }
    
    private void Start() {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlLDSetup.text);
        lemmings = xmlDoc.GetElementsByTagName("Lemming");

        LoadLemmings();
    }
    
    private void Update() {
        LemmingsToSpawn();
    }

    private void LemmingsToSpawn() {

        if(i < lemmings.Count) {
            XmlNode lemming = lemmings[i];

            float ancienSpawnDeltaTime = spawnDeltaTime;
            spawnDeltaTime = float.Parse(lemming.Attributes["spawnDeltaTime"].Value);

            if ((spawnDeltaTime + ancienSpawnDeltaTime) < Time.time) {
                i++;
                string type = lemming.Attributes["type"].Value.ToString();
				string color = lemming.Attributes["color"].Value.ToString();

				if(RetrieveLemmingsFromType(type) != null) {
					GameObject newLemming = Instantiate(RetrieveLemmingsFromType(type), transform.position, transform.rotation) as GameObject;
					newLemming.transform.parent = GameObject.FindGameObjectWithTag("Lemmings").transform;
					newLemming.GetComponent<Lemmings>().lemmingColor = color;
				}             
            }
        }
    }
    
    private GameObject RetrieveLemmingsFromType(string type)
    {
		Debug.Log (type);
        switch(type)
        {
            case "lemmingNeutral" :
                return lemmingsPrefabs[0];
            case "lemmingBounce" : 
                return lemmingsPrefabs[1];
			case "lemmingPoison" :
				return lemmingsPrefabs[2];
			case "lemmingStone" : 
				return lemmingsPrefabs[3];
        }
        return null;
    }
}

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

		public enum NEWLEMMING {POISON, ROCH, JUMP, PLATFORM, GRAVITY, LOVE};
		public NEWLEMMING newLemming;
	}

	public List<ColorCombination> combinations;

	public void CombineTwoLemmings(GameObject firstLemming, GameObject secondLemming, string selectedCauldron) {
		string firstLemmingColor = firstLemming.GetComponent<Lemmings>().lemmingColor;
		string secondLemmingColor = secondLemming.GetComponent<Lemmings>().lemmingColor;

		for(int i = 0; i < combinations.Count; i++) {
			if(combinations[i].color1.ToString() == firstLemmingColor || combinations[i].color1.ToString() == secondLemmingColor) {
				if(combinations[i].color2.ToString() == firstLemmingColor || combinations[i].color2.ToString() == secondLemmingColor) {
					if(combinations[i].cauldron.ToString() == selectedCauldron) {
						Debug.Log("Push new lemming : " + combinations[i].newLemming.ToString());
					}
				}
			}
		}
	}
}
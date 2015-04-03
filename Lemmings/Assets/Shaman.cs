using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Xml;

public class Shaman : MonoBehaviour {

    public Text shamanText;
    public TextAsset xmlShamanTextField;
    private XmlNodeList shamanTextsXML;
    
    private int i = 0;

	void Start () {
        GameManager.instance.isPaused = true;
        SetXML();
        XmlNode shamanTextXML = shamanTextsXML[0];
        shamanText.text = shamanTextXML.Attributes["text"].Value.ToString();
	}

    private void SetXML() {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlShamanTextField.text);
        shamanTextsXML = xmlDoc.GetElementsByTagName("Shaman");
    }

    private void Update() {
        DisplayNextText();
    }

    private void DisplayNextText() {
        if(InputManager.instance.LeftMouseButtonDown() && i < shamanTextsXML.Count)
        {
            XmlNode shamanTextXML = shamanTextsXML[i];
            shamanText.text = shamanTextXML.Attributes["text"].Value.ToString();
            i++;
        }

        if(i >= shamanTextsXML.Count) {
            FadeOutShamanAndText();
        }
    }
   
    private void FadeOutShamanAndText() {
        GameManager.instance.isPaused = false;
        gameObject.SetActive(false);
        shamanText.gameObject.SetActive(false);
    }
	
}

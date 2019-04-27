using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuLevelSelect : MonoBehaviour {
	public GameObject slide;

	public GameObject toggler;
	bool firstUpdate = true;

	string[] levels = {
		"Level1",
		"Level2",
		"MinionKing",
		"Level3",
		"Level4",
		"Level5",
		"BoarKing",
		"Level6",
		"Level7",
		"Level8",
		"WitchKing"
	};

	
	// Update is called once per frame
	void FixedUpdate () {
		if (slide.GetComponent<Scrollbar> ().value != 0 && firstUpdate) {
						toggler.GetComponent<Toggle> ().isOn = true;
			firstUpdate = false;
				}
		float swag = slide.GetComponent<Scrollbar> ().value;
		if (swag <= .9) {
						GetComponent<Text> ().text = levels [Mathf.FloorToInt (swag / .0909090909090909f)];
				} else
						GetComponent<Text> ().text = levels [10];
	}

	public string imput()
	{
		if (GetComponent<Text> ().text == "Level1")
						return "level2";
		if (GetComponent<Text> ().text == "Level2")
			return "level3";
		if (GetComponent<Text> ().text == "MinionKing")
			return "boss1";
		if (GetComponent<Text> ().text == "Level3")
			return "level4";
		if (GetComponent<Text> ().text == "Level4")
			return "level5";
		if (GetComponent<Text> ().text == "Level5")
			return "level6";
		if (GetComponent<Text> ().text == "BoarKing")
			return "boss2";
		if (GetComponent<Text> ().text == "Level6")
			return "level7";
		if (GetComponent<Text> ().text == "Level7")
			return "level8";
		if (GetComponent<Text> ().text == "Level8")
			return "level9";
		if (GetComponent<Text> ().text == "WitchKing")
			return "boss3";
		return "error";
	}
}

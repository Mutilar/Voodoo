//Main Menu
//Attached To Main Camera
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	//
	//public GameObject fade;
	public string savedLevel = "cutscene2";

	public GameObject toggler;

	public GameObject buttonCamp;
	public GameObject buttonCont;
	public GameObject buttonTuto;
	public GameObject buttonSett;
	public GameObject buttonExit;

	public GameObject buttonDiff;
	public GameObject buttonJagg;
	public GameObject buttonLeve;

	public GameObject text;

	public GameObject fade;

	int slideCount = 0;

	bool settingsOpen = false;
	bool fading = false;
	string level;
	int fadeCount = 0;

	public void open(string level)
	{
		fadeCount = 0;
		if (level == "campaign") 
			if (toggler.GetComponent<Toggle>().isOn) Application.LoadLevel(text.GetComponent<MenuLevelSelect>().imput ());
			else Application.LoadLevel("cutscene2");
		if (level == "continuous") Application.LoadLevel("continuous");
		if (level == "tutorial") Application.LoadLevel ("testing");
		if (level == "settings") 
		{
			if (slideCount == 0)
			{
				slideCount = 150;
				settingsOpen = !settingsOpen;
			}
		}
		if (level == "exit") Application.Quit();
	}

	void FixedUpdate () 
	{
		if (slideCount > 0) {
			if (settingsOpen)
			{
				if (slideCount > 75 && slideCount < 135) buttonSett.transform.position = new Vector2(buttonSett.transform.position.x - (Mathf.Pow(slideCount, 2) / 2000f), buttonSett.transform.position.y + (Mathf.Pow(slideCount, 2) / 2200f));
				if (slideCount > 90 && slideCount < 150) buttonCamp.transform.position = new Vector2(buttonCamp.transform.position.x + (Mathf.Pow(slideCount, 2) / 500f), buttonCamp.transform.position.y);
				if (slideCount > 85 && slideCount < 145) buttonCont.transform.position = new Vector2(buttonCont.transform.position.x + (Mathf.Pow(slideCount, 2) / 500f), buttonCont.transform.position.y);
				if (slideCount > 80 && slideCount < 140) buttonTuto.transform.position = new Vector2(buttonTuto.transform.position.x + (Mathf.Pow(slideCount, 2) / 500f), buttonTuto.transform.position.y);
				if (slideCount > 70 && slideCount < 130) buttonExit.transform.position = new Vector2(buttonExit.transform.position.x + (Mathf.Pow(slideCount, 2) / 500f), buttonExit.transform.position.y);
				if (slideCount > 90 && slideCount < 150) buttonDiff.transform.position = new Vector2(buttonDiff.transform.position.x - (Mathf.Pow(slideCount, 2) / 500f), buttonDiff.transform.position.y);
				if (slideCount > 80 && slideCount < 140) buttonJagg.transform.position = new Vector2(buttonJagg.transform.position.x - (Mathf.Pow(slideCount, 2) / 500f), buttonJagg.transform.position.y);
				if (slideCount > 70 && slideCount < 130) buttonLeve.transform.position = new Vector2(buttonLeve.transform.position.x - (Mathf.Pow(slideCount, 2) / 500f), buttonLeve.transform.position.y);
			}
			else
			{
				if (slideCount > 75 && slideCount < 135) buttonSett.transform.position = new Vector2(buttonSett.transform.position.x + (Mathf.Pow(slideCount, 2) / 2000f), buttonSett.transform.position.y - (Mathf.Pow(slideCount, 2) / 2200f));
				if (slideCount > 90 && slideCount < 150) buttonCamp.transform.position = new Vector2(buttonCamp.transform.position.x - (Mathf.Pow(slideCount, 2) / 500f), buttonCamp.transform.position.y);
				if (slideCount > 85 && slideCount < 145) buttonCont.transform.position = new Vector2(buttonCont.transform.position.x - (Mathf.Pow(slideCount, 2) / 500f), buttonCont.transform.position.y);
				if (slideCount > 80 && slideCount < 140) buttonTuto.transform.position = new Vector2(buttonTuto.transform.position.x - (Mathf.Pow(slideCount, 2) / 500f), buttonTuto.transform.position.y);
				if (slideCount > 70 && slideCount < 130) buttonExit.transform.position = new Vector2(buttonExit.transform.position.x - (Mathf.Pow(slideCount, 2) / 500f), buttonExit.transform.position.y);
				if (slideCount > 90 && slideCount < 150) buttonDiff.transform.position = new Vector2(buttonDiff.transform.position.x + (Mathf.Pow(slideCount, 2) / 500f), buttonDiff.transform.position.y);
				if (slideCount > 80 && slideCount < 140) buttonJagg.transform.position = new Vector2(buttonJagg.transform.position.x + (Mathf.Pow(slideCount, 2) / 500f), buttonJagg.transform.position.y);
				if (slideCount > 70 && slideCount < 130) buttonLeve.transform.position = new Vector2(buttonLeve.transform.position.x + (Mathf.Pow(slideCount, 2) / 500f), buttonLeve.transform.position.y);
			}
			slideCount--;
		}
	}    
}
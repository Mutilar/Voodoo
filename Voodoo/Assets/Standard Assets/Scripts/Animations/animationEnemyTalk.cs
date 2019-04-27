using UnityEngine;
using System.Collections;

public class animationEnemyTalk : MonoBehaviour {
	int counter;
	// Use this for initialization
	void Start () {
		this.GetComponent<GUIText>().text = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		counter++;
	
		if (counter == 1100)
		{
			this.GetComponent<GUIText>().text = "Show them no mercy.";
		}
		if (counter == 1300)
		{
			this.GetComponent<GUIText>().text = "";
		}
	}
}

using UnityEngine;
using System.Collections;

public class animationDescription : MonoBehaviour {
	int counter;
	// Use this for initialization
	void Start () {
		this.GetComponent<GUIText>().text = "";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		counter++;
		if (counter > 1975)
		{
			this.GetComponent<GUIText>().text = "    Farms were looted and burned";
		}
		if (counter > 2175)
		{
			this.GetComponent<GUIText>().text = "         Those who escaped \n         got together to fight back";
		}
	}
}

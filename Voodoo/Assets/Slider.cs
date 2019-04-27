using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Slider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//LevelSaver swag = new LevelSaver ();
		int jagg = Mathf.FloorToInt(this.GetComponent<Scrollbar>().value / .33f);
		if (jagg == 3) jagg = 2;
		//swag.setJaggedness(jagg);

		LevelSaver.setRough(jagg);
		//print (Mathf.FloorToInt(this.GetComponent<Scrollbar>().value / .33f) + " :X: " + swag.getJaggedness());
	}
}

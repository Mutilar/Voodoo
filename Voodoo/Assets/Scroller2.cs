using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scroller2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		/*LevelSaver swag = new LevelSaver ();
		int diff = Mathf.FloorToInt(this.GetComponent<Scrollbar>().value / .33f);
		if (diff == 3) diff = 2;
		swag.setContinuousDifficulty (diff);
		print (diff + " " + swag.getContinuousDifficulty ());*/
		int diff = Mathf.FloorToInt(this.GetComponent<Scrollbar>().value / .33f);
		if (diff == 3) diff = 2;
		LevelSaver.setDiff (diff);
		//print (Mathf.FloorToInt(this.GetComponent<Scrollbar>().value / .33f) + " :X: " + swag.getJaggedness());
	}
}

using UnityEngine;
using System.Collections;

public class animationFarmerSpy : MonoBehaviour {
	int counter = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		counter++;
		Vector3 position = this.transform.position;
		if (counter >= 475 && counter <= 950) {
			Vector3 scale = this.transform.localScale;
			scale.x = -1f;
			this.transform.localScale = scale;
			position.x -= .01f;
				}

		this.transform.position = position;
	}
}

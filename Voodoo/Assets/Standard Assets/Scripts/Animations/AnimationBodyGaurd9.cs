using UnityEngine;
using System.Collections;

public class AnimationBodyGaurd9 : MonoBehaviour {
	int counter = 0;
	// Use this for initialization
	void Start () {
		GetComponent<Animator> ().SetBool ("Selected", false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		counter++;
		if (counter >= 450) {
			GetComponent<Animator> ().SetBool ("Selected", true);
			Vector3 position = this.transform.position;
			position.x -= .0075f;
			this.transform.position = position;

			Vector3 scale = this.transform.localScale;
			scale.x = -1;
			this.transform.localScale = scale;
		}
	}
}

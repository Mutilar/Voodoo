using UnityEngine;
using System.Collections;

public class animationGeneral4 : MonoBehaviour {
	float speedx = 0;
	float speedy = 0;
	int counter = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		counter++;
		Animator swag = GetComponent<Animator> ();
		Vector3 position = this.transform.position;
		if (counter == 1100) {
			speedx = .01f;
			speedy = -.005f;
			swag.SetBool ("Selected", true);

				}
		if (counter == 1160) {
			speedy = 0f;
				}
		position.x += speedx;
		position.y += speedy;
		this.transform.position = position;

	}
}

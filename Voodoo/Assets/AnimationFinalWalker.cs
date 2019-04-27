using UnityEngine;
using System.Collections;

public class AnimationFinalWalker : MonoBehaviour {
	int counter = 0;
	float speed = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 position = this.transform.position;
		counter++;
		if (counter < 700) {
			speed = -.002f;//position.x -= .005f;
		}
		if (counter == 700) {
			speed = 0f;
			Animator swag = GetComponent<Animator> ();
			swag.SetBool ("Moving", false);
			
			
			
		}
		if (counter == 1000) {
			speed = .002f;
			Animator swag = GetComponent<Animator> ();
			swag.SetBool ("Moving", true);
			Vector3 scale = this.transform.localScale;
			scale.x = 1;
			this.transform.localScale = scale;
		}
		position.x += speed;
		this.transform.position = position;
	}
}

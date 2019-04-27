using UnityEngine;
using System.Collections;

public class AnimationFinalCameraPan : MonoBehaviour {
	float speed = .005f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.position = new Vector3(this.transform.position.x - speed, this.transform.position.y, -10f);
	
		if (speed > 0)	speed -= .000005f;
		if (speed < .00001f)
						speed = 0;
	}
}

using UnityEngine;
using System.Collections;

public class animationSoldiers6 : MonoBehaviour {
	float speed = 0f;
	// Use this for initialization
	void Start () {
		speed = .008f + (Random.value * .004f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.position = new Vector2 (this.transform.position.x + speed, this.transform.position.y);
	}
}

using UnityEngine;
using System.Collections;

public class AnimationBoss3targetMovement : MonoBehaviour {
	float movementX;
	float movementY;
	public GameObject general;
	public GameObject boss;
	// Use this for initialization
	void Start () {
	//Use sin and cos to determine direction needed to move into to hit, only check at start so you can evade.
		//
		//		X.
		//		|	.
		//		|		.
		//		|			.
		//		--------------X
		//
		/////////////////////////
		boss = GameObject.FindGameObjectWithTag ("enemyGO");
		general = GameObject.FindGameObjectWithTag("friendlyGO");
		movementX = (general.transform.position.x - boss.transform.position.x)/50; 
		movementY = (general.transform.position.y - boss.transform.position.y)/50; 
		//vementX /= 50;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 swag = this.transform.position;
		swag.x += movementX;
		swag.y += movementY;
		this.transform.position = swag;
	}
}

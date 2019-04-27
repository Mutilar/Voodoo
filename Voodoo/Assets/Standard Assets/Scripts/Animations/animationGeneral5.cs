using UnityEngine;
using System.Collections;

public class animationGeneral5 : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//"Push while we have the advantage!"
		Vector3 position = this.transform.position;
		position.x += .01f;
		this.transform.position = position;
	}
}

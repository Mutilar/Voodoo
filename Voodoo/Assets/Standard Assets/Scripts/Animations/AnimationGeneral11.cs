using UnityEngine;
using System.Collections;

public class AnimationGeneral11 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.position = new Vector2(this.transform.position.x + .008f, this.transform.position.y);
	}
}

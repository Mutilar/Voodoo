using UnityEngine;
using System.Collections;

public class animationBoss2Boar : MonoBehaviour {
	int counter = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.position = new Vector2 (this.transform.position.x - .015f, this.transform.position.y);
	}
}

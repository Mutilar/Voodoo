using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	if (Input.GetKey (KeyCode.A)) {
			this.transform.position = new Vector2(this.transform.position.x + .01f, this.transform.position.y);
				}
	}

	void OnTriggerEnter(Collider other) {
		Destroy(other.gameObject);
	}
}

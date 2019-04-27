using UnityEngine;
using System.Collections;

public class animation7Combined : MonoBehaviour {
	public GameObject explosion;
	// Use this for initialization
	void Start () {
		this.transform.position = new Vector2(this.transform.position.x + .1f, this.transform.position.y + .1f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.position = new Vector2(this.transform.position.x + .005f, this.transform.position.y);
	}
}

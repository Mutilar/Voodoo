using UnityEngine;
using System.Collections;

public class AnimationGeneral10 : MonoBehaviour {
	int counter = 0 ;
	public GameObject puffRight;
	public AudioClip fireSound;
	// Use this for initialization
	void Start () {
		GetComponent<Animator> ().SetBool ("Slow", true);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		counter++;
		Vector3 swag = this.transform.position;
		swag.x += .0025f;
		this.transform.position = swag;
		if (counter == 700 || counter == 800) {
						AudioSource.PlayClipAtPoint (fireSound, this.transform.position);
						Vector3 fireLocation = this.transform.position;
						fireLocation.z = 2f;
		
						fireLocation.x += .2f;
						Instantiate (puffRight, fireLocation, this.transform.rotation);

				}
	}
}

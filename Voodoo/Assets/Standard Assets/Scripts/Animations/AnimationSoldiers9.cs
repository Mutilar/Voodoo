using UnityEngine;
using System.Collections;

public class AnimationSoldiers9 : MonoBehaviour {
	public GameObject fade;
	int counter = 0;

	public AudioClip talk3;
	public AudioClip talk4;
	public AudioClip grunt4;
	public AudioClip grunt1;
	public AudioClip yell1;
	public GameObject fadeUnfade;
	
	public GameObject location;
	float speed =.01f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		counter++;
		if (counter < 200) {
			Vector3 position = this.transform.position;
			position.x -= .0075f;
			this.transform.position = position;

				}
		if (counter == 200)
						GetComponent<Animator> ().SetBool ("Selected", false);
		if (counter >= 400) {
			GetComponent<Animator> ().SetBool ("Selected", true);
			Vector3 position = this.transform.position;
			position.x -= .0075f;
			this.transform.position = position;
				}

	}
}

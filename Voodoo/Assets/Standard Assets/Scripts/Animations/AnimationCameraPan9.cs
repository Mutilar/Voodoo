using UnityEngine;
using System.Collections;

public class AnimationCameraPan9 : MonoBehaviour {
	public GameObject fade;
	int counter = 0;
	
	public AudioClip talk3;
	public AudioClip talk4;
	public AudioClip grunt4;
	public AudioClip grunt1;
	public AudioClip yell1;
	public GameObject fadeUnfade;
	
	public GameObject location;
	float speed =.005f;
	// Use this for initialization
	void Start () {
		Unfade.resetTimer ();
		for (int i = 0; i < 75; i++)
			Instantiate (fadeUnfade, new Vector3 (0f, 0f, 0f), this.transform.rotation);		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (counter < 200 || counter > 375) {
						Vector3 position = this.transform.position;
						position.x -= speed;
						speed += .00005f;
			if (counter == 199) speed = .001f;
			if (counter > 199) speed += .00005f;
						this.transform.position = position;
				}
		counter++;
		if (counter == 100) AudioSource.PlayClipAtPoint (yell1, this.transform.position);
		if (counter == 160) AudioSource.PlayClipAtPoint (grunt4, this.transform.position);
		if (counter == 230) AudioSource.PlayClipAtPoint (talk3, this.transform.position);
		if (counter == 300) AudioSource.PlayClipAtPoint (grunt1, this.transform.position);
		if (counter == 320) AudioSource.PlayClipAtPoint (talk3, this.transform.position);
		if (counter == 340) AudioSource.PlayClipAtPoint (talk4, this.transform.position);
		if (counter == 450) AudioSource.PlayClipAtPoint (yell1, this.transform.position);
		if (counter == 460) AudioSource.PlayClipAtPoint (talk3, this.transform.position);
		if (counter == 475) AudioSource.PlayClipAtPoint (yell1, this.transform.position);
		//if (counter > 120)
		//	speed -= .0005f;
		//	if (counter == 190) AudioSource.PlayClipAtPoint (grunt3, this.transform.position);
		if (counter >= 475) Instantiate (fade, new Vector3(0f,0f,0f), this.transform.rotation);	
		if (counter == 550)
			Application.LoadLevel ("level6");
	}
}

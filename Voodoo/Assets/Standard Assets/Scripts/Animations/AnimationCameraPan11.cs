using UnityEngine;
using System.Collections;

public class AnimationCameraPan11 : MonoBehaviour {
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
		Unfade.resetTimer ();
		for (int i = 0; i < 75; i++)
			Instantiate (fadeUnfade, new Vector3 (0f, 0f, 0f), this.transform.rotation);		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 position = this.transform.position;
		position.x += .01f;
		this.transform.position = position;
		counter++;
		if (counter == 100) AudioSource.PlayClipAtPoint (yell1, this.transform.position);
		if (counter == 150) AudioSource.PlayClipAtPoint (grunt1, this.transform.position);
		if (counter == 170) AudioSource.PlayClipAtPoint (talk3, this.transform.position);
		if (counter == 200) AudioSource.PlayClipAtPoint (yell1, this.transform.position);
		if (counter == 240) AudioSource.PlayClipAtPoint (grunt4, this.transform.position);
		if (counter == 275) AudioSource.PlayClipAtPoint (talk3, this.transform.position);
		if (counter == 296) AudioSource.PlayClipAtPoint (yell1, this.transform.position);
		if (counter == 320) AudioSource.PlayClipAtPoint (grunt4, this.transform.position);
		if (counter == 360) AudioSource.PlayClipAtPoint (talk4, this.transform.position);
		if (counter == 380) AudioSource.PlayClipAtPoint (yell1, this.transform.position);
		if (counter == 420) AudioSource.PlayClipAtPoint (grunt1, this.transform.position);
		if (counter == 480) AudioSource.PlayClipAtPoint (talk3, this.transform.position);
		//if (counter > 120)
		//	speed -= .0005f;
		//	if (counter == 190) AudioSource.PlayClipAtPoint (grunt3, this.transform.position);
		if (counter >= 450) Instantiate (fade, new Vector3(0f,0f,0f), this.transform.rotation);	
		if (counter == 525)
			Application.LoadLevel ("level9");
	}
}

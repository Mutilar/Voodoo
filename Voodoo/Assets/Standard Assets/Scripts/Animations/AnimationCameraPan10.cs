using UnityEngine;
using System.Collections;

public class AnimationCameraPan10 : MonoBehaviour {
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
		position.x += .003f;
		this.transform.position = position;
		counter++;
		if (counter == 100) AudioSource.PlayClipAtPoint (yell1, this.transform.position);
		if (counter == 240) AudioSource.PlayClipAtPoint (grunt4, this.transform.position);
		if (counter == 500) AudioSource.PlayClipAtPoint (talk3, this.transform.position);
		//if (counter > 120)
		//	speed -= .0005f;
		//	if (counter == 190) AudioSource.PlayClipAtPoint (grunt3, this.transform.position);
		if (counter >= 800) Instantiate (fade, new Vector3(0f,0f,0f), this.transform.rotation);	
		if (counter == 875)
			Application.LoadLevel ("level8");
	}
}

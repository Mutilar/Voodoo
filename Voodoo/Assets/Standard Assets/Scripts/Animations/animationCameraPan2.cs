using UnityEngine;
using System.Collections;

public class animationCameraPan2 : MonoBehaviour {
	int counter;
	float pansize = 1;
	float speed;
	public GameObject fade;

	public AudioClip talk2;
	public AudioClip talk4;

	public AudioClip grunt3;
	public AudioClip yell1;

	public AudioClip puff;
	public AudioClip shoot;

	public GameObject location;

	public GameObject fadeUnfade;
	// Use this for initialization
	void Start () {
		Unfade.resetTimer ();
		for (int i = 0; i < 75; i++) Instantiate (fadeUnfade, new Vector3(0f,0f,0f), this.transform.rotation);		
	}
	// Update is called once per frame
	void FixedUpdate () 
	{
				Vector3 position = this.transform.position;
				counter++;
				if (counter < 850f) {
						speed = -.001f;//position.x -= .005f;
			if (counter == 800)  AudioSource.PlayClipAtPoint (talk4, this.transform.position);
			
		
				}

				if (counter == 850f) {
			speed = 0f;

				}
		if (counter == 855) AudioSource.PlayClipAtPoint (talk2, this.transform.position);
		if (counter == 1000)  AudioSource.PlayClipAtPoint (grunt3, this.transform.position);
		if (counter == 1400) AudioSource.PlayClipAtPoint (puff, this.transform.position);
		if (counter == 1450) AudioSource.PlayClipAtPoint (yell1, this.transform.position);
		if (counter == 1475 || counter == 1525) AudioSource.PlayClipAtPoint (shoot, this.transform.position);
		if (counter >= 1550) Instantiate (location, new Vector3(0f,0f,0f), this.transform.rotation);	
			if (counter >= 1550 && counter <= 1625) 	
			{
				AudioSource swagg = GetComponent<AudioSource> ();
			swagg.volume -= .013f;
				Instantiate (fade, new Vector3(0f,0f,0f), this.transform.rotation);		
			}
		if (counter == 1700) 	Application.LoadLevel ("level2");
				

				position.x += speed;
				this.transform.position = position;
		}
}

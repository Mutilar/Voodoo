using UnityEngine;
using System.Collections;

public class animationCameraPan4 : MonoBehaviour {
	int counter;
	float pansize = 1;
	float speed;
	public GameObject general;
	public GameObject general2;
	public GameObject fadeKill;

	public AudioClip grunt1;
	public AudioClip talk1;
	public AudioClip yell1;
	public AudioClip talk3;
	public AudioClip talk2;
	public AudioClip talk4;
	public AudioClip grunt3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 position = this.transform.position;
		counter++;
		if (counter == 1) {
			speed = -.003f;
				}
		if (counter == 50) AudioSource.PlayClipAtPoint (grunt1, this.transform.position);
		if (counter == 80 || counter == 130)  AudioSource.PlayClipAtPoint (talk3, this.transform.position);
		if (counter == 100 || counter == 165) AudioSource.PlayClipAtPoint (talk2, this.transform.position);
		if (counter == 220)  AudioSource.PlayClipAtPoint (talk1, this.transform.position);
		if (counter == 280)  AudioSource.PlayClipAtPoint (yell1, this.transform.position);


		if (counter >= 400 && counter <= 1000)
		{
			speed = 0f;
			position.x -= (position.x - general.transform.position.x) / 30f;
			position.y -= (position.y - general.transform.position.y) / 30f;
			if (counter >= 500 && counter <= 575) 	Instantiate (fadeKill, new Vector3(0f,0f,0f), this.transform.rotation);		

			if (counter == 980) AudioSource.PlayClipAtPoint (talk4, this.transform.position);
			if (counter == 1000)  AudioSource.PlayClipAtPoint (talk3, this.transform.position);


		}
		if (counter == 1030)  AudioSource.PlayClipAtPoint (talk4, this.transform.position);
		if (counter == 1060) AudioSource.PlayClipAtPoint (grunt1, this.transform.position);
		if (counter == 1100)  AudioSource.PlayClipAtPoint (grunt3, this.transform.position);
		if (counter > 1150) {
			position.x -= (position.x - general2.transform.position.x) / 10f;
			if (counter > 1225) 
			{
				AudioSource swagg = GetComponent<AudioSource> ();
				swagg.volume -= .013f;
				Instantiate (fadeKill, new Vector3(0f,0f,0f), this.transform.rotation);		
			}
			if (counter == 1300) Application.LoadLevel("boss1");
		}
	


		position.x += speed;
		this.transform.position = position;
	}
}

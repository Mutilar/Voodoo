using UnityEngine;
using System.Collections;

public class animationCameraPan : MonoBehaviour {
	int counter;
	float pansize = 1;
	float speed;
	public AudioClip talk1;
	public AudioClip talk2;
	public AudioClip talk3;
	public AudioClip talk4;

	public AudioClip grunt1;
	public AudioClip grunt2;
	public AudioClip grunt3;
	public AudioClip grunt4;

	public AudioClip yell1;

	public GameObject location;


	public GameObject fade;

	public GameObject fadeUnfade;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 75; i++) Instantiate (fadeUnfade, new Vector3(0f,0f,0f), this.transform.rotation);		
		Instantiate (location, new Vector3(0f,0f,0f), this.transform.rotation);	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		AudioSource swag = GetComponent<AudioSource> ();

		Vector3 position = this.transform.position;
		counter++;
		if (counter < 650)
		{
			float ranSpeak = Random.value * 650;
			if (counter == 200 || counter == 280 || counter == 420 ) AudioSource.PlayClipAtPoint (talk2, this.transform.position);
			if (counter == 230 || counter == 250 || counter == 450 || counter == 560) AudioSource.PlayClipAtPoint (talk4, this.transform.position);
			speed = -.005f;//position.x -= .005f;
		}
		if (counter ==650)
		{
			position.x = 25f;
			speed = .006f;
		}
		if (counter > 725)
		{
			//speed = .01f;//position.x += .01f;
		}
		if (counter > 875 && counter <= 1000)
		{
			if (counter == 960 || counter == 980) AudioSource.PlayClipAtPoint (grunt2, this.transform.position);
			speed = -.038f;//position.x -= .04f;
			pansize -= .002f;
			Camera.main.orthographicSize = pansize;
		}
		if (counter > 1000)
		{
			if (counter == 1050) AudioSource.PlayClipAtPoint (grunt4, this.transform.position);
			if (counter == 1075) AudioSource.PlayClipAtPoint (grunt3, this.transform.position);
			if (counter == 1100) AudioSource.PlayClipAtPoint (grunt1, this.transform.position);

			if (counter == 1175 || counter == 1200 || counter == 1255) AudioSource.PlayClipAtPoint (talk1, this.transform.position);
			if (counter == 1225 || counter == 1285) AudioSource.PlayClipAtPoint (talk3, this.transform.position);
			speed = -.023f;//position.x -= .04f;
		}
		if (counter == 1350)
		{
			pansize = 1;
			Camera.main.orthographicSize = pansize;
			position.x = -1f;
		}
		if (counter > 1350)
		{
			if (counter == 1500 || counter == 1555)  AudioSource.PlayClipAtPoint (yell1, this.transform.position);
			if (counter == 1520 || counter == 1495) AudioSource.PlayClipAtPoint (talk1, this.transform.position);
			pansize += .001f;
			speed = .02f;//position.x += .04f;
			Camera.main.orthographicSize = pansize;
		}
		if (counter > 1700)
		{
			pansize += .0005f;
			speed = -.023f;//position.x -= .05f;
			Camera.main.orthographicSize = pansize;		
		}
		if (counter > 1900 && counter < 1975)
		{
			Instantiate (fade, new Vector3(0f,0f,0f), this.transform.rotation);		
		}
		if (counter > 2100)
						swag.volume -= .005f;
		if (counter == 2300) {
			Application.LoadLevel("level1");
				}
		position.x += speed;
		this.transform.position = position;

	}
}

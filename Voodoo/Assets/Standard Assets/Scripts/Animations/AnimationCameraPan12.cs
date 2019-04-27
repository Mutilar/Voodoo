using UnityEngine;
using System.Collections;

public class AnimationCameraPan12 : MonoBehaviour {
	public GameObject fade;
	int counter = 0;
	
	public AudioClip talk3;
	public AudioClip talk4;
	public AudioClip grunt4;
	public AudioClip grunt1;
	public AudioClip yell1;
	public GameObject fadeUnfade;
	// Use this for initialization
	void Start () {
		Unfade.resetTimer ();
		for (int i = 0; i < 75; i++)
			Instantiate (fadeUnfade, new Vector3 (0f, 0f, 0f), this.transform.rotation);		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		counter++;
		this.transform.position = new Vector3(this.transform.position.x + .02f, this.transform.position.y, -10f);
		GetComponent<Camera>().orthographicSize -= .001f;
		if (counter >= 425) Instantiate (fade, new Vector3(0f,0f,0f), this.transform.rotation);	
		if (counter == 550)
			Application.LoadLevel ("boss3");


		if (counter == 10) AudioSource.PlayClipAtPoint (yell1, this.transform.position);
		if (counter == 30) AudioSource.PlayClipAtPoint (grunt1, this.transform.position);
		if (counter == 80) AudioSource.PlayClipAtPoint (talk3, this.transform.position);
		if (counter == 120) AudioSource.PlayClipAtPoint (yell1, this.transform.position);
		if (counter == 150) AudioSource.PlayClipAtPoint (grunt4, this.transform.position);
		if (counter == 170) AudioSource.PlayClipAtPoint (talk3, this.transform.position);
		if (counter == 180) AudioSource.PlayClipAtPoint (yell1, this.transform.position);
		if (counter == 210) AudioSource.PlayClipAtPoint (grunt4, this.transform.position);
		if (counter == 240) AudioSource.PlayClipAtPoint (talk4, this.transform.position);
		if (counter == 100) AudioSource.PlayClipAtPoint (yell1, this.transform.position);
		if (counter == 50) AudioSource.PlayClipAtPoint (grunt1, this.transform.position);
		if (counter == 20) AudioSource.PlayClipAtPoint (talk3, this.transform.position);
	}
}

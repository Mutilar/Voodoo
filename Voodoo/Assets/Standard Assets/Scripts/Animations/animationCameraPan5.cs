using UnityEngine;
using System.Collections;

public class animationCameraPan5 : MonoBehaviour {
	public GameObject general;
	public GameObject fade;
	int counter = 0;

	public AudioClip talk3;
	public AudioClip talk4;
	public AudioClip grunt2;
	public AudioClip grunt3;
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
		Vector3 position = this.transform.position;
		position.x -= (position.x - general.transform.position.x) / 40f;
		this.transform.position = position;
		counter++;
		if (counter == 20) AudioSource.PlayClipAtPoint (yell1, this.transform.position);
		if (counter == 50) AudioSource.PlayClipAtPoint (talk4, this.transform.position);
		if (counter == 80) AudioSource.PlayClipAtPoint (talk3, this.transform.position);
		if (counter == 150) AudioSource.PlayClipAtPoint (grunt2, this.transform.position);
		if (counter == 190) AudioSource.PlayClipAtPoint (grunt3, this.transform.position);
		if (counter >= 200) Instantiate (fade, new Vector3(0f,0f,0f), this.transform.rotation);	
		if (counter == 275)
						Application.LoadLevel ("level3");
	}
}

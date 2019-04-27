using UnityEngine;
using System.Collections;

public class animationSurvivor2 : MonoBehaviour {
	int counter;
	float pansize = 1;
	float speed;
	public GameObject fade;
	public GameObject puffRight;
	public AudioClip fireSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector3 position = this.transform.position;
		counter++;
		if (counter < 700) {
			speed = -.002f;//position.x -= .005f;
		}
		if (counter == 700) {
			speed = 0f;
			Animator swag = GetComponent<Animator> ();
			swag.SetBool ("Moving", false);



				}
		if (counter == 1000) {
			speed = .002f;
			Animator swag = GetComponent<Animator> ();
			swag.SetBool ("Moving", true);
			Vector3 scale = this.transform.localScale;
			scale.x = 1;
			this.transform.localScale = scale;
		}
		if (counter == 1400) {
			speed = 0f;
			Animator swag = GetComponent<Animator> ();

			//swag.SetBool ("Moving", false);
			swag.SetBool ("Priest", true);
				}
		if (counter == 1475) {
			AudioSource.PlayClipAtPoint (fireSound, this.transform.position);
			Vector3 scale = this.transform.localScale;
			Vector3 fireLocation = this.transform.position;
			fireLocation.z = 2f;
			fireLocation.x += .2f;
			Instantiate (puffRight, fireLocation, this.transform.rotation);
				}

		if (counter == 1525) {
			AudioSource.PlayClipAtPoint (fireSound, this.transform.position);
			Vector3 scale = this.transform.localScale;
			Vector3 fireLocation = this.transform.position;
			fireLocation.z = 2f;
			fireLocation.x += .2f;
			Instantiate (puffRight, fireLocation, this.transform.rotation);
		}
		//if (counter >= 1550)
		//{
		//	Instantiate (fade, new Vector3(0f,0f,-6f), this.transform.rotation);		
		//	if (counter == 1625) Application.LoadLevel ("level2");
		//}
		/*
				if (counter == 725) {
						position.x = 25f;
				}
				if (counter > 725) {
						speed = .01f;//position.x += .01f;
				}
				if (counter > 875 && counter <= 1000) {
						speed = -.038f;//position.x -= .04f;
						pansize -= .002f;
						Camera.main.orthographicSize = pansize;
				}
				if (counter > 1000) {
						speed = -.023f;//position.x -= .04f;
				}
				if (counter == 1350) {
						pansize = 1;
						Camera.main.orthographicSize = pansize;
						position.x = -1f;
				}
				if (counter > 1350) {
						pansize += .001f;
						speed = .02f;//position.x += .04f;
						Camera.main.orthographicSize = pansize;
				}
				if (counter > 1700) {
						pansize += .0005f;
						speed = -.023f;//position.x -= .05f;
						Camera.main.orthographicSize = pansize;		
				}
				if (counter > 1900 && counter < 1975) {
						Instantiate (fade, new Vector3 (0f, 0f, 0f), this.transform.rotation);		
				}
		
				if (counter == 2150) {
						Application.LoadLevel ("level1");
				}*/
		position.x += speed;
		this.transform.position = position;
	}
}

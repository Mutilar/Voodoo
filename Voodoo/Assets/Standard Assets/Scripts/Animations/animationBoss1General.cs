using UnityEngine;
using System.Collections;

public class animationBoss1General : MonoBehaviour {
	int counter;
	float speed;
	int jumpTimer;
	int shootTimer;
	public GameObject puffRight;
	public GameObject puffLeft;
	public AudioClip fireSound;

	public GameObject fade;

	bool secondCut = false;
	bool dying = false;
	int dieCounter = 0;

	int doubleTapRight = 0;
	int doubleTapLeft = 0;

	bool stop = false;
	int deathCounter = 18;
	float jumpHeight = .075f;
	bool jump = false;
	public AudioClip grunt1;
	public AudioClip grunt2;
	public AudioClip grunt3;
	public AudioClip grunt4;
	// Use this for initialization
	void Start () {
		GetComponent<Animator> ().SetBool ("Selected", true);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
				Vector3 position = this.transform.position;
				Animator swag = GetComponent<Animator> ();

				counter++;
				if (counter == 1) {
						speed = .005f;//position.x -= .005f;
				}
				if (counter >= 400 && counter <= 800) {
					speed = 0f;
					swag.SetBool ("Selected", false);
			if (counter == 500) AudioSource.PlayClipAtPoint (grunt4, this.transform.position);
			if (counter == 550) AudioSource.PlayClipAtPoint (grunt3, this.transform.position);
			if (counter == 700) AudioSource.PlayClipAtPoint (grunt2, this.transform.position);
			if (counter == 800) AudioSource.PlayClipAtPoint (grunt1, this.transform.position);
				}
				if (counter > 875 && counter < 10000) {
			if (doubleTapRight > 0) doubleTapRight--;
			if (doubleTapLeft > 0) doubleTapLeft--;

						if (shootTimer > 0)
								shootTimer --;
						if (jumpTimer > 0)
								jumpTimer --;

						Vector3 scale = this.transform.localScale;
						speed = 0f;

						if (Input.GetKey (KeyCode.D)) {
								
								speed = .0075f;
				if (doubleTapRight > 0) 
				{
					doubleTapRight = 2;
					speed = .0125f;
				}
								//doubled : speed = .0125f;
								scale.x = 1f;
						}
						if (Input.GetKeyUp(KeyCode.D))
						{
							doubleTapRight = 10;
				print ("swag");
						}


						if (Input.GetKey (KeyCode.A)) {
								speed = -.0075f;
				if (doubleTapLeft > 0)
				{
					doubleTapLeft = 2;
					speed = -.0125f;
				}
				//doubled : speed = -.0125f;
								scale.x = -1f;
						}

			if (Input.GetKeyUp(KeyCode.A))
			{
				doubleTapLeft = 10;
				print ("swag");
			}


						if (Input.GetKey (KeyCode.W)) {
				if (jumpTimer==0) jump = true;
								}

			if (jump) {
				//rigidbody2D.AddForce (new Vector2 (0, 150));
				position.y += jumpHeight;
				jumpHeight-=.005f;
				if (jumpHeight <= -.075f)
				{
					jump = false;
					jumpHeight =.075f;
					jumpTimer = 50;
				} 
			}
						
						if (Input.GetKey (KeyCode.Space)) {
								if (shootTimer == 0) {
										AudioSource.PlayClipAtPoint (fireSound, this.transform.position);
										Vector3 fireLocation = this.transform.position;
										fireLocation.z = 2f;
										if (scale.x == 1f) {
												fireLocation.x += .1f;
												Instantiate (puffRight, fireLocation, this.transform.rotation);
										}
										if (scale.x == -1f) {
												fireLocation.x -= .1f;
												Instantiate (puffLeft, fireLocation, this.transform.rotation);
										}
										shootTimer = 75;
								}	
						}
						if (speed == 0f)
								swag.SetBool ("Selected", false);
						else
								swag.SetBool ("Selected", true);
			if (position.x + speed < -1.9f)
				position.x = -1.9f;
						this.transform.localScale = scale;

			if (!secondCut && position.x > 4.75f)
			{
				secondCut = true;
				counter = 10000;
			}
				}
				if (counter >= 10000 && counter < 10500) {
	
			speed = 0;
			swag.SetBool ("Selected", false);
			if (counter == 10050) AudioSource.PlayClipAtPoint (grunt4, this.transform.position);
			if (counter == 10200) AudioSource.PlayClipAtPoint (grunt3, this.transform.position);
			if (counter == 10400) AudioSource.PlayClipAtPoint (grunt1, this.transform.position);
				}
				if (counter == 10500) {
			this.gameObject.tag = "friendlyGO";
			counter = 900;

				}


				position.x += speed;

				this.transform.position = position;

		if (dying) {

			if (!stop) {
				this.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
				Vector3 pos = this.transform.position;
				if (deathCounter > 11)
					pos.Set (pos.x, pos.y + .005f, pos.z);
				else
					pos.Set (pos.x, pos.y - .01f, pos.z);
				this.transform.position = pos;

					//this.transform.Rotate (new Vector3 (0f, 0f, this.transform.rotation.z - 5f));

					this.transform.Rotate (new Vector3 (0f, 0f, this.transform.rotation.z + 5f));
				deathCounter--;
				if (deathCounter == 0)
				{
					stop = true;
				}
			}





			dieCounter++;
			Instantiate (fade, new Vector3(0f,0f,0f), this.transform.rotation);		
			if (dieCounter == 75) Application.LoadLevel ("Boss1");

				}
		}

	void OnTriggerEnter2D (Collider2D other)
	{
		print(other.gameObject.tag);
		if (other.gameObject.tag == "enemy") {
			dying = true;

		}
	}
	public bool getSecondCut()
	{
		return secondCut;
	}


}

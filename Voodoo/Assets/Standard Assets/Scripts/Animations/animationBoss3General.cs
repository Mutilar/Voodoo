using UnityEngine;
using System.Collections;

public class animationBoss3General : MonoBehaviour {
	int counter;
	float speed;
	int jumpTimer;
	int shootTimer;
	public GameObject puffRight;
	public GameObject puffLeft;
	public AudioClip fireSound;

	public AudioClip grunt1;
	public AudioClip grunt2;
	public AudioClip grunt3;
	public AudioClip grunt4;
	
	int doubleTapRight = 0;
	int doubleTapLeft = 0;
	
	bool stop = false;
	int deathCounter = 18;
	float jumpHeight = .075f;
	bool jump = false;
	bool secondCut = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector3 position = this.transform.position;
		Animator swag = GetComponent<Animator> ();
		
		Vector3 scale = this.transform.localScale;
		counter++;
		if (counter == 1) {
			speed = .005f;//position.x -= .005f;
		}
		if (counter >= 400 && counter <= 1600) {
			speed = 0f;
			swag.SetBool ("Selected", false);
			if (counter == 500) AudioSource.PlayClipAtPoint (grunt2, this.transform.position);
			if (counter == 550) AudioSource.PlayClipAtPoint (grunt3, this.transform.position);
			if (counter == 700) AudioSource.PlayClipAtPoint (grunt4, this.transform.position);
			if (counter == 800) AudioSource.PlayClipAtPoint (grunt1, this.transform.position);
			if (counter == 900) AudioSource.PlayClipAtPoint (grunt2, this.transform.position);
			if (counter == 1200) AudioSource.PlayClipAtPoint (grunt2, this.transform.position);
			if (counter == 1400) AudioSource.PlayClipAtPoint (grunt1, this.transform.position);
			if (counter == 1500) AudioSource.PlayClipAtPoint (grunt4, this.transform.position);
		}
		if (counter == 1650)
						scale.x = -1f;
		if (counter == 2000)
						scale.x = 1f;
		if (counter > 2000 && counter < 10000) {
			if (doubleTapRight > 0) doubleTapRight--;
			if (doubleTapLeft > 0) doubleTapLeft--;
			
			if (shootTimer > 0)
				shootTimer --;
			if (jumpTimer > 0)
				jumpTimer --;

			speed = 0f;
			
			if (Input.GetKey (KeyCode.D)) {
				
				speed = .015f;
				if (doubleTapRight > 0) 
				{
					doubleTapRight = 2;
					speed = .03f;
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
				speed = -.015f;
				if (doubleTapLeft > 0)
				{
					doubleTapLeft = 2;
					speed = -.03f;
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
						fireLocation.x += .2f;
						Instantiate (puffRight, fireLocation, this.transform.rotation);
					}
					if (scale.x == -1f) {
						fireLocation.x -= .2f;
						Instantiate (puffLeft, fireLocation, this.transform.rotation);
					}
					shootTimer = 75;
				}	
			}
			if (speed == 0f)
				swag.SetBool ("Selected", false);
			else
				swag.SetBool ("Selected", true);
			

			
			if (!secondCut && position.x > 4.75f)
			{
				secondCut = true;
				counter = 10000;
			}
		}
		if (counter == 10000) {
			speed = 0;
			swag.SetBool ("Selected", false);
		}
		if (counter == 10500) {
			counter = 900;
			
		}
		
		
		position.x += speed;
		if (position.x > 1.4f)
						position.x = 1.4f;
		if (position.x < -2.4f) 
						position.x = -2.4f;
		this.transform.position = position;
		this.transform.localScale = scale;
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "enemy" || other.gameObject.tag.Equals("projectile")) {
		
			Application.LoadLevel ("Boss3");
			Destroy (this.gameObject);
		}
	}
	
	
}

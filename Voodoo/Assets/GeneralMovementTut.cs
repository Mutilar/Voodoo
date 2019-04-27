using UnityEngine;
using System.Collections;

public class GeneralMovementTut : MonoBehaviour {
	int counter;
	float speed;
	bool moving;
	int jumpTimer;
	bool stop = false;
	int deathCounter = 18;
	float jumpHeight = .075f;
	bool jump = false;
	int shootTimer;
	public GameObject puffRight;
	public GameObject puffLeft;
	public AudioClip fireSound;

	int doubleTapRight = 0;
	int doubleTapLeft = 0;

	public GameObject toggler;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (toggler.GetComponent<Demo> ().cameraSnap) {
			this.GetComponent<CreatePlayers>().enabled = false;
			if (jumpTimer > 0)
				jumpTimer --;
			if (shootTimer > 0)
				shootTimer --;
						Vector3 position = this.transform.position;
						Animator swag = GetComponent<Animator> ();
						Vector3 scale = this.transform.localScale;

						speed = 0f;
			if (doubleTapRight > 0) doubleTapRight--;
			if (doubleTapLeft > 0) doubleTapLeft--;
			
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
				GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, 150));
				jump = false;
				jumpTimer = 50;
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


						position.x += speed;
						this.transform.position = position;
				}
	}
}

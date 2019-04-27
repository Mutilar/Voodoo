using UnityEngine;
using System.Collections;


/*** BRIAN HUNGERMAN ***/


public class Movement : MonoBehaviour
{
	public static int numberDead = 0;
	float jumpHeight;
	bool jumping = false;
	float jumpWait;
	bool tracking;
	Vector3 clickPoint;
	bool selected = true;
	bool moveRight = false;
	public bool shooting = false;
	int shootDelay = 10;
	public bool meele = false;
	int swingDelay = 10;
	public GameObject puffRight;
	public AudioClip fire1;
	public AudioClip fire2;
	public AudioClip fire3;
	public AudioClip hit1;
	public AudioClip hit2;
	float delay;
	public float speed;
	public float height;

	public GameObject swinger;

	public GameObject explosionFriend;


	//DAVID
	bool right = false;
	bool stop=false,died=false;
	int counter=18;


	public static int getDeaths()
	{
		return numberDead;
	}

	void Start()
	{
		clickPoint = new Vector2 (this.transform.position.x + (Random.value * 10f) + 1f, this.transform.position.y);
		//Fastest is ~ .01
		//Add/Subtract up to .0025

		speed += (Random.value / 200) - .0025f;
		//print (speed);
	}



	void FixedUpdate ()
	{

		if (this.gameObject.tag == "magicDead") {
			Instantiate (explosionFriend, new Vector2(this.transform.position.x + .1f, this.transform.position.y + .08f), this.transform.rotation);					
			Destroy (this.gameObject);

				}

		else if (this.gameObject.tag == "dead") {
						if (!died)
								die ();
						if (!stop) {

				//Animation for falling down dead
				this.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
								Vector3 pos = this.transform.position;
								if (counter > 11)
										pos.Set (pos.x, pos.y + .01f, pos.z);
								else
										pos.Set (pos.x, pos.y - .02f, pos.z);
								this.transform.position = pos;
								if (right)
										this.transform.Rotate (new Vector3 (0f, 0f, this.transform.rotation.z - 5f));
								else
										this.transform.Rotate (new Vector3 (0f, 0f, this.transform.rotation.z + 5f));
								counter--;
								if (counter == 0)
				{
										stop = true;
					Destroy (this.gameObject,10f);
								Destroy (this.GetComponent<Movement> ());
				}
						} 
				} else {
						//method
		 
						Vector3 position = this.transform.position;
						Quaternion playerRotation = this.transform.rotation;
						Animator swag = GetComponent<Animator> ();
						Vector3 scale = this.transform.localScale;
				

					
						//Getting location to go to by mouse click
						if (selected) {
								if (Input.GetMouseButton (0)) {

										//ADD A LIMIT ON THE BOTTOM OF THE SCREEN SO SPAWNING PEOPLE DOES NOT SET POSITION
					if (Input.mousePosition.y > 240)
										clickPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
								}
								if (position.x < clickPoint.x)
										position.x += speed;
			
								if (position.x > clickPoint.x)
										position.x -= speed;
							//Check to shoot : if people are in front of you
								if (shooting && shootDelay <= 0) {
										RaycastHit2D shooter = Physics2D.Raycast (new Vector2 (transform.position.x + height, transform.position.y), new Vector2 (1, 0), 5f);
										//Debug.DrawRay(new Vector2(transform.position.x - height, transform.position.y), new Vector2 (-5f, 0));
										if (shooter.collider != null)
										if (shooter.collider.gameObject.tag == "enemy")
												shoot ();
								} else if (shooting)
										shootDelay--;

							//Melee: same with ranged except a shorter checking range
							//Yes, variable spelt wrong, cry about it :)
								if (meele && swingDelay <= 0) {
										RaycastHit2D shoot = Physics2D.Raycast (new Vector2 (transform.position.x + height, transform.position.y), new Vector2 (1, 0), .1f);
										//Debug.DrawRay(new Vector2(transform.position.x - height, transform.position.y), new Vector2 (-.1f, 0));
										if (shoot.collider != null)
										if (shoot.collider.gameObject.tag == "enemy")
												swing (shoot.collider.gameObject);
								} else if (meele)
										swingDelay--;
						
								//Checking if person needs to go down (fall) due to nothing below him
								RaycastHit2D hit = Physics2D.Raycast (new Vector2 (transform.position.x, transform.position.y - height), new Vector2 (0, -1f), .01f);
								//Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - height), new Vector2 (0, -.02f));
								if (hit.collider == null)
										position.y -= .005f;
								else if (hit.collider.gameObject.tag == "environment")
										position.y += .005f;
		
								if (position.x - clickPoint.x > .1f)
								if (scale.x > 0)
										scale.x = -1;
								if (clickPoint.x - position.x > .1f)
								if (scale.x < 0)
										scale.x = 1;
						}

						playerRotation.z = 0;
						swag.SetBool ("Selected", selected);

		
						this.transform.rotation = playerRotation;
						this.transform.position = position;
						this.transform.localScale = scale;
				}
	}
	

	public void shoot ()
	{
		//Shooting
		shootDelay = (Mathf.RoundToInt ((Random.value * 100) + 50));
		float ran = Random.value;
		if (ran < .33f) AudioSource.PlayClipAtPoint (fire1, this.transform.position);
		else if (ran < .66f) AudioSource.PlayClipAtPoint (fire2, this.transform.position);
		else AudioSource.PlayClipAtPoint (fire3, this.transform.position);
		Vector3 scale = this.transform.localScale;
		Vector3 fireLocation = this.transform.position;
		fireLocation.z = 2f;
		fireLocation.x += .2f;
		Instantiate (puffRight, fireLocation, this.transform.rotation);
				
	}

	public void swing(GameObject enemy)
	{
		//Animation of sword swing
		swingDelay = (Mathf.RoundToInt ((Random.value * 30) + 10));
		Instantiate (swinger, new Vector2(this.transform.position.x +.2f, this.transform.position.y + .1f), this.transform.rotation);
		enemy.gameObject.tag = "dead";
		float ran = Random.value;
		if (ran < .5f) AudioSource.PlayClipAtPoint (hit1, this.transform.position);
			else AudioSource.PlayClipAtPoint (hit2, this.transform.position);
			

		//Destroy (enemy);
		//Destroy (this.gameObject);
		//Instantiate the swing animation
	}

	//DAVID
	void die ()
	{
		//Death: setting values and stuff
		float ran = Random.value;
		if (ran < .5f) AudioSource.PlayClipAtPoint (hit1, this.transform.position);
		else AudioSource.PlayClipAtPoint (hit2, this.transform.position);
		numberDead++;
		string[] types = {
			"Rigidbody2D",
			"CircleCollider2D",
			"CircleCollider2D",
			"Animator"
		};//removes these components
		for (int i=0; i!=15; i++) {
						if (this.gameObject.GetComponent<CircleCollider2D> () != null)
								Destroy (this.gameObject.GetComponent<CircleCollider2D> ());
						if (this.GetComponent (types [i % types.GetLength (0)]) != null)
								Destroy (this.GetComponent (types [i % types.GetLength (0)]));
				}
		if (Random.value > .5f) {
			right = true;
			this.transform.Rotate (new Vector3 (0f, 0f, 355f));
		}
		died = true;
		
		
	}







}
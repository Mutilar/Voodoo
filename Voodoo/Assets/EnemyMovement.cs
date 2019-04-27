using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
	public static int numberDead = 0;
	public bool moveEnabled;
	bool jumpEnabled;
	public int delayMovement;
	int delayCounter;
	public float speed;

	public GameObject puff;
	public AudioClip fire1;
	public AudioClip fire2;
	public AudioClip fire3;
	public AudioClip hit1;
	public AudioClip hit2;


	public bool shooting;
	int shootDelay = 10;
	public bool meele;
	int swingDelay = 10;
	public float height = .125f;
	bool right = false;
	bool stop=false,died=false;
	int counter=18;

	public GameObject swinger;

	public static int getDeaths()
	{
		return numberDead;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{	
		if (this.gameObject.tag == "dead") {
						if (!died)
								die ();
						if (!stop) {
								this.gameObject.layer = LayerMask.NameToLayer ("Ignore Raycast");
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
								if (counter == 0) {
										stop = true;
					Destroy (this.gameObject,10f);
										Destroy (this.GetComponent<EnemyMovement> ());
								}
						} 
				} else {			



						Animator swag = GetComponent<Animator> ();
						swag.SetBool ("Selected", moveEnabled);
						Vector3 position = this.transform.position;
						Quaternion playerRotation = this.transform.rotation;

						//	if (playerRotation.z != 0)
						//		playerRotation.z += ((0 - playerRotation.z) / 2f);		
						if (moveEnabled) {
								position.x -= speed;

								if (shooting && shootDelay <= 0) {
										RaycastHit2D shooter = Physics2D.Raycast (new Vector2 (transform.position.x - height, transform.position.y), new Vector2 (-1, 0f), 2f);
										//Debug.DrawRay(new Vector2(transform.position.x - height, transform.position.y), new Vector2 (-5f, 0));
										if (shooter.collider != null)
										if (shooter.collider.gameObject.tag == "friendly")
												shoot ();
								} else if (shooting)
										shootDelay--;
								if (meele && swingDelay <= 0) {
										RaycastHit2D shoot = Physics2D.Raycast (new Vector2 (transform.position.x - height, transform.position.y), new Vector2 (-1, 0), .1f);
										//Debug.DrawRay(new Vector2(transform.position.x - height, transform.position.y), new Vector2 (-.1f, 0));
										if (shoot.collider != null)
										if (shoot.collider.gameObject.tag == "friendly")
												swing (shoot.collider.gameObject);
								} else if (meele)
										swingDelay--;
								RaycastHit2D hit = Physics2D.Raycast (new Vector2 (transform.position.x, transform.position.y - height), new Vector2 (0, -1f), .01f);
								//Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - height), new Vector2 (0, -.02f));
								if (hit.collider == null)
										position.y -= .005f;
								else if (hit.collider.gameObject.tag == "environment")
										position.y += .005f;
								else
										position.y -= .005f;
						} else {
								delayCounter++;
								if (delayCounter == delayMovement)
										moveEnabled = true;
						}
						this.transform.rotation = playerRotation;
						this.transform.position = position;
				}
	}
	
	public void shoot()
	{
		shootDelay = (Mathf.RoundToInt ((Random.value * 100) + 50));
		float ran = Random.value;
		if (ran < .33f) AudioSource.PlayClipAtPoint (fire1, this.transform.position);
		else if (ran < .66f) AudioSource.PlayClipAtPoint (fire2, this.transform.position);
		else AudioSource.PlayClipAtPoint (fire3, this.transform.position);
		Vector3 fireLocation = this.transform.position;
		fireLocation.x -= .2f;
		fireLocation.z = 2f;
		Instantiate (puff, fireLocation, this.transform.rotation);
	}

	public void swing(GameObject friend)
	{
		swingDelay = (Mathf.RoundToInt ((Random.value * 30) + 10));
		Instantiate (swinger, new Vector2(this.transform.position.x -.2f, this.transform.position.y + .1f), this.transform.rotation);
		friend.gameObject.tag = "dead";
	

		//Destroy (this.gameObject);
		//Instantiate the swing animation
	}

		//DAVID
		void die ()
		{
		numberDead++;
		float ran = Random.value;
		if (ran < .5f) AudioSource.PlayClipAtPoint (hit1, this.transform.position);
		else AudioSource.PlayClipAtPoint (hit2, this.transform.position);
			string[] types = {
				"Rigidbody2D",
				"Circle Collider2D",
				"Circle Collider2D",
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



	void OnTriggerEnter2D(Collider2D other)
	{
	//	if (meele) if (other.gameObject.tag == "friendly") Destroy(other.gameObject);
	}
}


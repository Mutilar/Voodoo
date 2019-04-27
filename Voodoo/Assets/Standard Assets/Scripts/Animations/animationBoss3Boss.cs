using UnityEngine;
using System.Collections;

public class animationBoss3Boss : MonoBehaviour {
	int counter = 0;
	int spawnCounter = 0;
	float waver = 0f;
	bool waveToggle = false;
	float randomPosition = 0f;
	int life = 5;

	// Use this for initialization
	public GameObject superPuff;
	public GameObject targetedPuff;
	public GameObject pink2;
	public GameObject explosionLarge;
	public GameObject explosion;
	public AudioClip part1Song;

	public GameObject fade;

	bool part1 = false;
	bool dying = false;
	bool stop = false;
	int dieCounter = 20;
	int rot = 10, dir = 5;
	void Start () {
		this.GetComponent<Animator> ().SetBool ("Selected",false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		counter++;

		if (part1) {
			GetComponent<AudioSource>().volume -= .01f;

						if (rot == 90)
								dir = -5;
						if (rot == -90)
								dir = 5;
						rot += dir;
						Quaternion swag = Quaternion.Euler (new Vector3 (0, 0, (float)rot));
						if (Random.value < .05f)
								Instantiate (explosion, new Vector2 (this.transform.position.x, this.transform.position.y), swag);
				}

		if (dying) {
			Instantiate (fade, new Vector3(0f,0f,0f), this.transform.rotation);		
			dieCounter--;
				if (dieCounter == 10) Instantiate (explosionLarge,  new Vector2 (this.transform.position.x, this.transform.position.y), this.transform.rotation);
				if (dieCounter == -55) Application.LoadLevel("finalCutscene");

		 

				}


		if (counter >= 1350 && counter <= 1450) {
			this.transform.position = new Vector2 (this.transform.position.x, this.transform.position.y + .01f);
		}
		if (counter > 1450 && counter < 3000) {
			this.transform.position = new Vector2 (this.transform.position.x, 1.725f + (Mathf.Sin (waver) / 10));
			waver+=.1f;
			if (counter < 1600)
			{
				this.transform.position = new Vector2 (this.transform.position.x - .01f, this.transform.position.y);
			}
			if (counter == 1600)
				Instantiate(superPuff,this.transform.position,this.transform.rotation);
			

		}
		if (counter > 2050 && counter < 3000) {
	
			if (counter % 50 == 0)
			{
				GameObject general = GameObject.FindGameObjectWithTag("friendlyGO");
		
				randomPosition = general.transform.position.x + (Random.value * 5f) - 2.5f;
			}
			if (counter % 75 == 0)
				Instantiate(targetedPuff,this.transform.position,this.transform.rotation);
			this.transform.position = new Vector2 (this.transform.position.x + (randomPosition - this.transform.position.x) / 50, this.transform.position.y);

			//random position to go to between x and xx
			//after, go to the second hole, set down "recharging"
			//Send out units, once hit, go back up

				}
		if (counter > 3000 && counter < 3500) {
			randomPosition = 1.66f;
			this.transform.position = new Vector2 (this.transform.position.x + (randomPosition - this.transform.position.x) / 50, this.transform.position.y);
			if (transform.position.y > .715f) this.transform.position = new Vector2 (this.transform.position.x, this.transform.position.y + (.715f - this.transform.position.y) / 50);
		
		}
		if (counter == 3500)	this.transform.position = new Vector2 (1.66f, .715f);
		if (counter > 3000 || part1)
		{

			if (counter % 150 == 0) 
			{
				Instantiate (pink2, new Vector3(3f,.82f,0), this.transform.rotation);
				waveToggle = true;
			}
			if (waveToggle)
			{
				spawnCounter++;
				if (spawnCounter % 15 == 0)
				{Instantiate (pink2, new Vector3(3f,.82f,0), this.transform.rotation);
				if (Random.value < .33f)
				{
					waveToggle = false;
					spawnCounter = 0;
				}
			}
			}
		}


		}
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "projectile") {
			print (life);	
			life--;
			Destroy(other.gameObject);
			if (life == 0)
			{

				if (!part1)
				{
					AudioSource.PlayClipAtPoint (part1Song, this.transform.position);

				
					part1 = true;
					life = 5;
					counter = 2050;
				}
				else 
				{
					dying = true;


				}


				Instantiate (explosionLarge,  new Vector2 (this.transform.position.x, this.transform.position.y + .5f), this.transform.rotation);
			}
		}
	}

	}


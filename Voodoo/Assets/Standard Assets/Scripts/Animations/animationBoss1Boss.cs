using UnityEngine;
using System.Collections;

public class animationBoss1Boss : MonoBehaviour {

	int counter;
	float speed;

	bool secondAttack = false;
	int secondCounter = 0;
	
	public GameObject pink1;
	public GameObject swinger;
	public GameObject throwSword;

	public AudioClip grunt1;
	public AudioClip grunt2;
	public AudioClip grunt3;
	public AudioClip grunt4;

	public GameObject explosion;

	public GameObject fade;
	int life = 6;
	bool dying = false;
	int deathCounter = 0;
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
		//if (counter < 800) {
	//	speed = .005f;//position.x -= .005f;
		//}
		if (counter == 800) {
			speed = .01f;
			swag.SetBool ("Moving", true);
			scale.x = 1f;
		}
		if (counter == 1200) {
			speed = 0f;
			swag.SetBool ("Moving", false);
			scale.x = -1f;


				}
		if (counter >= 2000)
		{
			if (!secondAttack)
			{
				Debug.DrawRay(new Vector2(this.transform.position.x -.3f, this.transform.position.y), new Vector2(-2f,0));
				RaycastHit2D hit = Physics2D.Raycast ( new Vector2(this.transform.position.x -.3f, this.transform.position.y), new Vector2 (-1, 0), 2f, Physics2D.DefaultRaycastLayers);
			if (hit.collider != null)
			{
				if (hit.collider.gameObject.tag == "friendlyGO")
				{
					swag.SetBool ("Moving", true);
					secondAttack = true;
			
				}
				print (hit.collider.gameObject.tag);
			}
			}
		}
		if (secondAttack) {
			print ("working");
			secondCounter++;
			if (secondCounter % 100 == 0)

			{
				if (Random.value < .5f)
				{
				//throwing
				Instantiate (swinger, new Vector2(this.transform.position.x -.2f, this.transform.position.y + .1f), this.transform.rotation);
				Instantiate (throwSword, new Vector2(this.transform.position.x -.2f, this.transform.position.y + .1f), this.transform.rotation);

				}
				else
				Instantiate (pink1, new Vector3(7.5f,.5f,0), this.transform.rotation);
			}

			if (dying) 
			{
				Destroy(this.gameObject.GetComponent<Animator> ());
				Destroy(this.gameObject.GetComponent<SpriteRenderer> ());

				deathCounter++;
				if (deathCounter % 5 == 0)
				{
					Instantiate (explosion, new Vector2(this.transform.position.x + (deathCounter / 50f), this.transform.position.y), this.transform.rotation);
					Instantiate (explosion, new Vector2(this.transform.position.x - (deathCounter / 50f), this.transform.position.y), this.transform.rotation);
				}
				if (deathCounter >= 20)
				{
					if (deathCounter % 5 == 0)
					{
						Instantiate (explosion, new Vector2(this.transform.position.x + ((deathCounter - 20) / 50f), this.transform.position.y), this.transform.rotation);
						Instantiate (explosion, new Vector2(this.transform.position.x - ((deathCounter - 20) / 50f), this.transform.position.y), this.transform.rotation);
					}

				}
				if (deathCounter >= 25)
				{
					Instantiate (fade, new Vector3(0f,0f,0f), this.transform.rotation);		

				}
				if (deathCounter == 100) Application.LoadLevel("cutscene6");

			}

				}


//		general.GetComponent<"animationBoss1General">()
		position.x += speed;
		this.transform.position = position;
		this.transform.localScale = scale;
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		print(other.gameObject.tag);
		if (other.gameObject.tag == "projectile") {
			Destroy (other.gameObject);
			Instantiate (explosion, this.transform.position, this.transform.rotation);
			life--;
			if (life == 0)
			{
				dying = true;
			}//death

		}
	}
}

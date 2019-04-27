using UnityEngine;
using System.Collections;

public class animationFarmer : MonoBehaviour {
	int counter;
	int rayCounter = 0;
	int direction = 1;
	float heal;
	public GameObject explosion;

	public AudioClip hit1;
	public AudioClip hit2;
	// Use this for initialization
	void Start () 
	{
		heal = Random.Range(2f,4f);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		rayCounter++;
		counter++;
		if (counter < 1500)
		{
			Vector3 scale = this.transform.localScale;
			
			Vector3 position = this.transform.position;
			position.x += direction * .01f;
			this.transform.position = position;
			if (counter % 50 == 0)
			{
				if (Random.Range(0f,1f) < .5f) direction = 1;
				else direction = -1;
				
				if (position.x < 0f) direction = 1;
				if (position.x > 1.25f) direction = -1;
				
				scale.x = direction;
			}
			this.transform.localScale = scale;
			
		}
		else if (counter >= 1500)
		{
		if (rayCounter >= 2)
		{
			RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (1, 0), .5f, Physics2D.DefaultRaycastLayers);
			if (hit.collider != null) {
			if (hit.collider.gameObject.tag == "enemy") 
			{
				heal--;
				if (heal <= 0)	
						{
				Destroy(this.gameObject);
							float ranVal = Random.value;
							float ran = Random.value;
							if (ran < .5f) AudioSource.PlayClipAtPoint (hit1, this.transform.position);
							else AudioSource.PlayClipAtPoint (hit2, this.transform.position);

							Instantiate (explosion, new Vector2(this.transform.position.x + .1f, this.transform.position.y + .08f), this.transform.rotation);					

						}
				
			}
				}
			rayCounter = 0;
		}
			Vector3 scale = this.transform.localScale;
			scale.x = 1f;
			this.transform.localScale = scale;
			Vector3 position = this.transform.position;
			position.x += .02f;
			this.transform.position = position;
		}
	}	
}

using UnityEngine;
using System.Collections;

public class GeneralMovement : MonoBehaviour {

	int counter;
	float speed;
	bool moving;
	int jumpTimer;
	int shootTimer;
	public GameObject puffRight;
	public GameObject puffLeft;
	public AudioClip fireSound;
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
		if (jumpTimer > 0)
						jumpTimer --;
		if (shootTimer > 0)
			shootTimer --;
		if (counter == 900) {
			moving = true;
		}
		if (moving) {
			speed = 0f;

			if (Input.GetKey(KeyCode.D))
			    {
				speed = .0075f;
				scale.x = 1f;
				}
			if (Input.GetKey(KeyCode.A))
			    {
				speed = -.0075f;
				scale.x = -1f;
			}
			if (Input.GetKey(KeyCode.W))
			    {
				if (jumpTimer == 0) 
				{
					GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, 150));
				jumpTimer = 50;
				}				
			}

			if (Input.GetKey(KeyCode.Space))
			{
				if (shootTimer == 0) 
				{
					AudioSource.PlayClipAtPoint (fireSound, this.transform.position);
					Vector3 fireLocation = this.transform.position;
					fireLocation.x += .2f;
					fireLocation.z = 2f;
				//	Instantiate (puff, fireLocation, this.transform.rotation);
					shootTimer = 75;
				}	

			}



			if (speed == 0f) swag.SetBool("Selected",false);
			else swag.SetBool("Selected",true);
		
		this.transform.localScale = scale;
		position.x += speed;
		this.transform.position = position;
	}
}
}
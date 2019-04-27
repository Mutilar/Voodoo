using UnityEngine;
using System.Collections;

public class animationRaider : MonoBehaviour {
	int counter;
	public GameObject puff;
	public AudioClip fireSound;
	public bool mage1;
	public bool mage2;
	float speed;
	// Use this for initialization
	void Start () 
	{
		GetComponent<Animator> ().SetBool ("Moving", true);
		 speed = Random.Range(.02f,.03f);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		
		counter++;
		if (counter <= 1600)
		{
			Vector3 position = this.transform.position;
			position.x -= .023f;
			this.transform.position = position;
		}
		if (counter > 1600)
		{
		if (mage1) if (counter == 1700) 
		{
		AudioSource.PlayClipAtPoint (fireSound, this.transform.position);
		Vector3 fireLocation = this.transform.position;
					fireLocation.z = -1f;
		fireLocation.x -= .2f;
		Instantiate (puff, fireLocation, this.transform.rotation);	
		}
		
		if (mage2) if (counter == 1750)
		{
					AudioSource.PlayClipAtPoint (fireSound, this.transform.position);
		Vector3 fireLocation = this.transform.position;
			fireLocation.z = -1f;
		fireLocation.x -= .2f;
		Instantiate (puff, fireLocation, this.transform.rotation);	
		}
		if (mage1) if (counter == 1775) 
		{
		AudioSource.PlayClipAtPoint (fireSound, this.transform.position);
		Vector3 fireLocation = this.transform.position;
					fireLocation.z = -1f;
		fireLocation.x -= .2f;
		Instantiate (puff, fireLocation, this.transform.rotation);	
		}

			Vector3 position = this.transform.position;
			position.x -= speed;
			this.transform.position = position;
		}
		/*
		//if (counter == 150)
		//{
		//	
			
		
			Animator swag = GetComponent<Animator> ();
			swag.SetBool ("Selected", false);
		}
		if (counter >= 725)
		{	
			Vector3 scale = this.transform.localScale;
			scale.x = 1f;
			this.transform.localScale = scale;
			Vector3 position = this.transform.position;
			position.x += .02f;
			this.transform.position = position;
			
			Animator swag = GetComponent<Animator> ();
			swag.SetBool ("Selected", true);
		}*/
	}
	
}

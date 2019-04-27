using UnityEngine;
using System.Collections;

public class animationScout : MonoBehaviour {
	int counter;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		
		counter++;
		if (counter < 90)
		{
			Vector3 position = this.transform.position;
			position.x -= .02f;
			this.transform.position = position;
		}
		if (counter == 150)
		{
			
			
		
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
		}
	}
}

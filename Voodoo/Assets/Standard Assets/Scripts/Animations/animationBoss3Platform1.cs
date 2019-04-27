using UnityEngine;
using System.Collections;

public class animationBoss3Platform1 : MonoBehaviour {

	float waver = 0f;
	int counter = 0;
	public GameObject explosionLarge;
	public GameObject boss3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		counter++;
		if (counter >= 1350 && counter <= 1450) {
			if (counter == 1350)
				Instantiate (explosionLarge,  new Vector2 (this.transform.position.x, this.transform.position.y + .5f), this.transform.rotation);
			this.transform.position = new Vector2 (boss3.transform.position.x +.1f , boss3.transform.position.y-.395f);
				}
		
		if (counter > 1450) {
			this.transform.position = new Vector2 (boss3.transform.position.x +.1f, boss3.transform.position.y-.395f);
		}
	
	
	
	}
	
}

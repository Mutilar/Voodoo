using UnityEngine;
using System.Collections;

public class General : MonoBehaviour 
{
	//public gameObject heart1;
	//public gameObject heart2;
	///public gameObject heart3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "enemy") 
		{
			
			Destroy (other.gameObject);
			//life--;
			//if (life == 0) print ("dead");	
		}
	}
	void updateHearts()
	{
		
	}
}

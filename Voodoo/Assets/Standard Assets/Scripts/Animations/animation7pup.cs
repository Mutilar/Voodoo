using UnityEngine;
using System.Collections;

public class animation7pup : MonoBehaviour {
	int counter = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		counter++;
		if (counter >= 900)		
		{
			this.transform.position = new Vector2(this.transform.position.x - .002f, this.transform.position.y);
			if (counter ==1600) Destroy (this.gameObject);
		}
	}
}

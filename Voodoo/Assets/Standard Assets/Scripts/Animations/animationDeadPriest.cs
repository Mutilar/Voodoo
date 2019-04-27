using UnityEngine;
using System.Collections;

public class animationDeadPriest : MonoBehaviour {
	int counter;
	public GameObject explosionEnemy;
	public GameObject swag;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector3 position = this.transform.position;
		counter++;

		if (counter == 1400) {
			Destroy(this.gameObject);
			Vector3 superswag = swag.transform.position;
			superswag.z -= 5f;
			Instantiate (explosionEnemy,superswag, swag.transform.rotation);
				}
}
}

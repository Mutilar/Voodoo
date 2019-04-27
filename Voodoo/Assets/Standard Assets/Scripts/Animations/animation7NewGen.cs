using UnityEngine;
using System.Collections;

public class animation7NewGen : MonoBehaviour {
	int counter = 0;
	public GameObject newGeneral;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		counter++;
			if (counter <600)
		{
			this.transform.position = new Vector2(this.transform.position.x + .002f, this.transform.position.y);

		}
		if (counter == 600)
						GetComponent<Animator> ().SetBool ("Selected", false);
		if (counter > 800) {
			GetComponent<Animator> ().SetBool ("Selected", true);
			this.transform.position = new Vector2(this.transform.position.x + .002f, this.transform.position.y);
			print (counter);
			if (counter == 1600)
			{
				Instantiate(newGeneral,this.transform.position,this.transform.rotation);
				Destroy(this.gameObject);

			}
				}
	}
}

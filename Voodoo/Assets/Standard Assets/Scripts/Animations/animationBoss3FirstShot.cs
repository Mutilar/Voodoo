using UnityEngine;
using System.Collections;

public class animationBoss3FirstShot : MonoBehaviour {
	int counter = 0;
	int explosionCounter = 0;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		counter++;
		if (counter < 100) {
			this.transform.position = new Vector2 (this.transform.position.x, this.transform.position.y + .05f);
				}
		if (counter == 100)
						this.transform.position = new Vector2 (-2.25f, 5f);
		if (counter > 100 && counter < 185)
		{
			this.transform.position = new Vector2 (this.transform.position.x, this.transform.position.y-.05f);
	}
		if (counter == 185) {
			Destroy(this.GetComponent<SpriteRenderer>());
				}
		if (counter > 185 && counter < 250)
		{
			explosionCounter++;
			if (explosionCounter % 5 == 0)
			{
				Instantiate (explosion, new Vector2(this.transform.position.x + (explosionCounter / 40f), this.transform.position.y), this.transform.rotation);
				Instantiate (explosion, new Vector2(this.transform.position.x - (explosionCounter / 40f), this.transform.position.y), this.transform.rotation);
			}

		}
}
}
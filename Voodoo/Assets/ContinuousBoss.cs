using UnityEngine;
using System.Collections;

public class ContinuousBoss : MonoBehaviour {
	int counter =0;
	public GameObject general;
	Vector3 position;
	public int difficulty = 0;
	// Use this for initialization
	void Start () 
	{
		difficulty = LevelSaver.getDiff();
		//LevelSaver swagg = new LevelSaver();
		GetComponent<Animator> ().SetInteger ("Type", difficulty);

		position = this.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		
		//LevelSaver swagg = new LevelSaver();
		//print (new LevelSaver().getJaggedness() + "tempjag?");
		//position.x += .002f;
		//every 100 is .2f
		//print (new LevelSaver ().getContinuousDifficulty ());

		counter++;
		position = this.transform.position;

		RaycastHit2D hit = Physics2D.Raycast (new Vector2 (transform.position.x, transform.position.y - .18f), new Vector2 (0, -1f), .01f);
		//Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - height), new Vector2 (0, -.02f));
		if (hit.collider == null)
			position.y -= .005f;
		else if (hit.collider.gameObject.tag == "environment")
			position.y += .005f;


		if (counter <= 300) {
			Vector3 scale = this.transform.localScale;
			scale.x = -1f;
			this.transform.localScale = scale;
			GetComponent<Animator> ().SetBool ("Moving", false);

				} else if (counter <= 500) {
			Vector3 scale = this.transform.localScale;
			scale.x = 1f;
			this.transform.localScale = scale;
			GetComponent<Animator> ().SetBool ("Moving", true);

		
			position.x += .005f;

			if (counter == 500) {
				counter = 0;
			}
				}

		this.transform.position = position;
		// (this.transform.position.x - general.transform.position.x);


	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "friendly") {
			other.gameObject.tag = "dead";

		}
}
}

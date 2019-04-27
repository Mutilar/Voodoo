using UnityEngine;
using System.Collections;

public class EnemyGeneral : MonoBehaviour {
	bool run = false;
	public string levelType = "";
	int counter = 0;
	public GameObject fade;
	public GameObject general;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (run) {
			Vector3 scale = this.transform.localScale;
			Vector3 position = this.transform.position;
			scale.x = 1f;
			position.x += .01f;
			Animator swag = GetComponent<Animator> ();
			AudioSource swagg = general.GetComponent<AudioSource> ();
			swagg.volume -= .013f;
			swag.SetBool ("Selected", true);
			counter++;
			Instantiate (fade, new Vector3(0f,0f,0f), this.transform.rotation);		
			if (counter == 75) Application.LoadLevel (levelType);
			this.transform.localScale = scale;
			this.transform.position = position;
				}
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "friendly") {
			run = true;
		}
	}
}

using UnityEngine;
using System.Collections;

public class PuffPhysics : MonoBehaviour {

	public bool friendlyPuff;
	public AudioClip fireSound;
	public bool movingRight;

	public GameObject explosionEnemy;
	public GameObject explosionFriend;

	
	int rot = 10, dir = 5;


	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 1f);
		Quaternion swag;
		if (friendlyPuff) {
						swag = Quaternion.Euler (new Vector3 (0, 0, 90f));
			rot = 90;
				} else {
						swag = Quaternion.Euler (new Vector3 (0, 0, -90f));
			rot = -90;
				}
		this.transform.rotation = swag;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 location = this.transform.position;
		if (movingRight) location.x += .04f;
		else location.x -= .04f;
		this.transform.position = location;

		if (!friendlyPuff) {

						if (rot == -70)
								dir = -2;
						if (rot == -110)
								dir = 2;
				} else {
			if (rot == 70)
				dir = 2;
			if (rot == 110)
				dir = -2;
				}
						rot += dir;
						Quaternion swag = Quaternion.Euler (new Vector3 (0, 0, (float)rot));
						this.transform.rotation = swag;
				



	}

	void OnTriggerEnter2D(Collider2D other) 
	{
				if (!friendlyPuff) {
						if (other.gameObject.tag == "friendly") {
								Destroy (other.gameObject);
				Instantiate (explosionEnemy, new Vector2(this.transform.position.x - .1f, this.transform.position.y + .08f), this.transform.rotation);
								Destroy (this.gameObject);
								
								AudioSource.PlayClipAtPoint (fireSound, this.transform.position);
						}
				} else {
						if (other.gameObject.tag == "enemy") {
								Destroy (other.gameObject);
				Instantiate (explosionFriend, new Vector2(this.transform.position.x + .1f, this.transform.position.y + .08f), this.transform.rotation);					
								Destroy (this.gameObject);

								AudioSource.PlayClipAtPoint (fireSound, this.transform.position);
						}
				}
		}
}

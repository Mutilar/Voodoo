using UnityEngine;
using System.Collections;

public class ThrownSword : MonoBehaviour {
	public bool right = false;
	int killAmount = 3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (right) {
			this.transform.Rotate (new Vector3 (0f, 0f, this.transform.rotation.z - 10f));
			this.transform.position = new Vector2 (this.transform.position.x + .03f, this.transform.position.y - .002f);
				} else {
						this.transform.Rotate (new Vector3 (0f, 0f, this.transform.rotation.z + 10f));
						this.transform.position = new Vector2 (this.transform.position.x - .03f, this.transform.position.y - .002f);
				}
	
	}
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (killAmount > 0) {
						if (other.gameObject.tag == "enemy") {
								other.gameObject.tag = "dead";
				killAmount--;	
						}

				}
		if (killAmount == 0)
						Destroy (this.gameObject);
	}

}

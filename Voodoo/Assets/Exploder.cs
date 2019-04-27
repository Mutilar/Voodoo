using UnityEngine;
using System.Collections;

public class Exploder : MonoBehaviour {

	public bool tracking = false;
	GameObject boss;
	// Use this for initialization
	void Start () {
		
		if (tracking)
						boss = GameObject.FindGameObjectWithTag ("enemyGO");
		Destroy (this.gameObject, .52f);
		Vector3 position = this.transform.position;
		if (!tracking)
						position.z = -2f;
				else
						position.z = 2f;
		this.transform.position = position;
		if (!tracking) this.transform.rotation = Quaternion.Euler (0, 0, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (tracking) {
			Vector3 position = boss.transform.position;

				}
	}
}

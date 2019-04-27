using UnityEngine;
using System.Collections;

public class animationBoss3FriendlyDeath : MonoBehaviour {
	int counter = 0;
	public int delay;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		counter++;
		if (counter == 1790 + delay)
						Destroy (this.gameObject);
	}
}

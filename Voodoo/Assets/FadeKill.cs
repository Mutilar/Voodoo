using UnityEngine;
using System.Collections;

public class FadeKill : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ContinuousDistance : MonoBehaviour {
	public GameObject general;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		GetComponent<Text> ().text = ((int)(general.transform.position.x * 10)) + " Feet";
	}
}

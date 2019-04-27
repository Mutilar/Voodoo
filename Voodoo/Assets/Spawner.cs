using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spawner : MonoBehaviour {
	float delayer = 0f;
	public AudioClip click;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (this.GetComponent<Button> ().interactable == false) this.GetComponent<Image> ().fillAmount += (1f / delayer);
		if (this.GetComponent<Image>().fillAmount >= 1f) this.GetComponent<Button> ().interactable = true;

	}

	public void delay(float delayTime)
	{
		AudioSource.PlayClipAtPoint (click, this.transform.position);
		delayer = delayTime;
		//fill amount = 0->1. 1 = ready to spawn.
		this.GetComponent<Button> ().interactable = false;
		this.GetComponent<Image> ().fillAmount = 0;
		//this.GetComponent<Button>().interactable = true;
	}
}

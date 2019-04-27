using UnityEngine;
using System.Collections;

public class animationBoss1CameraPan : MonoBehaviour {

	int counter;
	float pansize = 1;
	float speed;
	bool secondCut = false;
	public GameObject general;
	public GameObject fadeUnfade;
	// Use this for initialization
	void Start () {
		Unfade.resetTimer ();
		for (int i = 0; i < 75; i++) Instantiate (fadeUnfade, new Vector3(0f,0f,0f), this.transform.rotation);		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
	
		
		Vector3 position = this.transform.position;
		counter++;
		if (counter < 600)
		{
			speed = .004f;//position.x -= .005f;
			pansize += .0001f;
			Camera.main.orthographicSize = pansize;
		}
		if (counter == 600)
		{
			speed = -0f;
		}
		if (counter > 875 && counter < 10000)
		{
			//if (position.x > general.transform.position.x)
			//{
			position.x -= (position.x - general.transform.position.x) / 10f;
			if (position.x < -.8f) position.x = -.8f;
			//}
			//else
			//{
			//	position.x -= (position.x - general.transform.position.x) / 2f;
			//}
		}
		if (!secondCut && general.transform.position.x > 4.75f) {
			counter = 10000;
			secondCut = true;
				}

		if (counter == 10000)
		{

			speed = .004f;
		}
		if (counter == 10150) {
			speed = 0f;
			//counter = 900;
				}
		if (counter == 10500) {
			counter = 900;
				}

		position.x += speed;
		this.transform.position = position;

		/*if (counter == 725)
		{
			position.x = 25f;
		}
		if (counter > 725)
		{
			speed = .01f;//position.x += .01f;
		}
		if (counter > 875 && counter <= 1000)
		{
			speed = -.038f;//position.x -= .04f;
			pansize -= .002f;
			Camera.main.orthographicSize = pansize;
		}
		if (counter > 1000)
		{
			speed = -.023f;//position.x -= .04f;
		}
		if (counter == 1350)
		{
			pansize = 1;
			Camera.main.orthographicSize = pansize;
			position.x = -1f;
		}
		if (counter > 1350)
		{
			pansize += .001f;
			speed = .02f;//position.x += .04f;
			Camera.main.orthographicSize = pansize;
		}
		if (counter > 1700)
		{
			pansize += .0005f;
			speed = -.023f;//position.x -= .05f;
			Camera.main.orthographicSize = pansize;		
		}
		if (counter > 1900 && counter < 1975)
		{
			Instantiate (fade, new Vector3(0f,0f,0f), this.transform.rotation);		
		}
		
		if (counter == 2250) {
			Application.LoadLevel("level1");
		}*/
	
	}
}

using UnityEngine;
using System.Collections;

public class animationBoss3CameraPan : MonoBehaviour {
	
	int counter;
	float pansize = 1;
	float speed;
	bool secondCut = false;
	public GameObject general;
	public GameObject boss;
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
			speed = .0045f;//position.x -= .005f;
			pansize += .0005f;
			Camera.main.orthographicSize = pansize;
		}
		if (counter == 600)
		{
			speed = -0f;
		}
		if (counter > 1200 && counter < 1600) {
			position.x -= (position.x - boss.transform.position.x)/ 5f;
			position.y -= (position.y - boss.transform.position.y)/ 5f;
				}
		if (counter > 1600 && counter < 1675)
						position.y += .03f;
		if (counter == 1675)
						position.x = -2.25f;
		if (counter > 1675 && counter < 1775)
						position.y -= .03f;
		if (counter > 2000 && counter < 10000)
		{
			//if (position.x > general.transform.position.x)
			//{
			position.x -= (position.x - ((general.transform.position.x + boss.transform.position.x) / 2))/ 8f;
	      position.y -= (position.y - ((general.transform.position.y + boss.transform.position.y) / 2)) / 8f;
			if (counter > 2100) if (position.x < -.8f) position.x = -.8f;
			//}
			//else
			//{
			//	position.x -= (position.x - general.transform.position.x) / 2f;
			//}
		}
		
		position.x += speed;
		this.transform.position = position;

		
	}
}

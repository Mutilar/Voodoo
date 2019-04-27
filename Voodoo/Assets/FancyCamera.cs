using UnityEngine;
using System.Collections;
public class FancyCamera : MonoBehaviour {
	//bool mask = false;
	public float maxPanSpeed = .06f;
	float speed = 0f;
	bool moving;

	bool bottomOut=false;
	public GameObject general;
	public GameObject boss;

	public GameObject fadeUnfade;
	void Start()
	{
		Unfade.resetTimer ();
		for (int i = 0; i < 75; i++) Instantiate (fadeUnfade, new Vector3(0f,0f,0f), this.transform.rotation);		
	}

	void FixedUpdate () 
	{
		Vector3 position = this.transform.position;
		if (Input.GetKey (KeyCode.A)) {
			increaseSpeed ();
			position.x -= speed;

		} 
		if (Input.GetKey (KeyCode.D)) {
			increaseSpeed ();
			position.x += speed;

		}  
		if (Input.GetKey (KeyCode.W)) {
			increaseSpeed ();
			position.y += speed;
		} 
		if (Input.GetKey (KeyCode.S) && !bottomOut) {
			increaseSpeed ();
			position.y -= speed;
		}
		if (!moving) 
			if (speed - .005f >= 0f) 
				speed -= .005f;

		if (position.x < general.transform.position.x)
			position.x = general.transform.position.x;

		if (position.x > boss.transform.position.x)
			position.x = boss.transform.position.x;

		this.transform.position = position;
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}
	void increaseSpeed()
	{
		if (speed + .001f <= maxPanSpeed) speed += .005f;
		moving = true;
	}
}
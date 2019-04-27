using UnityEngine;
using System.Collections;

public class CameraPan : MonoBehaviour 
{
	bool mask = false;
	public float maxPanSpeed = .06f;
	float speed = 0f;

	bool moving;

	public float minX;
	public float maxX;
	public float minY;
	public float maxY;

	public GameObject fadeUnfade;
	// Use this for initialization
	void Start () {
		Unfade.resetTimer ();
		for (int i = 0; i < 75; i++) Instantiate (fadeUnfade, new Vector3(0f,0f,0f), this.transform.rotation);		
	}


	void FixedUpdate () 
	{

		Vector3 position = this.transform.position;
		if (Input.GetKey (KeyCode.A)) {
			increaseSpeed ();
			position.x -= speed;
			if (position.x < minX) position.x = minX;
				} 
		if (Input.GetKey (KeyCode.D)) {
			increaseSpeed ();
			position.x += speed;
			if (position.x > maxX) position.x = maxX;
				}  
		if (Input.GetKey (KeyCode.W)) {
			increaseSpeed ();
			position.y += speed;
			if (position.y > maxY) position.y = maxY;
				} 
		if (Input.GetKey (KeyCode.S)) {
			increaseSpeed ();
			position.y -= speed;
			if (position.y < minY) position.y = minY;
				} 
		 
				
		if (!moving) 	if (speed - .005f >= 0f) speed -= .005f;

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




/*
				//Camera cam = this.camera;
				//SpriteRenderer sprite = this.renderer;
				if (Input.GetKey (KeyCode.A)) {
						if (panSpeed [LEFT] < maxPanSpeed)
								panSpeed [LEFT] += .0005f;

						if (position.x - panSpeed [LEFT] > 1.85f)
								position.x -= panSpeed [LEFT];
						else if (panSpeed [LEFT] - .01f > 0)
								panSpeed [LEFT] -= .01f;
				}
				if (Input.GetKey (KeyCode.D)) {
						if (panSpeed [RIGHT] < maxPanSpeed)
								panSpeed [RIGHT] += .0005f;

						if (position.x - panSpeed [RIGHT] > 1.85f)
								position.x -= panSpeed [LEFT];
						else if (panSpeed [RIGHT] - .01f > 0)
								panSpeed [LEFT] -= .01f;
				}
				if (Input.GetKey (KeyCode.W)) {
						if (panSpeed [UP] < maxPanSpeed)
								panSpeed [UP] += .0005f;

						if (position.y + panSpeed [UP] < 6.0f)
								position.y += panSpeed [UP];
						else  if (panSpeed [UP] - .01f > 0)
								panSpeed [UP] -= .01f;
				}
				if (Input.GetKey (KeyCode.S)) {
						if (panSpeed [DOWN] < maxPanSpeed)
								panSpeed [DOWN] += .0005f;

						if (position.y - panSpeed [DOWN] > .5f)
								position.y -= panSpeed [DOWN];
						else if (panSpeed [DOWN] - .01f > 0)
								panSpeed [DOWN] -= .01f;
				}
				for (int i = 0; i <= 3; i++)
						if (panSpeed [i] > 0)
								panSpeed [i] -= .0001f;
*/
//if (Input.GetKey(KeyCode.W)
//{
//	if (panSpeed < maxPanSpeed) 
//						panSpeed += .001f;
//
//
//}
//		else
//				panSpeed = .03f;

//if (Input.GetKey (KeyCode.Plus)) 
//				cam.orthographicSize = 2.0f;
//cam.orthographicSize = 2.0f;
//if (Input.GetKey (KeyCode.Minus))
//				cam.orthographicSize = 1.5f;
//cam.orthographicSize = 1.5f;

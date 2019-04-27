using UnityEngine;
using System.Collections;

public class CameraPanTut : MonoBehaviour {
	bool mask = false;
	public float maxPanSpeed = .06f;
	float speed = 0f;

	public GameObject codeBase;
	
	bool moving;
	
	public float minX;
	public float maxX;
	public float minY;
	public float maxY;
	
	public GameObject fadeUnfade;

	public GameObject general;
	// Use this for initialization
	void Start () {
		Unfade.resetTimer ();
		for (int i = 0; i < 75; i++) Instantiate (fadeUnfade, new Vector3(0f,0f,0f), this.transform.rotation);		
	}
	
	
	void Update () 
	{Vector3 position = this.transform.position;
		if (codeBase.GetComponent<Demo> ().cameraSnap == false) {
						
						if (Input.GetKey (KeyCode.A)) {
								increaseSpeed ();
								position.x -= speed;
								if (position.x < minX)
										position.x = minX;
						} 
						if (Input.GetKey (KeyCode.D)) {
								increaseSpeed ();
								position.x += speed;
								if (position.x > maxX)
										position.x = maxX;
						}  
						if (Input.GetKey (KeyCode.W)) {
								increaseSpeed ();
								position.y += speed;
								if (position.y > maxY)
										position.y = maxY;
						} 
						if (Input.GetKey (KeyCode.S)) {
								increaseSpeed ();
								position.y -= speed;
								if (position.y < minY)
										position.y = minY;
						} 
		
		
						if (!moving)
						if (speed - .005f >= 0f)
								speed -= .005f;
		
				
				} else {
					position.x -= (position.x - general.transform.position.x) / 20f;




				}
						if (Input.GetKeyDown (KeyCode.Escape)) {
								Application.Quit ();
						}
		this.transform.position = position;
		
		//this.camera = cam;
		
	}
	
	
	void increaseSpeed()
	{
		if (speed + .001f <= maxPanSpeed) speed += .005f;
		moving = true;
	}
}




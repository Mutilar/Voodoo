using UnityEngine;
using System.Collections;

public class animation7CameraPan : MonoBehaviour {
	public GameObject fadeKill;
	public GameObject fade;
	public GameObject soldier;
	public GameObject pup;

	public GameObject red1;
	public GameObject red2;
	public GameObject red3;
	public GameObject location;
	int counter = 0;
	public GameObject fadeUnfade;
	// Use this for initialization
	void Start () {
		Unfade.resetTimer ();
		for (int i = 0; i < 75; i++) Instantiate (fadeUnfade, new Vector3(0f,0f,0f), this.transform.rotation);		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		counter++;
		Vector3 position = this.transform.position;
		if (counter >= 1525 && counter <= 1600) 	Instantiate (fadeKill, new Vector3(0f,0f,0f), this.transform.rotation);		
		if (counter < 600) position.x -= (position.x - soldier.transform.position.x) / 20f;
		if (counter > 600 && counter < 800)
			position.x += .002f;
		if (counter > 800 && counter < 1000)  position.x -= (position.x - pup.transform.position.x) / 20f;
		if (counter > 1000 && counter < 1200) position.x -= (position.x - ((soldier.transform.position.x + pup.transform.position.x) / 2)) / 20f;
		if (counter > 1600) position.x += .005f;
		if (counter >= 2000 && counter <= 2075) 	Instantiate (fadeKill, new Vector3(0f,0f,0f), this.transform.rotation);	
		if (counter > 2050)
		{
			if (counter % 50 == 0)
			{
				float ranVal = Random.value;
				if (ranVal < .33)Instantiate (red1, new Vector2(this.transform.position.x - 1.5f, this.transform.position.y-.2f), this.transform.rotation);	
				else if (ranVal < .66) Instantiate (red2, new Vector2(this.transform.position.x - 1.5f, this.transform.position.y-.2f), this.transform.rotation);	
				else Instantiate (red3, new Vector2(this.transform.position.x - 1.5f, this.transform.position.y- .2f), this.transform.rotation);	


			}

		}
		if (counter == 2600) Instantiate (location, new Vector3(0f,0f,0f), this.transform.rotation);
		if (counter > 2600 && counter < 2675) {

			Instantiate (fade, new Vector3(0f,0f,0f), this.transform.rotation);
		}
		if (counter == 2700) Application.LoadLevel("level7");

		this.transform.position = position;
	
	}
}

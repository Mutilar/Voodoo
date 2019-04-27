using UnityEngine;
using System.Collections;

public class CreatePlayers : MonoBehaviour {

	int counter = 0;
	public GameObject red0;
	public GameObject red1;
	public GameObject red2;
	public GameObject red3;
	public float enemySpawnLocationX = 18f;
	public float enemySpawnLocationY = 2f;
	public GameObject pink1;
	public bool spawn1;
	public GameObject pink2;
	public bool spawn2;
	public GameObject pink3;
	public bool spawn3;
	public GameObject pinkExtra; //level 1-3 = none. //level 4-6 = boar pups //level 7-9 = farmers
	public bool spawnExtra;

	public int spawnRate = 300;
	bool prevSpawn = false;

	public string levelType = "";

	public GameObject fade;
	bool fading = false;
	int fadeCounter = 0;
	// Use this for initialization
	void Start () 
	{
		GetComponent<Animator> ().SetBool ("Selected", false);
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{

		if (fading) {
			fadeCounter++;
			AudioSource swagg = GetComponent<AudioSource> ();
			swagg.volume -= .013f;
			Instantiate (fade, new Vector3(0f,0f,0f), this.transform.rotation);		
			if (fadeCounter == 75) Application.LoadLevel (levelType);
				}

		counter++;
		if (counter >= spawnRate) {
			counter = Mathf.RoundToInt(Random.value * (spawnRate - 50));
			if (counter < 0) counter = 0;
			if (prevSpawn && Random.value < .5f)
			{
				counter = spawnRate - 20;
			}
			else if (prevSpawn) prevSpawn = false;
			else if (!prevSpawn && Random.value < .2f) 
			{
				counter = spawnRate - 20;
				prevSpawn = true;
			}
			spawnEnemy();
			/*
			int numberSpawns;
			if (spawn1) numberSpawns++;
			if (spawn2) numberSpawns++;
			if (spawn3) numberSpawns++;


			double swag = Random.value;
			if (swag < 1f / numberSpawns)
			{
				Instantiate (pink1, new Vector3(enemySpawnLocationX,enemySpawnLocationY + 1f,0), this.transform.rotation);
			}
			else if (swag < .6f)
			{
				Instantiate (pink2, new Vector3(enemySpawnLocationX,enemySpawnLocationY + 1f,0), this.transform.rotation);
			}
			else 
			{
				Instantiate (pink3, new Vector3(enemySpawnLocationX,enemySpawnLocationY + 1f,0), this.transform.rotation);
			}	*/
		}
	}


	void spawnEnemy()
	{
		ArrayList swag; 
		swag = new ArrayList ();
		if (spawn1) {
			for (int i = 0; i < 3; i++)	swag.Add ("1");
				}

		if (spawn2) {
						swag.Add ("2");
						swag.Add ("2");
				}
		if (spawn3) {
						swag.Add ("3");
				}
		if (spawnExtra) {
			for (int i = 0; i < 4; i++) swag.Add ("4");
				}
		double randomPick = Random.Range (0, swag.Count);
		switch (swag [((int)randomPick)].ToString ()) 
		{
		case "1":
			Instantiate (pink1, new Vector3(enemySpawnLocationX,enemySpawnLocationY + 1f,0), this.transform.rotation);
			break;
		case "2":
			Instantiate (pink2, new Vector3(enemySpawnLocationX,enemySpawnLocationY + 1f,0), this.transform.rotation);
			break;
		case "3":
			Instantiate (pink3, new Vector3(enemySpawnLocationX,enemySpawnLocationY + 1f,0), this.transform.rotation);
			break;
		case "4":
			Instantiate (pinkExtra, new Vector3(enemySpawnLocationX,enemySpawnLocationY + 1f,0), this.transform.rotation);
			break;
		}


				

	}

	public void spawn(string type)
	{
		if (type.Equals ("Farmer")) {
			Instantiate (red0, new Vector3(-2.2f,.7f,0), this.transform.rotation);
				}
		if (type.Equals ("Soldier")) {
			Instantiate (red1, new Vector3(-2.2f,.7f,0), this.transform.rotation);
		}
		if (type.Equals ("Priest")) {
			Instantiate (red2, new Vector3(-2.2f,.7f,0), this.transform.rotation);
		}
		if (type.Equals ("Witchdoctor")) {
			Instantiate (red3, new Vector3(-2.2f,.7f,0), this.transform.rotation);
		}

	}


	void OnTriggerEnter2D (Collider2D other)
	{
			if (other.gameObject.tag == "enemy") {
				fading = true;
			}
	}

}

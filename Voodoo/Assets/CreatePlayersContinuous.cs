using UnityEngine;
using System.Collections;
public class CreatePlayersContinuous : MonoBehaviour
{
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
	public GameObject boss;
	bool fading = false;
	int fadeCounter = 0;
	// Use this for initialization
	void Start ()
	{
		GetComponent<Animator> ().SetBool ("Slow", true);
		spawnRate = (Mathf.Abs (2 - LevelSaver.getDiff ()) + 1) * 100;
		//LevelSaver swagg = new LevelSaver ();
		//print (swagg.getContinuousDifficulty ());
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{

		Vector3 position = this.transform.position;
		position.x += .002f;
		RaycastHit2D hit = Physics2D.Raycast (new Vector2 (transform.position.x, transform.position.y - .22f), new Vector2 (0, -1f), .01f);
		//Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - height), new Vector2 (0, -.02f));
		if (hit.collider == null)
			position.y -= .005f;
		else if (hit.collider.gameObject.tag == "environment")
			position.y += .005f;
		this.transform.position = position;


		getSpawnPos (false);
		if (fading) {
			fadeCounter++;
			AudioSource swagg = GetComponent<AudioSource> ();
			swagg.volume -= .013f;
			Instantiate (fade, new Vector3 (0f, 0f, 0f), this.transform.rotation);        
			if (fadeCounter == 75)
				Application.LoadLevel (levelType);
		}
		counter++;
		if (counter >= spawnRate) {
			if (spawnRate > 10) spawnRate -= 5; ///////**********************************This can be increased/decreased to change how fast it goes to impossible-lose
 			counter = Mathf.RoundToInt (Random.value * (spawnRate - 50));
			if (counter < 0)
				counter = 0;
			if (prevSpawn && Random.value < .5f) {
				counter = spawnRate - 20;
			} else if (prevSpawn)
				prevSpawn = false;
			else if (!prevSpawn && Random.value < .2f) {
				counter = spawnRate - 20;
				prevSpawn = true;
			}
			spawnEnemy ();
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
            }    */
		}
	}
	
	void spawnEnemy ()
	{
		ArrayList swag; 
		swag = new ArrayList ();
		if (spawn1) {
			for (int i = 0; i < 3; i++)
				swag.Add ("1");
		}
		if (spawn2) {
			swag.Add ("2");
			swag.Add ("2");
		}
		if (spawn3) {
			swag.Add ("3");
		}
		if (spawnExtra) {
			for (int i = 0; i < 4; i++)
				swag.Add ("4");
		}
		double randomPick = Random.Range (0, swag.Count);
		switch (swag [((int)randomPick)].ToString ()) {
		case "1":
			Instantiate (pink1, getSpawnPos (true), this.transform.rotation);
			break;
		case "2":
			Instantiate (pink2, getSpawnPos (true), this.transform.rotation);
			break;
		case "3":
			Instantiate (pink3, getSpawnPos (true), this.transform.rotation);
			break;
		case "4":
			Instantiate (pinkExtra, getSpawnPos (true), this.transform.rotation);
			break;
		}
	}
	public Vector2 getSpawnPos (bool isEnemy)
	{
		float location = this.transform.position.x;
		if (isEnemy)
			location = boss.transform.position.x + 1.75f;
				else
						location -= 1.75f;
		RaycastHit2D hit = Physics2D.Raycast (new Vector2 (location, 150f), -Vector2.up, 300f);
		return new Vector2 (hit.transform.position.x, hit.point.y - 3f);
	}
	public void spawn (string type)
	{
		if (type.Equals ("Farmer")) {
			Instantiate (red0, getSpawnPos (false), this.transform.rotation);
		}
		if (type.Equals ("Soldier")) {
			Instantiate (red1, getSpawnPos (false), this.transform.rotation);
		}
		if (type.Equals ("Priest")) {
			Instantiate (red2, getSpawnPos (false), this.transform.rotation);
		}
		if (type.Equals ("Witchdoctor")) {
			Instantiate (red3, getSpawnPos (false), this.transform.rotation);
		}
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "enemy") {
			fading = true;
		}
	}
}
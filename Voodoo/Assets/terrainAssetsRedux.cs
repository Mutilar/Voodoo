using UnityEngine;
using System.Collections;
public class terrainAssetsRedux : MonoBehaviour
{
	public int chunksToGenerate;
	//S=slope,F=flat
	//G=grass,D=dirt,T=grass-dirt transition
	//#=variant
	//u=up,d=down(for slopes)
	public GameObject SG0u, SD0u, SG0d, SD0d, FG0, FG1, FD0, FT0, FT1;
	public GameObject Underground;
	int elementsCount = 9;//this should always equal the number of sprites implemented in code
	float xDistance = -2f, yLocation = 0f;//keeps track of how far right the generation progresses
	numberedTerrain[] terrains;
	int flatFor = 10;
	string currentVegetation = "grass";
	int lastIndex = 4;
	bool transitioning = false, endingGeneration = false;
	Quaternion renderRotation = new Quaternion ();

	public GameObject boss;
	public GameObject general;
	int jaggedness;//retreives the jaggedness value from memory, the value is reversed just to make it easier to work with in code
	void Start ()
	{
		jaggedness = (int)Mathf.Abs(2-LevelSaver.getRough());//retreives the jaggedness value from memory, the value is reversed just to make it easier to work with in code

		//jaggedness = (int)Mathf.Abs(2-new LevelSaver().getJaggedness());
		//print (new LevelSaver ().getJaggedness () + "jagg");
		//print (new LevelSaver ().getContinuousDifficulty () + "diff");
		BoxCollider2D box = Underground.GetComponent<BoxCollider2D> ();
		//---------------------------------------------------------------
		//Assign sprites to the array here
		//Enter values as: (height,length,variant,SpriteRenderer,direction(up,down,flat),vegetationType(grass,dirt,tograss,todirt))
		//---------------------------------------------------------------
		terrains = new numberedTerrain[elementsCount];
		terrains [0] = new numberedTerrain (.32f, .64f, 0, SG0u.GetComponent<SpriteRenderer> (), "up", "grass", SG0u.GetComponent<PolygonCollider2D> ());
		terrains [1] = new numberedTerrain (.32f, .64f, 0, SD0u.GetComponent<SpriteRenderer> (), "up", "dirt", SD0u.GetComponent<PolygonCollider2D> ());
		terrains [2] = new numberedTerrain (-.32f, .64f, 0, SG0d.GetComponent<SpriteRenderer> (), "down", "grass", SG0d.GetComponent<PolygonCollider2D> ());
		terrains [3] = new numberedTerrain (-.32f, .64f, 0, SD0d.GetComponent<SpriteRenderer> (), "down", "dirt", SD0d.GetComponent<PolygonCollider2D> ());
		terrains [4] = new numberedTerrain (0, .32f, 0, FG0.GetComponent<SpriteRenderer> (), "flat", "grass", FG0.GetComponent<PolygonCollider2D> ());
		terrains [8] = new numberedTerrain (0, .32f, 1, FG1.GetComponent<SpriteRenderer> (), "flat", "grass", FG1.GetComponent<PolygonCollider2D> ());
		terrains [5] = new numberedTerrain (0, .32f, 0, FD0.GetComponent<SpriteRenderer> (), "flat", "dirt", FD0.GetComponent<PolygonCollider2D> ());
		terrains [6] = new numberedTerrain (0, .32f, 0, FT0.GetComponent<SpriteRenderer> (), "flat", "tograss", FT0.GetComponent<PolygonCollider2D> ());//the "to" prefix signifies a transition sprite
		terrains [7] = new numberedTerrain (0, .32f, 0, FT1.GetComponent<SpriteRenderer> (), "flat", "todirt", FT1.GetComponent<PolygonCollider2D> ());//the "to" prefix signifies a transition sprite
		//---------------------------------------------------------------
		//Generation takes place here
		//---------------------------------------------------------------
		Vector3 renderPosition = new Vector3 (xDistance, yLocation, 0);
		for (int pos=0; pos!=chunksToGenerate; pos++) {
			xDistance += terrains [lastIndex].getL ();
			if (flatFor > 0) {
				Instantiate (getTerrain ("flat", currentVegetation), getRenderPosition (), renderRotation);
				if (transitioning) {
					transitioning = false;
					currentVegetation = currentVegetation.Substring (2);//takes off the "to" part of the string to convert it to a nontransition state
				} else
					switchVeg ();
				flatFor--;
			} else {
				int dir = newDirection ();
				yLocation += terrains [lastIndex].getH () / 2;
				if (dir == 1) 
					Instantiate (getTerrain ("up", currentVegetation), getRenderPosition (), renderRotation);
				else if (dir == -1) 
					Instantiate (getTerrain ("down", currentVegetation), getRenderPosition (), renderRotation);
				else if (dir >=0)
					Instantiate (getTerrain ("flat", currentVegetation), getRenderPosition (), renderRotation);
			}
			addUnderground (getRenderPosition ());
			if (pos == chunksToGenerate - 1 && !endingGeneration) {
				endingGeneration = true;
				flatFor = 6;
				pos -= 6;
				addEndColliders ();
			}
		}
	}
	void addEndColliders ()
	{
		Instantiate (getSkyCollider (), new Vector3 (xDistance + .32f, yLocation + 1.4f, 0), renderRotation);
		Instantiate (getSkyCollider (), new Vector3 (xDistance + .32f, yLocation + 1f, 0), renderRotation);
		Instantiate (getSkyCollider (), new Vector3 (xDistance + .32f, yLocation + .5f, 0), renderRotation);
	}
	void addUnderground (Vector3 pos)//instantiates a set of underground terrain sprites beneath the point passed up
	{
		float counter = pos.y - .32f;
		bool isGrassSlope = terrains [lastIndex].getH () != 0;
		if (terrains [lastIndex].type.Equals ("grass") && terrains [lastIndex].height != 0)
			counter -= .16f;
		if (!isGrassSlope)
		while (counter>yLocation-1.5f) {
			Instantiate (getUnderground (), new Vector3 (pos.x, counter, 0), renderRotation);
			counter -= .32f;
		}
		else
		while (counter>yLocation-2f) {
			Instantiate (getUnderground (), new Vector3 (pos.x - .16f, counter, 0), renderRotation);
			Instantiate (getUnderground (), new Vector3 (pos.x + .16f, counter, 0), renderRotation);
			counter -= .32f;
		}
		addSkyCollider (pos, isGrassSlope);
	}
	void addSkyCollider (Vector3 pos, bool isGrassSlope)//adds a collider in the sky above the terrain so the camera can't go up indefinitely
	{
		float yLoc = pos.y + 3f;
		if (!isGrassSlope)
			Instantiate (getSkyCollider (), new Vector3 (pos.x, yLoc, 0), renderRotation);
		else {
			Instantiate (getSkyCollider (), new Vector3 (pos.x - .16f, yLoc, 0), renderRotation);
			Instantiate (getSkyCollider (), new Vector3 (pos.x + .16f, yLoc, 0), renderRotation);
		}
	}
	public GameObject getSkyCollider ()//returns a sky collider gameobject, I use an underground sprite so that the size of the collider is correct
	{
		GameObject panel = new GameObject ();
		panel.AddComponent<CircleCollider2D> ();
		panel.GetComponent<CircleCollider2D> ().radius = .3f;
		panel.AddComponent<WeirdnessKiller> ();
		return panel;
	}
	Vector3 getRenderPosition ()//determines the point that the next terrain should be located at
	{
		float yFixer = 0;
		if (currentVegetation.Equals ("grass"))
			if (terrains [lastIndex].getH () < 0)
				yFixer = -.16f;
		else
			yFixer = .16f;
		else if (terrains [lastIndex].getH () > 0)
			yFixer = .32f;
		if (terrains [lastIndex].getL () > .33f)
			return new Vector3 (xDistance + .16f, yLocation + yFixer, 0);
		return new Vector3 (xDistance, yLocation, 0);
	}
	void switchVeg ()//determines whether the vegetation type should switch from grass to dirt or vice versa
	{
		float val = Random.value;
		if (currentVegetation.Equals ("dirt"))//this just makes it more likely to switch from dirt to grass
			val += .3f;
		if (val > .6 && flatFor > 1) {
			transitioning = true;
			if (currentVegetation.Equals ("grass"))
				currentVegetation = "todirt";
			else
				currentVegetation = "tograss";
		}
	}
	int newDirection ()//Determines whether the next terrain should be up, down or flat
	{
		int val = Mathf.FloorToInt (Random.value * (3f+(float)jaggedness )- 1f);
		if (val >=0&&val!=1)
			flatFor = Mathf.FloorToInt (Random.value * 3f + jaggedness);//used to make the generation stay flat for a random amount of distance
		//print (val);
		yLocation += terrains [lastIndex].getH () / 2;
		return val;
	}
	public GameObject getTerrain (string dir, string vegTyp)//assmembles and returns a terrain gameobject based on the parameters passed up
	{
		
		GameObject panel = new GameObject ();//--------------------------this is the gameobject that everything else will be attached to
		Sprite background = new Sprite ();//================================this will later be filled with a sprite 
		panel.AddComponent<SpriteRenderer> ();//-------------------------adds a spriterenderer so the sprite can actually be added to the object
		int type = pickType (getTypes (dir, vegTyp));//==================finds the number of vaiants of the given terrain classification
		for (int i=0; i!=elementsCount; i++)//---------------------------finds the sprite that matches both the parameters passed up and the chosen variant
		if (terrains [i].checkVals (dir, vegTyp, type)) {//======checks to see if the sprite has the desired characteristics
			background = terrains [i].getTerrain ().sprite;//puts the sprite into a variable
			lastIndex = i;//=================================updates the last used index of the terrains[] array, this is needed so that other methods can access 
			//-----------------------------------------------data from the same item as the sprite. These values are needed for positioning of the gameobject on the screen
		}
		panel.GetComponent<SpriteRenderer> ().sprite = background;//=====puts the sprite into the terrain gameobject
		panel.AddComponent<PolygonCollider2D> ();//======================adds a collider for collision purposes
		panel.GetComponent<PolygonCollider2D> ().points = terrains [lastIndex].getCollider ().points;//sets panel's collider to its specific one
		panel.tag = "environment";//-----------------------------------------adds a tag for collision purposes
		panel.AddComponent<WeirdnessKiller> ();//------------------------see WeirdnessKiller class
		return panel;//==================================================returns the assembled gameobject
	}
	public GameObject getUnderground ()//returns an underground terrain gameobject
	{
		Sprite background = new Sprite ();
		GameObject panel = new GameObject ();
		panel.AddComponent<SpriteRenderer> ();
		background = Underground.GetComponent<SpriteRenderer> ().sprite;
		panel.GetComponent<SpriteRenderer> ().sprite = background;
		panel.AddComponent<WeirdnessKiller> ();
		return panel;
	}
	
	int getTypes (string dir, string vegTyp)//returns the number of types for a given classification of terrain
	{
		int counter = 0;
		for (int i=0; i!=elementsCount; i++)
			if (terrains [i].checkVals (dir, vegTyp)) 
				counter++;
		return counter;
	}
	int pickType (int types)//randomly chooses a terrain type
	{
		return Mathf.FloorToInt (Random.value * types);
	}
	
}


//methods left over from the last method of generation I used
/*int getTypes (int start, int end)
        {
                int counter = 0;
                for (int i=0; i!=elementsCount; i++)
                        if (terrains [i].checkVals (start, end)) 
                                counter++;
                return counter;
        }
public GameObject getTerrain (int start, int end)
        {
                Sprite background = new Sprite ();
                GameObject panel = new GameObject ();
                panel.AddComponent<SpriteRenderer> ();
                int type = pickType (getTypes (start, end));
                for (int i=0; i!=elementsCount; i++)
                        if (terrains [i].checkVals (start, end, type)) {
                                background = terrains [i].getTerrain ().sprite;
                                //print ("success " + start + " " + end);
                        }
                panel.GetComponent<SpriteRenderer> ().sprite = background;
                panel.AddComponent<PolygonCollider2D> ();
                panel.tag = "surface";
                panel.AddComponent<WeirdnessKiller> ();
                return panel;
        }
     */
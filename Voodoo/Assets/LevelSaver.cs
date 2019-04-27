using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class LevelSaver
{


	public static int contDiff = 0;
	public static int contRough = 0;



	int level;
	int jaggedness;
	int kills, deaths;
	int continuousDifficulty;
	string[] levelNames = {
		"cutscene2",
		"level1",
		"cutscene3",
		"level2",
		"cutscene5",
		"level3",
		"cutscene4",
		"boss1",
		"cutscene6",
		"level4",
		"cutscene8",
		"level5",
		"cutscene9",
		"level6",
		"boss2",
		"cutscene7",
		"level7",
		"cutscene10",
		"level8",
		"cutscene11",
		"level9",
		"cutscene12",
		"boss3",
		"finalCutscene"
	};

	public static int getDiff()
	{
		return contDiff;
	}
	public static void setDiff(int in1)
	{
		contDiff = in1;
	}
	public static int getRough()
	{
		return contRough;
	}
	public static void setRough(int in1)
	{
		contRough= in1;
	}


	public LevelSaver ()
	{
		loadData ();
	//	saveData();
		//FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");
		//file.Close ();
	}
	public void setLevel (int levelNum)
	{
		level = levelNum;
		saveData ();
	}
	public void setLevel (string levelName)
	{
		for (int i = 0; i!=levelNames.Length; i++)
			if (levelNames [i].Equals (levelNames))
				level = i;
		saveData ();
	}
	public string getLevelName ()
	{
		return levelNames [level];
	}
	public int getLevel ()
	{
		return level;
	}
	public void levelUp ()
	{
		level++;
		saveData ();
	}
	void saveData ()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");
		PlayerData data = new PlayerData ();
		data.level = level;
		bf.Serialize (file, data);
		file.Close ();
	}
	void loadData ()
	{
		if (File.Exists (Application.persistentDataPath + "playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();
			level = data.level;
			jaggedness = data.jaggedness;
			kills = data.kills;
			deaths = data.deaths;
			continuousDifficulty = data.continuousDifficulty;
		}
	}

	public void addKills (int killsToAdd)
	{
		kills += killsToAdd;
		saveData ();
	}
	public void addDeaths (int deathsToAdd)
	{
		deaths += deathsToAdd;
		saveData ();
	}
	public int getKills ()
	{
		return kills;
	}
	public int getDeaths ()
	{
		return deaths;
	}
	public float getKD ()
	{
		return kills / deaths;
	}
	public int getContinuousDifficulty ()
	{
		return continuousDifficulty;
	}
	public void setContinuousDifficulty (int difficulty)
	{
		continuousDifficulty = difficulty;
		saveData ();
	}
	public void setJaggedness (int jags)
	{
		jaggedness = jags;
		saveData ();
	}
	public int getJaggedness ()
	{
		return jaggedness;
	}
	[Serializable]
	class PlayerData
	{
		public int continuousDifficulty;
		public int jaggedness;
		public int level;
		public int kills, deaths;
	}
}
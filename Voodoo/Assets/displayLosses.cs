using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class displayLosses : MonoBehaviour {
	int counter = 0;
	// Use this for initialization
	void Start () {
		GetComponent<Text> ().text = "";
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		if (counter > 100) {
			GetComponent<Text> ().text = "Losses: " + Movement.getDeaths () + "\n";

				}
		if (counter > 200)
		{
			GetComponent<Text> ().text = "Losses: " + Movement.getDeaths () + "\n" + "Kills: " +EnemyMovement.getDeaths () + "\n" ;
		}
		if (counter > 300)
		{
			GetComponent<Text> ().text = "Losses: " +Movement.getDeaths () + "\n" + "Kills: " + EnemyMovement.getDeaths () + "\n" + "KD: " + ( Movement.getDeaths ()/(EnemyMovement.getDeaths () + 1f)) ;
		}
		if (counter > 400)
		{
			GetComponent<Text> ().text =  "Losses: " +Movement.getDeaths () + "\n" + "Kills: " +EnemyMovement.getDeaths () + "\n" + "KD: " + ( Movement.getDeaths ()/(EnemyMovement.getDeaths () + 1f) ) + "\n" + "If man hasn't" +
				" discovered something he will die for,\n he isn't fit to live\n-Martin Luther King Jr.";
		}
		if (counter > 700)
		{
			if (Input.GetKey(KeyCode.Escape)) Application.LoadLevel ("Menu");
			GetComponent<Text> ().text =  "Losses: " +Movement.getDeaths () + "\n" + "Kills: " +EnemyMovement.getDeaths () + "\n" + "KD: " +  ( Movement.getDeaths ()/(EnemyMovement.getDeaths () + 1f) ) + "\n" + "If man hasn't" +
				" discovered something he will die for,\n he isn't fit to live\n-Martin Luther King Jr." + "\nPress Esc to Continue";
		}
	}
}

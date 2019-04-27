using UnityEngine;
using System.Collections;

public class animationGeneral : MonoBehaviour {
	int counter;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		counter++;
		if (counter < 100)
		{
			this.GetComponent<GUIText>().text = "";
		}
		if (counter == 100)
		{
			Vector3 position = this.transform.position;
			position.x = .22f;
			position.y = .58f;
			this.transform.position = position;
			this.GetComponent<GUIText>().text = "At ease, soldier.";
		}
		if (counter == 200)
		{
			Vector3 position = this.transform.position;
			position.x = .325f;
			position.y = .48f;
			this.transform.position = position;
			this.GetComponent<GUIText>().text = "Sir, the scouts have spotted\n a horde of enemies coming!";
		}
		if (counter == 300)
		{
			Vector3 position = this.transform.position;
			position.x = .22f;
			position.y = .58f;
			this.transform.position = position;
			this.GetComponent<GUIText>().text = "Is that so...\nHow much time do we have?";
		}
		if (counter == 400)
		{
			Vector3 position = this.transform.position;
			position.x = .325f;
			position.y = .48f;
			this.transform.position = position;
			this.GetComponent<GUIText>().text = "Only a few minutes, Sir.";
		}
		if (counter == 500)
		{
			Vector3 position = this.transform.position;
			position.x = .22f;
			position.y = .58f;
			this.transform.position = position;
			this.GetComponent<GUIText>().text = "Very well.\nSend the mages to clean them up.";
		}
		if (counter == 600)
		{
			this.GetComponent<GUIText>().text = "*Whistles*";
		}
		if (counter == 650)
		{
			this.GetComponent<GUIText>().text = "";
		}
	}
}

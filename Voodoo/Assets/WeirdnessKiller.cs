
using UnityEngine;
using System.Collections;
public class WeirdnessKiller : MonoBehaviour
{
	//For some reason whenever a terrain object is created by the random generator, an identical copy is spawned at (0,0) as well. 
	//The sole purpose of this script is to destroy the copies that appear at (0,0) and then it deactivates itself if it does not spawn there.
	void Start ()
	{
		if (this.transform.position.x == 0)
			Destroy (this.gameObject);
		else
			this.GetComponent<WeirdnessKiller> ().enabled = false;
	}
}
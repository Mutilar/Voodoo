using UnityEngine;
using System.Collections;

public class Unfade : MonoBehaviour {
	public static float killTime = 1.5f;
	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, killTime);
		killTime -= (1.5f / 75f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void resetTimer()
	{
		killTime = 1.5f;
	}
}

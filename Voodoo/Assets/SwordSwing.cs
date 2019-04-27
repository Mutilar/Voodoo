using UnityEngine;
using System.Collections;
public class SwordSwing : MonoBehaviour
{
	int counter = 15;
	float scaleCounter=.5f;
	bool stop = false, right = true;
	public bool friendly;
	void Start ()
	{
		Vector3 pos = this.transform.position;
		if (friendly) pos.Scale(new Vector3(.5f,.5f,1));
		else pos.Scale(new Vector3(-.5f,.5f,1));
	}
	void FixedUpdate ()
	{
			if (!stop) {
				Vector3 pos = this.transform.position;
				if (counter > 10) {
				 scaleCounter+=.075f;

				if (friendly)
					pos.Set (pos.x + .01f, pos.y - .02f, pos.z);
				else pos.Set (pos.x - .01f, pos.y - .02f, pos.z);
				} else {
				scaleCounter-=.075f;

				if (friendly)
					pos.Set (pos.x - .01f, pos.y - .02f, pos.z);
				else pos.Set (pos.x + .01f, pos.y - .02f, pos.z);
				}
				if (friendly ) this.transform.localScale=new Vector3(scaleCounter,scaleCounter,1);
			else  this.transform.localScale=new Vector3(-scaleCounter,scaleCounter,1);
				//pos.Scale(new Vector3(scaleCounter,scaleCounter,1));
				this.transform.position = pos;
				if (friendly)
					this.transform.Rotate (new Vector3 (0f, 0f, this.transform.rotation.z - 5f));
				else
					this.transform.Rotate (new Vector3 (0f, 0f, this.transform.rotation.z + 5f));
				counter--;
				if (counter == 0)
					stop = true;
			} else
				Destroy (this.gameObject);
		}
	}


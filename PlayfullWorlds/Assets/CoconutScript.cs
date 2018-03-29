using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutScript : MonoBehaviour 
{
	public GameObject toucan;

	//Zodra een Toucan geraakt wordt met een kokosnoot, +140120423102103 score en verandert die van koers.
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == toucan.tag) 
		{
			GameObject.Find ("Score").GetComponent<Score> ().addScore (100);
			toucan.GetComponent<ToucanVlieg> ().kiesLocatie ();
			Destroy (col.gameObject);
		}
	}
}

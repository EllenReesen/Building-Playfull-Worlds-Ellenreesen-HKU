using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kogelscript : MonoBehaviour {

	private int leven = 0;

	public GameObject toucan;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		leven++;

		if (leven > 100) Destroy (gameObject);
	}

	//Zodra een Toucan geraakt wordt met een kogel, verandert die van koers.
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == toucan.tag) 
		{
			GameObject.Find ("Score").GetComponent<Score> ().addScore (1);
			toucan.GetComponent<ToucanVlieg> ().kiesLocatie ();
			Destroy (gameObject);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingGun : MonoBehaviour {

	public GameObject kogel, kogelpunt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && !transform.parent.GetComponent<CoconutPickUp>().heeftCoconutVast()) 
		{
			GameObject schietkogel = Instantiate (kogel, kogelpunt.transform.position, Quaternion.Euler(kogelpunt.transform.eulerAngles.x, kogelpunt.transform.eulerAngles.y - 90, kogelpunt.transform.eulerAngles.z));
			schietkogel.GetComponent<Rigidbody> ().AddForce (transform.parent.transform.forward * 2000);
			transform.GetComponent<AudioSource> ().Play ();

		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoconutPickUp : MonoBehaviour 
{
	private bool opgepakt = false;

	public GameObject kogelPunt, terrain, coconut;
	private int pakDelay = 0, cocamDelay = 0;
	
	// Update is called once per frame
	void Update ()
	{
		if (pakDelay > 0) pakDelay--;
		if (cocamDelay > 0) cocamDelay--;

		RaycastHit hit = new RaycastHit();
		if(Input.GetMouseButtonDown (1) && !opgepakt)
		{
			if (Physics.Raycast (GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)), out hit, 500f) && hit.transform.gameObject.layer == 8) 
			{
				if (pakDelay <= 0)  //niet meteen pakken en neerleggen tegelijk
				{
					coconut = hit.collider.gameObject;

					opgepakt = true;
					coconut.GetComponent<Rigidbody>().useGravity = false;
					coconut.GetComponent<Rigidbody> ().isKinematic = true;
					coconut.transform.SetParent (kogelPunt.transform);
					pakDelay = 10;
				}
			}
		}
		if (opgepakt && hit.transform != null) hit.transform.localPosition = new Vector3 (0, 0, 0);
		if (Input.GetMouseButtonDown(0) && pakDelay <= 0 && opgepakt) 
		{
			coconut.GetComponent<Rigidbody>().useGravity = true;
			coconut.GetComponent<Rigidbody> ().isKinematic = false;
			coconut.GetComponent<Rigidbody> ().AddForce (transform.forward * 1000);
			coconut.transform.rotation = transform.rotation; //zorgen dat de coconut op rotstion 0 begint
			coconut.GetComponent<Camera> ().enabled = true;
			GetComponent<Camera> ().enabled = false;
			coconut.transform.SetParent (terrain.transform);
			pakDelay = 10;
			cocamDelay = 200;	//je wordt de coconut als camera
			opgepakt = false;
		}
		if (cocamDelay <= 0) {
			coconut.GetComponent<Camera> ().enabled = false;
			GetComponent<Camera> ().enabled = true;
		}
	}

	public bool heeftCoconutVast()
	{
		return opgepakt;
	}
}
	
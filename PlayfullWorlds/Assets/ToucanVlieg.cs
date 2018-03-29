using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToucanVlieg : MonoBehaviour {

	private Vector3 target;

	private float delay = 0;

	public float snelheid = 0.6f;

	void Start()
	{
		snelheid += Random.Range (-0.15f, 0.15f);
		kiesLocatie ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (target != null) 
		{
			transform.LookAt (target); //Draai naar locatie
			//transform.Translate(transform.forward * snelheid); //Bewegen
			transform.position = new Vector3(Mathf.Lerp(transform.position.x, target.x, Time.deltaTime * snelheid/10), Mathf.Lerp(transform.position.y, target.y, Time.deltaTime * snelheid/10), Mathf.Lerp(transform.position.z, target.z, Time.deltaTime * snelheid/10));
		}

		if (delay > 0) delay--;
		else kiesLocatie ();
	}

	public void kiesLocatie()
	{
		delay = Random.Range (100, 400); //Wacht een tijdje tot je verandert waar je heen gaat
		target = new Vector3(Random.Range(20, 420), Random.Range(35, 70), Random.Range(0, 300)); //Vlieg ergens random heen
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voetstap : MonoBehaviour 
{
	public AudioClip[] voetstappen;
	private AudioSource geluidBron;

	private int loopDelay = 0;

	void Start () 
	{
		geluidBron = GetComponent<AudioSource>();
	}

	void Update ()
	{
		//Maakt geluid
		if ((GetComponent<CharacterController> ().velocity.x != 0 || GetComponent<CharacterController> ().velocity.z != 0) && GetComponent<CharacterController> ().isGrounded && loopDelay <= 0) {
			if (Input.GetKey (KeyCode.LeftShift)) { //Rengeluiden
				geluidBron.clip = voetstappen [1];
				loopDelay = 5;
			} else { //Loopgeluiden
				geluidBron.clip = voetstappen [0];
				loopDelay = 20;
			}
			geluidBron.Play ();
		} else if (Input.GetKey (KeyCode.Space) && GetComponent<CharacterController> ().isGrounded) { //Springgeluiden
			geluidBron.clip = voetstappen [2];
			loopDelay = 20;
			geluidBron.Play ();
		}

		if (loopDelay > 0) loopDelay--;
	}
}

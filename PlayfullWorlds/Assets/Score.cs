using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour 
{
	public int score;

	void Update()
	{
		GetComponent<Text> ().text = "Score: " + score;
	}

	//Voeg score toe vanuit andere scripts
	public void addScore(int i)
	{
		score += i;
	}
}

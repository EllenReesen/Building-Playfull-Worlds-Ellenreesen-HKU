using UnityEngine;
using System.Collections;

public class RespawnArround : MonoBehaviour
{
    public GameObject enemy;
    public float radius;
    public float timeRate = 5;
    float time;
	public int maxToucans = 10;

	private GameObject toucans;

	void Awake()
	{
		if(GameObject.Find ("Toucans") != null) toucans = GameObject.Find ("Toucans");
		else toucans = new GameObject ("Toucans");
	}

    void Update()
    {
		if (Time.time > time && toucans.transform.childCount < maxToucans)
        {
            GameObject clone = Instantiate(enemy);
			clone.transform.SetParent(toucans.transform); //Plaats alle toucans onder een dingetje
			clone.transform.position = new Vector3 (Random.Range(20, 420), Random.Range(10, 20), Random.Range(0, 300)); //Random ontstaan locatie van toucan
            clone.transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0); //Random rotatie van Toucan
            clone.transform.Translate(transform.forward * radius); //Bewegen

            time = Time.time + timeRate;
        }
    }
}

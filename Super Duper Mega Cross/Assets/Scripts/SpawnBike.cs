using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpawnBike : MonoBehaviour {

    public void SpawnObject(GameObject bike)
    {
        GameObject newBike = Instantiate(bike, transform);

       
        GameObject.FindGameObjectWithTag("FilmingPosition").transform.parent = newBike.transform;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("EditorOnly"))
        {
            obj.SetActive(false);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

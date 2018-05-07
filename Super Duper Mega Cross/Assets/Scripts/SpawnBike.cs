using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpawnBike : MonoBehaviour {

    public GameObject filmare;

    public void SpawnObject(GameObject bike)
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("EditorOnly"))
        {
            obj.SetActive(false);
        }

        GameObject newBike = Instantiate(bike, transform);

        newBike.transform.parent = null;

        filmare.transform.parent = newBike.transform;
    }
}

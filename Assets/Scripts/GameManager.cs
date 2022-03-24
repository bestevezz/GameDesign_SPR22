using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject carPrefab;
    public Transform[] carSpawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        SpawnCar();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnCar();
        }
    }

    void SpawnCar()
    {
        int index = Random.Range(0, carSpawnPoints.Length);
        Vector3 spawnPos = carSpawnPoints[index].position;

        GameObject car = Instantiate(carPrefab, spawnPos, Quaternion.identity);


        //conditional concatonation i.e version of if statement
        //essentially asking if the index is less than 1 and if it is then change the number to negative
        int dirModifier = (index > 3) ? -1 : 1;

        car.GetComponent<carMove>().speed = Random.Range(3.0f, 6.0f) * dirModifier;

        //change color of cars as they spawn, if the cars go off screen, they get destroyed
    }
}

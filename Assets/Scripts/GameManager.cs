using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject carPrefab;
    public Transform[] carSpawnPoints;
    public Color[] carColors;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCar", 3, 3);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SpawnCar();
        //}
    }

    void SpawnCar()
    {
        //Randomly choosing a range from the carSpawnPoints created in unity
        int index = Random.Range(0, carSpawnPoints.Length);
        //Setting the spawn position to points in space previously created
        Vector3 spawnPos = carSpawnPoints[index].position;

        GameObject car = Instantiate(carPrefab, spawnPos, Quaternion.identity);

        //conditional concatonation i.e version of if statement
        //essentially asking if the index is less than 1 and if it is then change the number to negative
        int dirModifier = (index > 3) ? -1 : 1;

        //getting the script component car move to modify the speed, and making each car random from the paramaters
        float newSpeed = Random.Range(3.0f, 6.9f); 
        car.GetComponent<carMove>().speed = newSpeed * dirModifier;

        //getting the component of sprite renderer, adjusting the material color to random with multiple parameters
        // parameters are float hueMin, float hueMax, float saturationMin, float saturationMax, float valueMin, float valueMax
        //car.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        //Math f is using math functions this one uses to make it an int
        //speed is between 3 to 6, array is 0-4, 3 becomes 0 and 6 becomes 4 in the array relative to speed
        //basically -3 sets the speed to the array 
        int colorIndex = Mathf.FloorToInt(newSpeed) - 3;

        //Does what the rest of the code in here does
        //Color c = Color.black;
        //if (newSpeed < 4.0f)
        //{
        //    c = carColors[0];
        //} else if (newSpeed >= 4.0f && newSpeed < 4.5f)
        //{
        //    c = carColors[1];
        //} else if (newSpeed >= 4.5f && newSpeed < 5.5f)
        //{
        //    c = carColors[3];
        //}

        car.GetComponent<SpriteRenderer>().color = carColors[colorIndex];
        

    }
}

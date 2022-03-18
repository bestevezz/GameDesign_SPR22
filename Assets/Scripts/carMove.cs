using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMove : MonoBehaviour
{
    public float speed = 5.0f;

    private void Start()
    {
        //transform.position = new Vector3(-11, 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Hint: In unity you can get vector direction shorthands like this:
        //Vector3.up etc

        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}

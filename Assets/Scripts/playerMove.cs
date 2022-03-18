using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{

    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");

        float xMovement = (xMove * speed * Time.deltaTime);
        float yMovement = (yMove * speed * Time.deltaTime);

        transform.Translate(xMovement, yMovement, 0);


    }
}

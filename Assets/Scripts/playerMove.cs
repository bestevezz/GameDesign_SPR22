using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Goal")
        {
            Debug.Log("Area cleared");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       //destroys player when it collides with car
        if (collision.gameObject.tag == "Car")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("LoseScreen");
        }
    }
}

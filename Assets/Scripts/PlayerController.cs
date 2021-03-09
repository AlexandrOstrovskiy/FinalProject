using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;

    private float speed = 200.0f;

    private float topBound = 10.0f;
    private float bottomBound = -10.0f;
    private float leftBound = -10.0f;
    private float rightBound = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }


    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalIntup = Input.GetAxis("Vertical");
        CheckBorders();
        playerRigidbody.AddForce(Vector3.forward * speed * verticalIntup * Time.deltaTime);
        playerRigidbody.AddForce(Vector3.right * speed * horizontalInput * Time.deltaTime);
    }


    void CheckBorders()
    {
        if (transform.position.x < leftBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
            playerRigidbody.AddForce(Vector3.right * speed * 5 * Time.deltaTime);
        }
        if (transform.position.x > rightBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
            playerRigidbody.AddForce(Vector3.left * speed * 5 * Time.deltaTime);
        }
        if (transform.position.z < bottomBound)
        {
            playerRigidbody.AddForce(Vector3.forward * speed * 5 * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, bottomBound);
        }
        if (transform.position.z > topBound)
        {
            playerRigidbody.AddForce(Vector3.back * speed * 5 * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, topBound);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            transform.Rotate(0, Random.Range(30, 210), 0);
            playerRigidbody.AddForce(Vector3.forward * speed * 100 * Time.deltaTime);
        }

    }
}

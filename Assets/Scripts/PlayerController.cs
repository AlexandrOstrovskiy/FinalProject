using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float turnSpeed;
    private float horizontalInput;
    private float forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        speed = 21.0f;
        turnSpeed = 21.0f;
        horizontalInput = 0.0f;
        forwardInput = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}

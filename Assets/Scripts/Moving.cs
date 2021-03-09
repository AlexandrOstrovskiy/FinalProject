using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speedMovement = 5.5f;
    private Rigidbody objectRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Move();
        Destroy();
    }

    private void Move()
    {
        objectRigidbody.AddForce(Vector3.forward * -speedMovement * Time.deltaTime);
    }

    private void Destroy()
    {
        if (transform.position.x < -10.0f)
            Destroy(gameObject);
    }
}

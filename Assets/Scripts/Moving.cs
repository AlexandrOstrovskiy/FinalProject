using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speedMovement = 50.0f;
    private Rigidbody objectRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        objectRigidbody = gameObject.GetComponent<Rigidbody>();
        transform.position = new Vector3(0.0f, 0.0f, 20.5f);
        Vector3 lookAtPlayer = GameObject.Find("Player").GetComponent<Transform>().position - transform.position;
        transform.rotation = Quaternion.Euler(lookAtPlayer);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Move();
        //Destroy();
    }

    private void Move()
    {
        objectRigidbody.AddForce(Vector3.forward * (speedMovement) * Time.deltaTime);
    }

    //private void Destroy()
    //{
    //    if (transform.position.x < -10.0f)
    //        Destroy(gameObject);
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IPooledObject
{
    private GameObject player;
    private Rigidbody enemyRigidbody;

    private Vector3 enemySpeed = new Vector3( 10.0f, 10.0f, 10.0f);
    // Start is called before the first frame update

    void Awake()
    {
        player = GameObject.Find("Player");
        enemyRigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(player.transform);
        enemyRigidbody.velocity += enemySpeed * Time.deltaTime;
        enemyRigidbody.AddForce(enemyRigidbody.velocity, ForceMode.Acceleration);
    }

    public void OnObjectSpawn()
    {
        transform.position = new Vector3(0.0f, 0.0f, 180.0f);
        //enemySpeed = new Vector3(Random.Range(1, 42.0f), Random.Range(1, 42.0f), Random.Range(1, 42.0f));
        enemyRigidbody.velocity = enemySpeed;
        enemyRigidbody.AddForce(enemySpeed, ForceMode.Impulse);
    }
}

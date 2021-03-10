using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ChaseTarget(player.transform.position);
    }

    private void ChaseTarget(Vector3 targetPosition)
    {
        Vector3 trajectoryToTarget = targetPosition - transform.position;

        transform.position += trajectoryToTarget * Time.deltaTime;
    }
}

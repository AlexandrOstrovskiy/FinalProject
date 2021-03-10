using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //public GameObject[] enemies;
    //public GameObject powerUp;
    ObjectPooler objectPooler;

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        InvokeRepeating("SpawnEnemy", 3.0f, 5.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //SpawnEnemy();
    }

    void SpawnEnemy()
    {
        ObjectPooler.Instance.SpawnFromPool("Enemy", transform.position, Quaternion.identity);


        //Instantiate(enemies[], spawnPos, enemies[].transform.rotation);
    }
}

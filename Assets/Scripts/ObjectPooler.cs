using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public static ObjectPooler Instance;

    #region Singleton

    private void Awake()
    {
        Instance = this; 
    }

    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPoolQ = new Queue<GameObject>();

            for(int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPoolQ.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPoolQ);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 positionOnSpawn, Quaternion rotationOnSpawn)
    {
        if(!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + "doesn't exists \' [-__-] / ");
            return(null);
        }


        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = positionOnSpawn;
        objectToSpawn.transform.rotation = rotationOnSpawn;

        IPooledObject pooledObject = objectToSpawn.GetComponent<IPooledObject>();

        if (pooledObject != null)
        {
            pooledObject.OnObjectSpawn();
        }

        poolDictionary[tag].Enqueue(objectToSpawn);

        return (objectToSpawn);
    }

}

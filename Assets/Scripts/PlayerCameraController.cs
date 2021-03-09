using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    private Vector3 cameraPosOffset = new Vector3(0.0f, 10.0f, 0.0f);
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        transform.position = cameraPosOffset;
        transform.Rotate(90.0f, 0.0f, 0.0f);
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.transform.position + cameraPosOffset;
    }
}

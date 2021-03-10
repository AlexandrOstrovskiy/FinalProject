using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float horsePower = 100.0f;
    //[SerializeField]
    private float speed;
    private float turnSpeed;
    private int wheelsOnGround;
    private float horizontalInput;
    private float verticalInput;

    private Rigidbody playerRigidbody;

    private WheelCollider[] allWheels;

    [SerializeField]
    private Transform playerCenterOfMass;

    [SerializeField]
    TextMeshProUGUI speedText;

    [SerializeField]
    TextMeshProUGUI rpmText;
    // Start is called before the first frame update

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        allWheels = GetComponentsInChildren<WheelCollider>();
        //playerCenterOfMass = transform.Find("CenterOfMass");
    }

    void Start()
    {
        //speed = 21.0f;
        turnSpeed = 21.0f;
        horizontalInput = 0.0f;
        verticalInput = 0.0f;
        playerRigidbody.centerOfMass = playerCenterOfMass.transform.position;
        InvokeRepeating("HudRpmUpdating", 0.0f, 0.5f);
    }

    private void Update()
    {
        HudSpeedUpdating();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(IsOnGround())
            Moving();
    }


    void Moving()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        playerRigidbody.AddRelativeForce(Vector3.forward * horsePower * verticalInput);

        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
                wheelsOnGround++;
        }
        if (wheelsOnGround == 4)
            return (true);
        else
            return (false);
    }

    void HudSpeedUpdating()
    {
        speed = Mathf.RoundToInt(playerRigidbody.velocity.magnitude * 3.6f);
        speedText.SetText("Speed: " + speed + " Km/h");


    }

    void HudRpmUpdating()
    {
        float rpm = Mathf.RoundToInt((speed % 30.0f) * 40);
        rpmText.SetText("RPM: " + rpm);
    }
}

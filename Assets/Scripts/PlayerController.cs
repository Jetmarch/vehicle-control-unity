using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float vehicleSpeed = 20.0f;
    [SerializeField] private float turnSpeed = 1.0f;
    private float horizontalInput;
    private float forwardInput;
    [SerializeField] private float horseForce;
    [SerializeField] private Transform centerOfMass;

    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private TextMeshProUGUI rpmText;
    [SerializeField] private List<WheelCollider> allWheels;
    [SerializeField] private int wheelsOnGround;

    private float speed;
    private float rpm;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        //Let's move that bloody car
        //transform.Translate(Vector3.forward * Time.deltaTime * vehicleSpeed * forwardInput);
        //rb.AddForce(transform.forward * horseForce * forwardInput);
        if (IsOnGround())
        {
            rb.AddRelativeForce(Vector3.forward * horseForce * forwardInput);
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);


            speed = rb.velocity.magnitude * 2.237f;
            speedometerText.SetText("Speed: " + speed.ToString("F0") + "mph");
            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM: " + rpm);
        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;

        foreach(WheelCollider wheel in allWheels)
        {
            if(wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        if(wheelsOnGround == allWheels.Count)
        {
            return true;
        }

        return false;
    }
}

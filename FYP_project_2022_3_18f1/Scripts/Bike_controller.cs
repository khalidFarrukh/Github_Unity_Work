using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class Bike_controller : MonoBehaviour
{
    [Header("RigidBody")]
    public Rigidbody rb;

    [Header("Wheel colliders")]
    public WheelCollider frontWheelCollider;
    public WheelCollider backWheelCollider;

    [Header("Wheel Transform")]
    public Transform frontWheelTransform;
    public Transform backWheelTransform;

    [Header("Handle Transform")]
    public Transform cycleHandle;

    [Header("Bike Power")]
    public float maxSpeed = 60f;
    public float maxMotorTorque = 15f;
    public float currentSpeed;
    public float maxBrakeTorque = 150f;
    private float presentBreakForce = 0f;

    [Header("Bike steering")]
    public float maxSteerAngle = 35f;
    private float presentTurnAngle = 0f;

    float verticalInput = 0f;
    float HorizontalInput = 0f;

    public static bool isDownbtn;
    public static bool isRightbtn;
    public static bool isLeftbtn;
    public static bool isBrakingbtn;

    private void FixedUpdate()
    {
        Vector3 rotation = transform.localEulerAngles;
        rotation.z = 0;
        transform.localEulerAngles = rotation;
    }
    private void Update()
    {
        MoveBike();
        ApplyBrake();
        SteerBike();
    }

    private void MoveBike()
    {
        currentSpeed = 2 * Mathf.PI * backWheelCollider.radius * backWheelCollider.rpm * 60 / 1000;
        if (currentSpeed < maxSpeed)
        {

            if (Input.GetKey(KeyCode.S)|| isDownbtn)
            {
                backWheelCollider.motorTorque =-1* maxMotorTorque;
            }
            else
            {
                backWheelCollider.motorTorque = 1 * maxMotorTorque;
            }
        }
        else
        {
            backWheelCollider.motorTorque = 0;
        }
    }

    async void Delay(int v)
    {
        await Task.Delay(v);
    }

    private void ApplyBrake()
    {
        if (Input.GetKey(KeyCode.Space) || isBrakingbtn)
        {
            frontWheelCollider.brakeTorque = maxBrakeTorque;
            backWheelCollider.brakeTorque = maxBrakeTorque;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            frontWheelCollider.brakeTorque = 0;
            backWheelCollider.brakeTorque = 0;
            rb.constraints = RigidbodyConstraints.FreezeRotationZ;
        }
    }

    private void SteerBike(){
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || isRightbtn)
        {
            if (HorizontalInput < 1f)
            {
                Delay(150);
                HorizontalInput += 0.1f;
            }
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || isLeftbtn)
        {
            if (HorizontalInput > -1f)
            {
                Delay(150);
                HorizontalInput -= 0.1f;
            }
        }
        else
        {
            HorizontalInput = 0;
        }
        presentTurnAngle = maxSteerAngle * HorizontalInput;
        frontWheelCollider.steerAngle = presentTurnAngle;
        movewheels(frontWheelCollider, frontWheelTransform);
        movewheels(backWheelCollider, backWheelTransform);
    }

    private void movewheels(WheelCollider WC, Transform WT)
    {
        Vector3 position;
        Quaternion rotation;
        WC.GetWorldPose(out position, out rotation);
    }

}

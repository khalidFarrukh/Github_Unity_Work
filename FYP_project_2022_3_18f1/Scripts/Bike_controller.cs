using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float maxSpeed = 15f;
    public float maxMotorTorque = 10f;
    public float currentSpeed;
    public float maxBrakeTorque = 150f;
    private float presentBreakForce = 0f;
    private bool isBraking = false;

    [Header("Bike steering")]
    public float maxSteerAngle = 35f;
    private float presentTurnAngle = 0f;


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
            backWheelCollider.motorTorque = maxMotorTorque* Input.GetAxis("Vertical");
        }
        else
        {
            backWheelCollider.motorTorque = 0;
        }
    }

    private void ApplyBrake()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            isBraking = true;
            frontWheelCollider.brakeTorque = maxBrakeTorque;
            backWheelCollider.brakeTorque = maxBrakeTorque;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else
        {
            isBraking = false;
            frontWheelCollider.brakeTorque = 0;
            backWheelCollider.brakeTorque = 0;
            rb.constraints = RigidbodyConstraints.FreezeRotationZ;
        }
    }

    private void SteerBike(){
        presentTurnAngle = maxSteerAngle * Input.GetAxis("Horizontal");
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

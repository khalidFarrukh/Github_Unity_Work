using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike_controller : MonoBehaviour
{
    [Header("Wheel colliders")]
    public WheelCollider frontWheelCollider;
    public WheelCollider backWheelCollider;

    [Header("Wheel Transform")]
    public Transform frontWheelTransform;
    public Transform backWheelTransform;

    [Header("Handle Transform")]
    public Transform cycleHandle;

    [Header("Bike Power")]
    public float accelerationForce = 200f;
    public float breakingForce = 3000f;
    private float presentBreakForce = 0f;
    private float presentAcceleration = 0f;

    [Header("Bike steering")]
    public float steeringAngle = 35f;
    private float presentTurnAngle = 0f;


    private void Update()
    {
        MoveBike();
        SteerBike();
    }

    private void MoveBike()
    {
        backWheelCollider.motorTorque = presentAcceleration;
        presentAcceleration = accelerationForce * Input.GetAxis("Vertical");
    }

    private void SteerBike(){
        presentTurnAngle = steeringAngle * Input.GetAxis("Horizontal");
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

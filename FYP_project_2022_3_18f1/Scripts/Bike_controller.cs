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
    public float accelerationForce = 0f;
    public float breakingForce = 200f;
    private float presentBreakForce = 0f;
    private float presentAcceleration = 0f;

    [Header("Bike steering")]
    public float steeringAngle = 35f;
    private float presentTurnAngle = 0f;

    private float counter=0;
    int i = 0;

    private void FixedUpdate()
    {
        Vector3 rotation = transform.localEulerAngles;
        rotation.z = 0;
        transform.localEulerAngles = rotation;
    }
    private void Update()
    {
        Default();
        MoveBike();
        ApplyBrake();
        SteerBike();
    }
    private void Default()
    {
        /*if (!Input.anyKey)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }*/
    }


    private void MoveBike()
    {
        backWheelCollider.motorTorque = presentAcceleration;
        presentAcceleration = accelerationForce * Input.GetAxis("Vertical");
    }

    private void ApplyBrake()
    {
        Rigidbody temprb = rb;
       
        if (Input.GetKey(KeyCode.Space)){
            frontWheelCollider.brakeTorque = breakingForce;
            backWheelCollider.brakeTorque = breakingForce;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        else if(!Input.GetKey(KeyCode.UpArrow))
        {
            frontWheelCollider.brakeTorque = 0;
            backWheelCollider.brakeTorque = 0;
            /*rb.velocity = new Vector3(0, 0, 0);*/
            rb.constraints = RigidbodyConstraints.FreezeRotationZ;
        }

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

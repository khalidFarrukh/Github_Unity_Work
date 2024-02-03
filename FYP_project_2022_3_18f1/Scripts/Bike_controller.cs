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
    public float maxForwardMotorTorque = 15f;
    public float maxReverseMotorTorque = 7f;
    public float currentSpeed=0f;
    public float maxBrakeTorque = 150f;
    private float presentBreakForce = 0f;

    [Header("Bike steering")]
    public float maxSteerAngle = 11f;
    private float presentTurnAngle = 0f;

    float verticalInput = 0f;
    float HorizontalInput = 0f;

    public static bool isReverseBtn;
    public static bool isRightbtn;
    public static bool isLeftbtn;
    public static bool isBrakingbtn;

    [SerializeField] private float TempCurrentSpeed;

    [SerializeField] private AudioSource BackTireSound;

    private void FixedUpdate()
    {
        Vector3 rotation = transform.localEulerAngles;
        rotation.z = 0;
        transform.localEulerAngles = rotation;

        float pitch = Mathf.Lerp(0, 0.5f, currentSpeed / maxForwardMotorTorque);
        float volume = Mathf.Lerp(0, 0.5f, currentSpeed / maxForwardMotorTorque);
        var localVel = transform.InverseTransformDirection(rb.velocity);
        
        /*if (!isReverseBtn && currentSpeed >= 0)
        {
            BackTireSound.volume = volume;
            BackTireSound.pitch = pitch;
        }
        else
        {
            BackTireSound.volume = 0;
            BackTireSound.pitch = 0;
        }*/
    }
    private void Update()
    {
        if (Timer_script.PlayerCanMove)
        {
            MoveBike();
        }
        ApplyBrake();
        SteerBike();
    }

    private void MoveBike()
    {
        currentSpeed = rb.velocity.magnitude * 3.6F;
        
        if (currentSpeed < maxSpeed)
        {
            if (Input.GetKey(KeyCode.S)|| isReverseBtn)
            {
                backWheelCollider.motorTorque = -1* maxReverseMotorTorque;;
            }
            else
            {
                backWheelCollider.motorTorque = maxForwardMotorTorque;
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

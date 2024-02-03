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
    public float TireRotateFactor = 2f;
    public float currentTireRotation;

    [Header("Cycle Pivot Transform")]
    public Transform cyclePivot;
    public float maxTiltAngle = 6f;
    private float CurrentTiltingAngle = 0f;

    [Header("Handle Transform")]
    public Transform cycleHandle;
    
    [Header("Cycle pedal Transform")]
    public Transform cycle_pedal;
    public float currentPedalRotation;

    [Header("Bike Power")]
    public float maxSpeed = 60f;
    public float maxForwardMotorTorque = 15f;
    public float maxReverseMotorTorque = 7f;
    public float currentSpeed=0f;
    public float maxBrakeTorque = 150f;
    private float presentBreakForce = 0f;

    [Header("Bike steering")]
    public float maxSteerAngle = 11f;
    private float CurrentSteeringAngle = 0f;

    float verticalInput = 0f;
    float HorizontalInput = 0f;

    public static bool isReverseBtn;
    public static bool isRightbtn;
    public static bool isLeftbtn;
    public static bool isBrakingbtn;
    public static bool isSprintbtn;

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
        Set_turning_transformation_to_cycle();
        Make_Tires_rotate_wrt_speed();
        pedal_rotation();
    }

    private void MoveBike()
    {
        currentSpeed = rb.velocity.magnitude * 3.6F;
        
        if (currentSpeed < maxSpeed)
        {
            if (Input.GetKey(KeyCode.S) || isReverseBtn)
            {
                backWheelCollider.motorTorque = -1 * maxReverseMotorTorque; ;
            }
            else
            {
                if (currentSpeed <= 10f)
                {
                    backWheelCollider.motorTorque = 15f;
                }
                else if (currentSpeed > 10f && currentSpeed<=25f)
                {
                    backWheelCollider.motorTorque = 16f;
                }
               /* else if (currentSpeed > 10f)
                {
                    backWheelCollider.motorTorque = 20f;
                }*/
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
            /*frontWheelCollider.brakeTorque = maxBrakeTorque;*/
            frontWheelCollider.brakeTorque = Mathf.MoveTowards(40f, maxBrakeTorque, 15 * Time.deltaTime);
            backWheelCollider.brakeTorque = Mathf.MoveTowards(40f, maxBrakeTorque, 15 * Time.deltaTime);
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
            HorizontalInput = Mathf.MoveTowards(HorizontalInput, 1f, 3 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || isLeftbtn)
        {
            HorizontalInput = Mathf.MoveTowards(HorizontalInput, -1f, 3 * Time.deltaTime);
        }
        else
        {
            HorizontalInput = Mathf.MoveTowards(HorizontalInput, 0f, 3 *Time.deltaTime);
        }
        if (currentSpeed < 5f)
        {
            maxSteerAngle = 22f;
        }
        else
        {
            maxSteerAngle = Mathf.MoveTowards(maxSteerAngle, 11f, 3 * Time.deltaTime);
        }
        CurrentSteeringAngle = maxSteerAngle * HorizontalInput;
        frontWheelCollider.steerAngle = CurrentSteeringAngle;
       
    }
    private void Set_turning_transformation_to_cycle()
    {
        CurrentTiltingAngle = maxTiltAngle * HorizontalInput;
        cycleHandle.localEulerAngles = new Vector3(0f, CurrentSteeringAngle, 0f);
        if (currentSpeed > 1.5f && !Input.GetKey(KeyCode.S))
        {
            cyclePivot.localEulerAngles = new Vector3(0f, 0f, -1 * CurrentTiltingAngle * 3);
        }
        else if(currentSpeed > 1.5f &&Input.GetKey(KeyCode.S) || isReverseBtn)
        {
            cyclePivot.localEulerAngles = Vector3.zero;
        }
    }
    private void Make_Tires_rotate_wrt_speed()
    {
        currentTireRotation += currentSpeed;
        currentTireRotation %= 360;
        frontWheelTransform.localEulerAngles = new Vector3(currentTireRotation, 0f, 0f);
        backWheelTransform.localEulerAngles = new Vector3(currentTireRotation, 0f, 0f);
    }
    private void pedal_rotation()
    {
        currentPedalRotation += currentSpeed;
        currentPedalRotation %= 360;
        cycle_pedal.localEulerAngles = new Vector3(currentPedalRotation, 0f, 0f);
        cycle_pedal.GetChild(0).transform.localEulerAngles = new Vector3(-1 * currentPedalRotation, 0f, 0f);
        cycle_pedal.GetChild(1).transform.localEulerAngles = new Vector3(currentPedalRotation, 0f, 0f);
    }

}

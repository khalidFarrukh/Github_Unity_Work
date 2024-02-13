using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Bike_controller1 : MonoBehaviour
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
    public float CurrentTiltingAngle = 0f;

    [Header("Handle Transform")]
    public Transform cycleHandle;

    [Header("Cycle pedal Transform")]
    public Transform cycle_pedal;
    public float currentPedalRotation;

    [Header("Bike Power")]
    public float maxForwadSpeed = 15f;
    public float maxMotorTorque = 10f;
    public static float currentForwardSpeed = 0f;
    public float currentForwardSpeedTemp = 0f;
    public float maxBrakeTorque = 150f;
    private float presentBreakForce = 0f;
    public bool isBraking = false;

    [Header("Bike steering")]
    public float maxSteerAngle = 11f;
    public float CurrentSteeringAngle;
    public float targetSteerAngle = 0f;
    public float turnSpeed = 5f;

    [Header("Waypoints")]
    public List<Transform> Track_waypoints;
    private List<Transform> nodes;
    public int goal = 0;

    [Header("cycle sensors")]
    public GameObject sensors;
    public float sensor_0D_Length =5f;
    public float sensor_20D_Length =5f;
    public float sensor_40D_Length =5f;

    public bool avoiding = false;
    public float total_avoid_multiplier = 0f;
    public int layerMask;
    public int layerNumber = 7;

    [Header("Audio FX")]
    [SerializeField] private AudioSource BackTireSound;


    private void Start()
    {
        layerMask = 1 << layerNumber;
        Transform waypoints = Track_waypoints[0];
        Transform[] waypoint_objects = waypoints.GetComponentsInChildren<Transform>();
        if (GameManager.Instance != null)
        {
            switch (GameManager.Instance.PlayerCycleTrackType)
            {
                case 1:
                    waypoints = Track_waypoints[0];
                    waypoint_objects = waypoints.GetComponentsInChildren<Transform>();
                    break;
                case 2:
                    waypoints = Track_waypoints[1];
                    waypoint_objects = waypoints.GetComponentsInChildren<Transform>();
                    break;
                case 3:
                    waypoints = Track_waypoints[2];
                    waypoint_objects = waypoints.GetComponentsInChildren<Transform>();
                    break;
                case 4:
                    waypoints = Track_waypoints[3];
                    waypoint_objects = waypoints.GetComponentsInChildren<Transform>();
                    break;
                case 5:
                    waypoints = Track_waypoints[4];
                    waypoint_objects = waypoints.GetComponentsInChildren<Transform>();
                    break;
            }  
        }
        nodes = new List<Transform>();
        for (int i = 0; i < waypoint_objects.Length; i++)
        {
            if (waypoint_objects[i] != waypoints.transform)
            {
                nodes.Add(waypoint_objects[i]);
            }
        }
    }
    private void FixedUpdate()
    {
        Vector3 rotation = transform.localEulerAngles;
        rotation.z = 0;
        transform.localEulerAngles = rotation;
        if (currentForwardSpeed >= 0)
        {
            BackTireSound.volume = Mathf.Lerp(0, 0.5f, currentForwardSpeed / maxMotorTorque);
            BackTireSound.pitch = Mathf.Lerp(0, 0.5f, currentForwardSpeed / maxMotorTorque);
        }
        else
        {
            BackTireSound.volume = 0;
            BackTireSound.pitch = 0;
        }
        if (Timer_script.PlayerCanMove)
        {
            currentForwardSpeedTemp = currentForwardSpeed;
            Sensors();
            AI_Move();
            AI_Steer();
            AI_Braking();
            HandleController();
            TiltController();
            Make_Tires_rotate_wrt_speed();
            pedal_rotation();
            LerpToSteerAngle();
            CheckWaypointDistance();
        }
    }

    private void Sensors()
    {
        RaycastHit hit;
        Transform sensor = sensors.transform.GetChild(0).gameObject.transform;
        total_avoid_multiplier = 0f;
        float AM_L40D = 0f;
        float AM_L20D = 0f;
        float AM_0D = 0f;
        float AM_R20D = 0f;
        float AM_R40D = 0f;
        avoiding = false;

        if (Physics.Raycast(sensor.position, Quaternion.AngleAxis(-40f, transform.up) * transform.forward, out hit, sensor_40D_Length))
        {
            if (hit.collider.CompareTag("obstacle")|| hit.collider.CompareTag("track_wall"))
            {
                Debug.DrawRay(sensor.position, Quaternion.AngleAxis(-40f, transform.up) * transform.forward * hit.distance, Color.yellow);
                avoiding = true;
                AM_L40D = .5f;
            }
        }
        sensor = sensors.transform.GetChild(1).gameObject.transform;
        if (Physics.Raycast(sensor.position, Quaternion.AngleAxis(-20f, transform.up) * transform.forward, out hit, sensor_20D_Length))
        {
            if (hit.collider.CompareTag("obstacle") || hit.collider.CompareTag("track_wall"))
            {
                Debug.DrawRay(sensor.position, Quaternion.AngleAxis(-20f, transform.up) * transform.forward * hit.distance, Color.yellow);
                avoiding = true;
                AM_L20D = .75f;
            }
        }
        sensor = sensors.transform.GetChild(3).gameObject.transform;
        if (Physics.Raycast(sensor.position, Quaternion.AngleAxis(20f, transform.up) * transform.forward, out hit, sensor_20D_Length))
        {
            if (hit.collider.CompareTag("obstacle") || hit.collider.CompareTag("track_wall"))
            {
                Debug.DrawRay(sensor.position, Quaternion.AngleAxis(20f, transform.up) * transform.forward * hit.distance, Color.yellow);
                avoiding = true;
                AM_R20D = -.75f;
            }
        }
        sensor = sensors.transform.GetChild(4).gameObject.transform;
        if (Physics.Raycast(sensor.position, Quaternion.AngleAxis(40f, transform.up) * transform.forward, out hit, sensor_40D_Length))
        {
            if (hit.collider.CompareTag("obstacle") || hit.collider.CompareTag("track_wall"))
            {
                Debug.DrawRay(sensor.position, Quaternion.AngleAxis(40f, transform.up) * transform.forward * hit.distance, Color.yellow);
                avoiding = true;
                AM_R40D = -.5f;
            }
        } 
            sensor = sensors.transform.GetChild(2).gameObject.transform;
        if (Physics.Raycast(sensor.position, Quaternion.AngleAxis(0f, transform.up) * transform.forward, out hit, sensor_0D_Length))
        {
            if (hit.collider.CompareTag("obstacle") || hit.collider.CompareTag("track_wall"))
            {
                Debug.DrawRay(sensor.position, Quaternion.AngleAxis(0f, transform.up) * transform.forward * hit.distance, Color.yellow);
                avoiding = true;
                if (hit.normal.x < 0)
                {
                    AM_0D = -1;
                }
                else
                {
                    AM_0D = 1;
                }
            }
        }
        total_avoid_multiplier = AM_L40D + AM_L20D + AM_0D + AM_R20D + AM_R40D;
        if (avoiding)
        {
            targetSteerAngle = maxSteerAngle * total_avoid_multiplier;
        }

    }
    private void AI_Steer()
    {
        if (avoiding) { return; }
        if (currentForwardSpeedTemp < 5f)
        {
            maxSteerAngle = 11f;
        }
        else
        {
            maxSteerAngle = 22f;
        }
        Vector3 relative_vector = transform.InverseTransformPoint(nodes[goal].position);
        float newSteer = (relative_vector.x / relative_vector.magnitude) * maxSteerAngle;
        targetSteerAngle = newSteer;
    }
    private void AI_Move()
    {
        currentForwardSpeed = rb.velocity.magnitude * 3.6F;
        if (currentForwardSpeed < maxForwadSpeed && !isBraking)
        {
            backWheelCollider.motorTorque = maxMotorTorque;
        }
        else
        {
            backWheelCollider.motorTorque = 0;
        }
    }

    private void AI_Braking()
    {

        /*if (Input.GetKey(KeyCode.Space))
        {
            isBraking = true;
            frontWheelCollider.brakeTorque = maxBrakeTorque;
        }
        else
        {
            isBraking = false;
            frontWheelCollider.brakeTorque = 0;
        }*/
    }
    private void LerpToSteerAngle()
    {
        /*CurrentSteeringAngle = Mathf.Lerp(frontWheelCollider.steerAngle, targetSteerAngle, Time.deltaTime * turnSpeed);*/
        CurrentSteeringAngle = Mathf.MoveTowards(CurrentSteeringAngle, targetSteerAngle, Time.deltaTime * turnSpeed);
        frontWheelCollider.steerAngle = CurrentSteeringAngle;
        
    }
    private void HandleController()
    {
        cycleHandle.localEulerAngles = new Vector3(0f, 1.5f*CurrentSteeringAngle, 0f);
    }
    private void TiltController()
    {
        /*CurrentTiltingAngle = maxTiltAngle * (CurrentSteeringAngle / maxSteerAngle);*/
        cyclePivot.localEulerAngles = new Vector3(0f, 0f, -CurrentSteeringAngle);
    }
    private void Make_Tires_rotate_wrt_speed()
    {
        currentTireRotation += currentForwardSpeed;
        currentTireRotation %= 360;
        frontWheelTransform.localEulerAngles = new Vector3(currentTireRotation, 0f, 0f);
        backWheelTransform.localEulerAngles = new Vector3(currentTireRotation, 0f, 0f);
        
    }
    private void pedal_rotation()
    {
        currentPedalRotation += currentForwardSpeed*.5f;
        currentPedalRotation %= 360;
        cycle_pedal.localEulerAngles = new Vector3(currentPedalRotation, 0f, 0f);
        cycle_pedal.GetChild(0).transform.localEulerAngles = new Vector3(-currentPedalRotation, 0f, 0f);
        cycle_pedal.GetChild(1).transform.localEulerAngles = new Vector3(-currentPedalRotation, 0f, 0f);
    }
    private void CheckWaypointDistance()
    {
        if (Vector3.Distance(transform.position, nodes[goal].position) < 3f)
        {
            if (goal == nodes.Count - 1)
            {
                goal = 0;
            }
            else
            {
                goal++;
            }
        }
    }
}

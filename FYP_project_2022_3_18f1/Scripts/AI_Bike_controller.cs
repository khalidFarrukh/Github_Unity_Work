using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Bike_controller : MonoBehaviour
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
    public float maxSpeed = 15f;
    public float maxMotorTorque = 10f;
    public float currentSpeed;
    public float maxBrakeTorque = 150f;
    private float presentBreakForce = 0f;
    public bool isBraking = false;

    [Header("Bike steering")]
    public float maxSteerAngle = 35f;
    private float presentTurnAngle = 0f;
    private float targetSteerAngle = 0f;
    private float turnSpeed = 5f;

    [Header("AI Goal to follow")]
    public Transform Track1_goal;
    public Transform Track2_goal;
    public Transform Track3_goal;
    public Transform Track4_goal;
    public Transform Track5_goal;
    private Transform goal_to_follow;

    [Header("cycle sensors")]


    private GlobalCycleTrackChoice _GlobalCycleTrackChoice;
    private Vector3 relative_vector;
    private void Awake()
    {
        goal_to_follow = Track1_goal;
    }
    private void Start()
    {
        /*goal_to_follow = Track1_goal;*/
        /*switch (_GlobalCycleTrackChoice.TrackImport)
        {
            case 1:
                goal_to_follow = Track1_goal;
                break;
            case 2:
                goal_to_follow = Track2_goal;
                break;
            case 3:
                goal_to_follow = Track3_goal;
                break;
            case 4:
                goal_to_follow = Track4_goal;
                break;
            case 5:
                goal_to_follow = Track5_goal;
                break;
        }*/
    }

    private void FixedUpdate()
    {
        Vector3 rotation = transform.localEulerAngles;
        rotation.z = 0;
        transform.localEulerAngles = rotation;
        if (Timer_script.PlayerCanMove)
        {
            AI_Move();
        }
        AI_Braking();
        AI_Steer();
    }

    private void AI_Steer()
    {
        relative_vector = transform.InverseTransformPoint(goal_to_follow.position);
        targetSteerAngle = (relative_vector.x / relative_vector.magnitude) * maxSteerAngle;
	    LerpToSteerAngle();
    }
    private void AI_Move()
    {
        currentSpeed = 2 * Mathf.PI * backWheelCollider.radius * backWheelCollider.rpm * 60 / 1000;
        if (currentSpeed < maxSpeed && !isBraking)
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

        if (Input.GetKey(KeyCode.Space))
        {
            isBraking = true;
            frontWheelCollider.brakeTorque = maxBrakeTorque;
        }
        else
        {
            isBraking = false;
            frontWheelCollider.brakeTorque = 0;
        }
    }
    private void LerpToSteerAngle()
    {
        frontWheelCollider.steerAngle = Mathf.Lerp(frontWheelCollider.steerAngle, targetSteerAngle, Time.deltaTime * turnSpeed);
    }
}

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
    public float accelerationForce = 200f;
    public float breakingForce = 3000f;
    private float presentBreakForce = 0f;
    private float presentAcceleration = 0f;

    [Header("Bike steering")]
    public float maxSteerAngle = 22f;
    private float presentTurnAngle = 0f;
    private float targetSteerAngle = 0f;
    private float turnSpeed = 5f;

    [Header("Waypoints")]
    public Transform waypoints;
    private List<Transform> nodes;
    public int goal = 0;
    private Vector3 relative_vector;
    private void Start()
    {
        Transform[] waypoint_objects = waypoints.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();
        for (int i=0; i<waypoint_objects.Length;i++)
        {
            if (waypoint_objects[i]!= waypoints.transform)
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
    }
    private void Update()
    {
        AI_Move();
        AI_Steer();
	CheckWaypointDistance();
    }

    private void AI_Steer()
    {
        relative_vector = transform.InverseTransformPoint(nodes[goal].position);
        //frontWheelCollider.steerAngle = (relative_vector.x / relative_vector.magnitude) * maxSteerAngle;
        targetSteerAngle = (relative_vector.x / relative_vector.magnitude) * maxSteerAngle;
	LerpToSteerAngle();

    }
    private void AI_Move()
    {
        backWheelCollider.motorTorque = presentAcceleration;
        presentAcceleration = accelerationForce * 1;
    }
    private void CheckWaypointDistance()
    {
	if(Vector3.Distance(transform.position,nodes[goal].position)<1.5f)
	{
	    if(goal == nodes.Count-1)
	    {
		goal = 0;
	    }
	    else
	    {
		goal++;
	    }
	}
    }
    private void LerpToSteerAngle()
    {
        frontWheelCollider.steerAngle = Mathf.Lerp(frontWheelCollider.steerAngle, targetSteerAngle, Time.deltaTime * turnSpeed);
    }
}

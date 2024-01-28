using UnityEngine;

public class Bike_controller_2 : MonoBehaviour
{
    [SerializeField] float motorTorque, brakeTorque, 
    maxSteeringAngle, maxSpeed, cycleRotation;

    [SerializeField] WheelCollider frontWheelCollider, backWheelCollider;
    
    Rigidbody rb;

    public static bool isAccelerating, isBraking, isTurningLeft, isTurningRight;

    float steeringAngle =0;

    void awake(){
        rb = GetComponent<Rigidbody>();
    }

    void Update(){
        if(isAccelerating){
            backWheelCollider.motorTorque = Mathf.Clamp(motorTorque,-maxSpeed,maxSpeed);
        }
        else{
            backWheelCollider.motorTorque = 0;
        }

        if(isBraking){
            frontWheelCollider.brakeTorque = brakeTorque;
            backWheelCollider.brakeTorque = brakeTorque;
        }
        else{
            frontWheelCollider.brakeTorque = 0;
            backWheelCollider.brakeTorque = 0;
        }
        steeringAngle = 0; 
        if(isTurningLeft){
            steeringAngle = -maxSteeringAngle;
        }
        else if(isTurningRight){
            steeringAngle = maxSteeringAngle;
        }

        frontWheelCollider.steerAngle = steeringAngle;
    }

}

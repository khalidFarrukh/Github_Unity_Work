using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint_script : MonoBehaviour
{
    public AI_Bike_controller ai_bike_controller;
    
    void OnTriggerEnter()
    {
        Debug.Log("go to next goal ");
        ai_bike_controller.goal+=1;
    }
}

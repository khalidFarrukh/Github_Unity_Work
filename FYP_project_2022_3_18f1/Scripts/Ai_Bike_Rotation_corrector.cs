using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Bike_Rotation_corrector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "track_tag")
        {
            this.gameObject.transform.localEulerAngles = new Vector3(0f, -48.609f, 0f);  
        }
    }
}

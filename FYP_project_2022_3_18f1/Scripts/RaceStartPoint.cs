using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceStartPoint : MonoBehaviour
{
    [SerializeField] private Transform track1_start_point;
    [SerializeField] private Transform track2_start_point;
    [SerializeField] private Transform track3_start_point;
    [SerializeField] private Transform track4_start_point;
    [SerializeField] private Transform track5_start_point;


    // Start is called before the first frame update
    private void Awake() 
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if(GlobalCycleTrack.TrackType==1)
        {
            rb.position = track1_start_point.position;
            rb.rotation = track1_start_point.rotation;
        }
        if (GlobalCycleTrack.TrackType == 2)
        {
            rb.position = track2_start_point.position;
            rb.rotation = track2_start_point.rotation;
        }
        if (GlobalCycleTrack.TrackType == 3)
        {
            rb.position = track3_start_point.position;
            rb.rotation = track3_start_point.rotation;
        }
        if (GlobalCycleTrack.TrackType == 4)
        {
            rb.position = track4_start_point.position;
            rb.rotation = track4_start_point.rotation;
        }
        if (GlobalCycleTrack.TrackType == 5)
        {
            rb.position = track5_start_point.position;
            rb.rotation = track5_start_point.rotation;
        }
    }
}

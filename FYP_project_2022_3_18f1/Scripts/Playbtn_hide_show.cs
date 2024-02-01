using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playbtn_hide_show : MonoBehaviour
{
    [SerializeField] private GameObject playbtn;
    // Update is called once per frame
    void Update()
    {
        if(GlobalCycleTrack.TrackType != 0)
        {
            playbtn.SetActive(true);
        }
        else
        {
            playbtn.SetActive(false);
        }
    }
}

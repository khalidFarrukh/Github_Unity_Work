using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCycleTrackChoice : MonoBehaviour
{
    public GameObject Track1;
    public GameObject Track2;
    public GameObject Track3;
    public GameObject Track4;
    public GameObject Track5;

    public int TrackImport;
    // Start is called before the first frame update
    void Start()
    {
        TrackImport = GlobalCycleTrack.TrackType;
        if(TrackImport == 1)
        {
            Track1.SetActive(true);
        }
        if (TrackImport == 2)
        {
            Track2.SetActive(true);
        }
        if (TrackImport == 3)
        {
            Track3.SetActive(true);
        }
        if (TrackImport == 4)
        {
            Track4.SetActive(true);
        }
        if (TrackImport == 5)
        {
            Track5.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

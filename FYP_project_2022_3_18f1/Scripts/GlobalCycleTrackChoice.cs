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
            Track2.SetActive(false);
            Track3.SetActive(false);
            Track4.SetActive(false);
            Track5.SetActive(false);
        }
        if (TrackImport == 2)
        {
            Track1.SetActive(false);
            Track2.SetActive(true);
            Track3.SetActive(false);
            Track4.SetActive(false);
            Track5.SetActive(false);
        }
        if (TrackImport == 3)
        {
            Track1.SetActive(false);
            Track2.SetActive(false);
            Track3.SetActive(true);
            Track4.SetActive(false);
            Track5.SetActive(false);
        }
        if (TrackImport == 4)
        {
            Track1.SetActive(false);
            Track2.SetActive(false);
            Track3.SetActive(false);
            Track4.SetActive(true);
            Track5.SetActive(false);
        }
        if (TrackImport == 5)
        {
            Track1.SetActive(false);
            Track2.SetActive(false);
            Track3.SetActive(false);
            Track4.SetActive(false);
            Track5.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCycleTrack : MonoBehaviour
{
    public void map1()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.PlayerCycleTrackType = 1;
        }
    }
    public void map2()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.PlayerCycleTrackType = 2;
        }
    }
    public void map3()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.PlayerCycleTrackType = 3;
        }
    }
    public void map4()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.PlayerCycleTrackType = 4;
        }
    }
    public void map5()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.PlayerCycleTrackType = 5;
        }
    }
    
}

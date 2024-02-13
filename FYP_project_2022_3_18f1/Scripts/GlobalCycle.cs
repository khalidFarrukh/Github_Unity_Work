using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCycle : MonoBehaviour
{
    public void WhiteCycle()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.PlayerCycleType = 0;
        }
    }
    public void YellowCycle()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.PlayerCycleType = 1;
        }
    }
    public void BlueCycle()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.PlayerCycleType = 2;
        }
    }
    public void RedCycle()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.PlayerCycleType = 3;
        }
    }
    public void OrangeCycle()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.PlayerCycleType = 4;
        }
    }
    public void GreenCycle()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.PlayerCycleType = 5;
        }
    }
    public void BlackCycle()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.PlayerCycleType = 6;
        }
    }
}

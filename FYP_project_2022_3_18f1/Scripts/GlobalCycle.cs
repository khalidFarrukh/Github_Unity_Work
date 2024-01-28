using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCycle : MonoBehaviour
{
    public static int CycleType;
    public void WhiteCycle()
    {
        CycleType = 0;
    }
    public void YellowCycle()
    {
        CycleType = 1;
    }
    public void BlueCycle()
    {
        CycleType = 2;
    }
    public void RedCycle()
    {
        CycleType = 3;
    }
    public void OrangeCycle()
    {
        CycleType = 4;
    }
    public void GreenCycle()
    {
        CycleType = 5;
    }
    public void BlackCycle()
    {
        CycleType = 6;
    }
}

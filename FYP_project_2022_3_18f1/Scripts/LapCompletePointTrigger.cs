using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LapCompletePointTrigger : MonoBehaviour
{
    public GameObject BestMinuteBox;
    public GameObject BestSecondBox;
    public GameObject BestMilliBox;
    public int MinCount;
    public int SecCount;
    public int MilliCount;
    bool bestTimeFlag;
    
    private void Start()
    {
        MinCount = 0;
        SecCount = 0;
        MilliCount = 0;
        bestTimeFlag = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (bestTimeFlag == true)
        {
            int previousTotalTime = ((MinCount * 60) * 10) + (SecCount * 10) + MilliCount;
            int NewTotalTime = ((LapTimeManager.MinCount * 60) * 10) + (LapTimeManager.SecCount * 10) + LapTimeManager.MilliCountInt;

            if (previousTotalTime > NewTotalTime)
            {
                MinCount = LapTimeManager.MinCount;
                SecCount = LapTimeManager.SecCount;
                MilliCount = LapTimeManager.MilliCountInt;
            }
                
        }
        else
        {
            MinCount = LapTimeManager.MinCount;
            SecCount = LapTimeManager.SecCount;
            MilliCount = LapTimeManager.MilliCountInt;
            bestTimeFlag = true;
        }
        BestMilliBox.GetComponent<TMP_Text>().text = " " + MilliCount;
        if (SecCount <= 9)
        {
            BestSecondBox.GetComponent<TMP_Text>().text = " 0" + SecCount + " .";
        }
        else
        {
            BestSecondBox.GetComponent<TMP_Text>().text = " " + SecCount + " .";
        }
        if (SecCount >= 60)
        {
            SecCount = 0;
            MinCount += 1;
        }
        if (MinCount <= 9)
        {
            BestMinuteBox.GetComponent<TMP_Text>().text = "0" + MinCount + " :";
        }
        else
        {
            BestMinuteBox.GetComponent<TMP_Text>().text = "" + MinCount + " :";
        }
        LapTimeManager.MinCount = 0;
        LapTimeManager.SecCount = 0;
        LapTimeManager.MilliCount = 0;
    }
}

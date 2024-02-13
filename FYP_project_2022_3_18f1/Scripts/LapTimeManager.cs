using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LapTimeManager : MonoBehaviour
{
    public static int MinCount;
    public static int SecCount;
    public static float MilliCount;
    public static int MilliCountInt;

    public GameObject MinuteBox;
    public GameObject SecondBox;
    public GameObject MilliBox;

    // Update is called once per frame
    void Update()
    {
        if (Timer_script.PlayerCanMove)
        {
            MilliCount += Time.deltaTime * 10;
            MilliCountInt = (int)MilliCount;
            if (MilliCountInt >= 10)
            {
                MilliCount = 0;
                SecCount += 1;
            }

            if (MilliCountInt < 10)
            {
                MilliBox.GetComponent<TMP_Text>().text = " " + MilliCountInt;
            }


            if (SecCount <= 9)
            {
                SecondBox.GetComponent<TMP_Text>().text = " 0" + SecCount + " .";
            }
            else
            {
                SecondBox.GetComponent<TMP_Text>().text = " " + SecCount + " .";
            }
            if (SecCount >= 60)
            {
                SecCount = 0;
                MinCount += 1;
            }
            if (MinCount <= 9)
            {
                MinuteBox.GetComponent<TMP_Text>().text = "0" + MinCount + " :";
            }
            else
            {
                MinuteBox.GetComponent<TMP_Text>().text = "" + MinCount + " :";
            }
        }
    }
}

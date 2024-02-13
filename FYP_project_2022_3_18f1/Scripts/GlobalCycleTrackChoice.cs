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

    // Start is called before the first frame update
    void Start()
    {
        Track1.SetActive(false);
        Track2.SetActive(false);
        Track3.SetActive(false);
        Track4.SetActive(false);
        Track5.SetActive(false);
        if (GameManager.Instance != null)
        {
            switch (GameManager.Instance.PlayerCycleTrackType)
            {
                case 1:
                    Track1.SetActive(true);
                    break;
                case 2:
                    Track2.SetActive(true);
                    break;
                case 3:
                    Track3.SetActive(true);
                    break;
                case 4:
                    Track4.SetActive(true);
                    break;
                case 5:
                    Track5.SetActive(true);
                    break;
            }
        }
        else
        {
            Track1.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playbtn_hide_show : MonoBehaviour
{
    [SerializeField] private GameObject playbtn;
    private void Start()
    {
        playbtn.transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.PlayerCycleTrackType != 0)
            {
                playbtn.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                playbtn.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}

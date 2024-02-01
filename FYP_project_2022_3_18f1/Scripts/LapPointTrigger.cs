using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapPointTrigger : MonoBehaviour
{
    [SerializeField] private GameObject OtherLapPoint;
    private void OnTriggerEnter(Collider other)
    {
        OtherLapPoint.SetActive(true);
        this.gameObject.SetActive(false);
    }
}

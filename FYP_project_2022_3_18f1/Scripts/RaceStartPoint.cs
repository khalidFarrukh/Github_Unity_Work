using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceStartPoint : MonoBehaviour
{
    [SerializeField]
    private Transform start_point;
    // Start is called before the first frame update
    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.position = start_point.position;
        rb.rotation = start_point.rotation;
    }
}

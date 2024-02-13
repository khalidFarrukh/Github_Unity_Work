using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demo : MonoBehaviour
{
    float vertical_slider = 0f;
    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKey(KeyCode.S))
        {
            vertical_slider = Mathf.MoveTowards(vertical_slider, 60f, 20 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            vertical_slider = Mathf.MoveTowards(vertical_slider, -20f, 20 * Time.deltaTime);
        }
        Debug.Log(vertical_slider);
    }
}

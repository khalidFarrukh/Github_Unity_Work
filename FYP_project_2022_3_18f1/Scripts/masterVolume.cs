using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class masterVolume : MonoBehaviour
{
    private void Start()
    {
        if (!PlayerPrefs.HasKey("RFRmasterVolume"))
        {
            gameObject.GetComponent<Slider>().value = 0.3f;
        }
        else
        {
            gameObject.GetComponent<Slider>().value = PlayerPrefs.GetFloat("RFRmasterVolume");
        }
    }
    public void OnValueChange()
    {
        PlayerPrefs.SetFloat("RFRmasterVolume", gameObject.GetComponent<Slider>().value);
    }
}

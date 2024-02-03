using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer_script : MonoBehaviour
{
    [SerializeField] private GameObject Timer;
    [SerializeField] private GameObject Controls;
    [SerializeField] private AudioSource Timer_beep;
    [SerializeField] private AudioSource Go_beep;
    [SerializeField] private TMP_Text Text;
    // Update is called once per frame
    public static bool PlayerCanMove;
    private void Awake()
    {
        PlayerCanMove = false;
        Timer.SetActive(true);
        Controls.SetActive(false);
    }
    private void Start()
    {
        StartCoroutine(CountStart());
    }

    IEnumerator CountStart()
    {
        yield return new WaitForSeconds(0.5f);
        for (int t=5; t > 0; t--)
        {
            Text.text = "" + t;
            Timer_beep.Play();
            yield return new WaitForSeconds(1f);
        }
        Text.text = "GO";
        Go_beep.Play();
        yield return new WaitForSeconds(1.07f);
        Timer.SetActive(false);
        Controls.SetActive(true);
        PlayerCanMove=true;
    }

}

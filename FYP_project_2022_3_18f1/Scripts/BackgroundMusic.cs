using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    private BackgroundMusic Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
        Scene currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "CyclingMap")
        {
            gameObject.GetComponent<AudioSource>().volume = 0f ;
        }
        else
        {
            gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("RFRmasterVolume");
        }


    }
}

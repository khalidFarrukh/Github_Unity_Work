using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button_to_Scene : MonoBehaviour
{
    public int scene;
    public Button btn;
    private void Awake()
    { 
        btn.onClick.AddListener(delegate { OnbtnClick(); });
    }

    private void OnbtnClick()
    {
        SceneManager.LoadScene(scene);
    }
}

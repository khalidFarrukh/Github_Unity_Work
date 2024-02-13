using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UICommonController : MonoBehaviour
{
    public GameObject ActualMenu;
    public GameObject optionsMenu;
    public Button options;
    void Start()
    {
        ActualMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
    private void Awake()
    {
        options.onClick.AddListener(delegate { OnOptionBtnClick(); });
    }

    private void OnOptionBtnClick()
    {
        if (ActualMenu.activeSelf == true)
        {
            Time.timeScale = 0f;
            ActualMenu.SetActive(false);
            optionsMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            ActualMenu.SetActive(true);
            optionsMenu.SetActive(false);
        }
    }
}

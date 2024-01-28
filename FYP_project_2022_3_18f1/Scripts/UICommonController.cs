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
            ActualMenu.SetActive(false);
            optionsMenu.SetActive(true);
        }
        else
        {
            ActualMenu.SetActive(true);
            optionsMenu.SetActive(false);
        }
    }
}

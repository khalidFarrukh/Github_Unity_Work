using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMenuOrCycleColorOpeningScript : MonoBehaviour
{
    public GameObject ActualMenu;
    public GameObject MapMenuOrCycleColor;
    public GameObject OptionBtn;
    public Button ChoosMap_Or_ChangeColor;
    void Start()
    {
        OptionBtn.SetActive(true);
        ActualMenu.SetActive(true);
        MapMenuOrCycleColor.SetActive(false);
    }
    private void Awake()
    {
        ChoosMap_Or_ChangeColor.onClick.AddListener(delegate {
            OptionBtn.SetActive(false);
            ActualMenu.SetActive(false);
            MapMenuOrCycleColor.SetActive(true);
        });
    }

}

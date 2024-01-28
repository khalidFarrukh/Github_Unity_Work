using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMenuOrCycleColorClosingScript : MonoBehaviour
{
    public GameObject ActualMenu;
    public GameObject MapMenuOrCycleColor;
    public GameObject OptionBtn;
    public Button background;
    public List<Button> mapbuttons_or_cyclecolorbuttons;

    private void Awake()
    {
        background.onClick.AddListener(delegate { OnBtnClick(); });
        for(int i = 0; i < mapbuttons_or_cyclecolorbuttons.Count; i++)
        {
            mapbuttons_or_cyclecolorbuttons[i].onClick.AddListener(delegate { OnBtnClick(); });
        }
    }

    private void OnBtnClick()
    {
        OptionBtn.SetActive(true);
        ActualMenu.SetActive(true);
        MapMenuOrCycleColor.SetActive(false);
    }
}

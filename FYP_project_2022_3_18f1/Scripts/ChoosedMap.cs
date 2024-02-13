using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoosedMap : MonoBehaviour
{
    [SerializeField] private TMP_Text ChoosedMapName;
    [SerializeField] private RawImage ChoosedMapImage;
    private void Update()
    {
        if (GameManager.Instance != null)
        {
            switch (GameManager.Instance.PlayerCycleTrackType)
            {
                case 1:
                    ChoosedMapImage.texture = GameManager.Instance.CycleMap1;
                    ChoosedMapName.text = "Map 1";
                    break;
                case 2:
                    ChoosedMapImage.texture = GameManager.Instance.CycleMap2;
                    ChoosedMapName.text = "Map 2";
                    break;
                case 3:
                    ChoosedMapImage.texture = GameManager.Instance.CycleMap3;
                    ChoosedMapName.text = "Map 3";
                    break;
                case 4:
                    ChoosedMapImage.texture = GameManager.Instance.CycleMap4;
                    ChoosedMapName.text = "Map 4";
                    break;
                case 5:
                    ChoosedMapImage.texture = GameManager.Instance.CycleMap5;
                    ChoosedMapName.text = "Map 5";
                    break;
            }
        }
    }
}

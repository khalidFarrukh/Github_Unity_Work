using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoosedCycle : MonoBehaviour
{
    [SerializeField] private TMP_Text ChoosedColorName;
    [SerializeField] private RawImage ChoosedColorImage;
    private void Update()
    {
        if (GameManager.Instance != null)
        {
            switch (GameManager.Instance.PlayerCycleType)
            {
                case 0:
                    ChoosedColorImage.texture = GameManager.Instance.WhiteCycleImage;
                    ChoosedColorName.text = "White";
                    break;
                case 1:
                    ChoosedColorImage.texture = GameManager.Instance.YellowCycleImage;
                    ChoosedColorName.text = "Yellow";
                    break;
                case 2:
                    ChoosedColorImage.texture = GameManager.Instance.BlueCycleImage;
                    ChoosedColorName.text = "Blue";
                    break;
                case 3:
                    ChoosedColorImage.texture = GameManager.Instance.RedCycleImage;
                    ChoosedColorName.text = "Red";
                    break;
                case 4:
                    ChoosedColorImage.texture = GameManager.Instance.OrangeCycleImage;
                    ChoosedColorName.text = "Orange";
                    break;
                case 5:
                    ChoosedColorImage.texture = GameManager.Instance.GreenCycleImage;
                    ChoosedColorName.text = "Green";
                    break;
                case 6:
                    ChoosedColorImage.texture = GameManager.Instance.BlackCycleImage;
                    ChoosedColorName.text = "Black";
                    break;
            }
        }
    }
}

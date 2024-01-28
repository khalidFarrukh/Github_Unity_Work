using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorChangeBtn : MonoBehaviour
{
    public TMP_Text ChangedColorName;
    public RawImage changedColorImage;
    public void SetColorImage(Texture T)
    {
        changedColorImage.texture = T;
    }
    public void SetColorName(string name)
    {
        ChangedColorName.SetText(name);
    }
}

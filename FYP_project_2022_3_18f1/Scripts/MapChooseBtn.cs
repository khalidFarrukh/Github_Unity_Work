using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MapChooseBtn : MonoBehaviour
{
    public TMP_Text ChoosedMapName;
    public RawImage ChoosedMapImage;
    public void SetMapImage(Texture T)
    {
        ChoosedMapImage.texture = T;
    }
    public void SetMapName(string name)
    {
        ChoosedMapName.SetText(name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCycleChoice : MonoBehaviour
{
    public Material WhiteColor;
    public Material YellowColor;
    public Material BlueColor;
    public Material RedColor;
    public Material OrangeColor;
    public Material GreenColor;
    public Material BlackColor;

    public Renderer obj1;
    public Renderer obj2;
    public Renderer obj3;
    private Material selectedColor;

    public int CycleImport;
    // Start is called before the first frame update
    void Start()
    {
        CycleImport = GlobalCycle.CycleType;
        if(CycleImport == 0)
        {
            selectedColor = WhiteColor;
        }
        else if (CycleImport == 1)
        {
            selectedColor = YellowColor;
        }
        else if (CycleImport == 2)
        {
            selectedColor = BlueColor;
        }
        else if (CycleImport == 3)
        {
            selectedColor = RedColor;
        }
        else if (CycleImport == 4)
        {
            selectedColor = OrangeColor;
        }
        else if (CycleImport == 5)
        {
            selectedColor = GreenColor;
        }
        else if (CycleImport == 6)
        {
            selectedColor = BlackColor;
        }
        obj1.material = selectedColor;
        obj2.material = selectedColor;
        obj3.material = selectedColor;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICycle_Color : MonoBehaviour
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
    [SerializeField] private int rn;
    // Start is called before the first frame update
    void Start()
    {
        CycleImport = GlobalCycle.CycleType;
        while (true)
        {
            rn = (int) Random.Range(0f, 6f);
            if(rn != CycleImport)
            {
                break;
            }
        }
        switch (rn)
        {
            case 0:
                selectedColor = WhiteColor;
                break;
            case 1:
                selectedColor = YellowColor;
                break;
            case 2:
                selectedColor = BlueColor;
                break;
            case 3:
                selectedColor = RedColor;
                break;
            case 4:
                selectedColor = OrangeColor;
                break;
            case 5:
                selectedColor = GreenColor;
                break;
            case 6:
                selectedColor = BlackColor;
                break;
        }

        obj1.material = selectedColor;
        obj2.material = selectedColor;
        obj3.material = selectedColor;
    }

}

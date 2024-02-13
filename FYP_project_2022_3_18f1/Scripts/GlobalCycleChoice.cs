using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalCycleChoice : MonoBehaviour
{
    public Renderer obj1;
    public Renderer obj2;
    public Renderer obj3;
    private Material selectedMaterial;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance != null)
        {
            switch (GameManager.Instance.PlayerCycleType)
            {
                case 0:
                    selectedMaterial = GameManager.Instance.WhiteMaterial;
                    break;
                case 1:
                    selectedMaterial = GameManager.Instance.YellowMaterial;
                    break;
                case 2:
                    selectedMaterial = GameManager.Instance.BlueMaterial;
                    break;
                case 3:
                    selectedMaterial = GameManager.Instance.RedMaterial;
                    break;
                case 4:
                    selectedMaterial = GameManager.Instance.OrangeMaterial;
                    break;
                case 5:
                    selectedMaterial = GameManager.Instance.GreenMaterial;
                    break;
                case 6:
                    selectedMaterial = GameManager.Instance.BlackMaterial;
                    break;
            }
            obj1.material = selectedMaterial;
            obj2.material = selectedMaterial;
            obj3.material = selectedMaterial;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICycle_Color : MonoBehaviour
{
    public Renderer obj1;
    public Renderer obj2;
    public Renderer obj3;
    private Material selectedMaterial;
    [SerializeField] private int rn;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance != null)
        {
            while (true)
            {
                rn = (int)Random.Range(0f, 6f);

                if (rn != GameManager.Instance.PlayerCycleType)
                {
                    break;
                }

            }
            switch (rn)
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

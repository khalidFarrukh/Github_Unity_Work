using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Cycle Materials")]
    public Material WhiteMaterial;
    public Material YellowMaterial;
    public Material BlueMaterial;
    public Material RedMaterial;
    public Material OrangeMaterial;
    public Material GreenMaterial;
    public Material BlackMaterial;

    [Header("Cycle Images")]
    public Texture2D WhiteCycleImage;
    public Texture2D YellowCycleImage;
    public Texture2D BlueCycleImage;
    public Texture2D RedCycleImage;
    public Texture2D OrangeCycleImage;
    public Texture2D GreenCycleImage;
    public Texture2D BlackCycleImage;

    [Header("Cycle Map Images")]
    public Texture2D CycleMap1;
    public Texture2D CycleMap2;
    public Texture2D CycleMap3;
    public Texture2D CycleMap4;
    public Texture2D CycleMap5;

    public int PlayerCycleType;
    public Material PlayerCycleColor;
    public int PlayerCycleTrackType;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

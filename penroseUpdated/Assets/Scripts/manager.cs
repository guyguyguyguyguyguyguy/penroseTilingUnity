using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class manager : MonoBehaviour
{
    public int _id = 0;
    public static List<tile> allObjects = new List<tile>();
    public static GameObject blueDrawObj;
    public static GameObject redDrawObj;
    public static string tileType = "P3";

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        OnDemandRendering.renderFrameInterval = 2;
        Physics.autoSimulation = false;

        blueDrawObj = new GameObject();
        blueDrawObj.name = "Blue drawing Object";
        MeshFilter blueDFil= blueDrawObj.AddComponent<MeshFilter>();
        MeshRenderer blueDRend = blueDrawObj.AddComponent<MeshRenderer>();
        blueDRend.material = new Material(Shader.Find("Standard"));
        blueDrawObj.AddComponent<blueDrawer>();

        redDrawObj = new GameObject();
        redDrawObj.name = "Red drawing Object";
        MeshFilter redDFil= redDrawObj.AddComponent<MeshFilter>();
        MeshRenderer redDRend = redDrawObj.AddComponent<MeshRenderer>();
        redDRend.material = new Material(Shader.Find("Standard"));
        redDrawObj.AddComponent<redDrawer>();
    }

    void Start()
    {   
        tileType = "P2";

        // dartTile firstDart = new dartTile();
        // firstDart.Init(new Vector3(1, 0));

        // kiteTile firstKite = new kiteTile();
        // firstKite.Init(new Vector3(0,1));

        // tileType = "P3";

        // thickRhomb firstTRhomb = new thickRhomb();
        // firstTRhomb.Init(new Vector3());

        // thinRhomb firstThRhomb = new thinRhomb();
        // firstThRhomb.Init(new Vector3());
    }


    void Update()
    {

    }


    void proceduralGeneration()
    {

    }
}

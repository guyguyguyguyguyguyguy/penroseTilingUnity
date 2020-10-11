using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class manager : MonoBehaviour
{
    public int _id = 0;
    public static List<robTriangle> allObjects = new List<robTriangle>();
    public static GameObject blueDrawObj;
    public static GameObject redDrawObj;


    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        OnDemandRendering.renderFrameInterval = 60;
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
    //     dartTile firstDart = new dartTile();
    //     firstDart.Init(new Vector3());

        kiteTile firstKite = new kiteTile();
        firstKite.Init(new Vector3());

        // thickRhomb firstTRhomb = new thickRhomb();
        // firstTRhomb.Init(new Vector3());

        // thinRhomb firstThRhomb = new thinRhomb();
        // firstThRhomb.Init(new Vector3());
    }


    void Update()
    {

    }
}

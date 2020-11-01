using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System;
using tilePlacement;

public class manager : MonoBehaviour
{
    public int _id = 0;
    public static List<tile> allObjects = new List<tile>();
    public static GameObject blueDrawObj;
    public static GameObject redDrawObj;
    public static string tileType = "P3";
    
    
    System.Random r = new System.Random( );
    bool autoDrawing = false;
    static List<string> sideList = new List<string>{"left", "right"}; 
    int tileNeightDraw = 0;

    int frame = 0;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        OnDemandRendering.renderFrameInterval = 6;
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
        // tileType = "P2";

        // dartTile firstDart = new dartTile();
        // firstDart.Init(new Vector3(1, 0));

        // kiteTile firstKite = new kiteTile();
        // firstKite.Init(new Vector3(0,1));

        tileType = "P3";

        // thickRhomb firstTRhomb = new thickRhomb();
        // firstTRhomb.Init(new Vector3());

        // thinRhomb firstThRhomb = new thinRhomb();
        // firstThRhomb.Init(new Vector3());
    }


    void Update()
    {
        // Debug.Log( "Number of tiles");
        // Debug.Log(manager.allObjects.Count);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            allObjects.Clear();
        }


        if (Input.GetKeyDown(KeyCode.Return) & !autoDrawing)
        {
            autoDrawing = true;
        }

        else if (Input.GetKeyDown(KeyCode.Return) & autoDrawing)
        {
            autoDrawing = false;
        }

        if (autoDrawing & frame%20 == 0)
        {
            tileNeightDraw = r.Next(allObjects.Count);

            drawLegalNeighbour(allObjects[tileNeightDraw]);
        }

        frame++;

        Debug.Log(tileNeightDraw);
        Debug.Log(allObjects.Count);
    }   


    void proceduralGeneration()
    {

    }


    void drawLegalNeighbour(tile t)
    {   

        int sideIndex = r.Next(sideList.Count);
        string side = sideList[sideIndex];
        

        // some function that lists legal edges for each tile

        int edgeIndex = r.Next(t.edges.Count);
        Vector3[] edgeVec = t.edges[edgeIndex];
        Debug.Log(edgeIndex);

        tilePlacement2.P3TilePlacement(side, t, edgeIndex+1, edgeVec);
    }


    // Tuple<int, Vector3[]> legalEdgesForTile(tile t)
    // {
    //     int edgeNo;
    //     Vector3[] edgeVec;

                


    //     return new Tuple<int, Vector3[]> (edgeNo, edgeVec);
    // }
}

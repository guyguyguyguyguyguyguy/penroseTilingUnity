using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System;
// using TilePlacement;
using ForcedTiles;

public class Manager : MonoBehaviour
{
    public int _id = 0;
    public static List<Tile> allObjects = new List<Tile>();
    public static GameObject blueDrawObj;
    public static GameObject redDrawObj;
    public static string tileType = "P3";

    private TilePlacementClass placement = new TilePlacementClass();
    
    
    System.Random r = new System.Random( );
    bool autoDrawing = false;
    static List<string> sideList = new List<string>{"left", "right"}; 
    // int tileNeightDraw = 0;

    int frame = 0;

    bool noForced = false;


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
        blueDrawObj.AddComponent<BlueDrawer>();

        redDrawObj = new GameObject();
        redDrawObj.name = "Red drawing Object";
        MeshFilter redDFil= redDrawObj.AddComponent<MeshFilter>();
        MeshRenderer redDRend = redDrawObj.AddComponent<MeshRenderer>();
        redDRend.material = new Material(Shader.Find("Standard"));
        redDrawObj.AddComponent<RedDrawer>();

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

        // Need to sort the tiles in allobjects and also the rules are wrong 


        // Debug.Log(allObjects.Count);

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

        if (autoDrawing & frame%60 == 0)
        {

            int forcedTiles = 0;
            
            for (int i = 0; i < allObjects.Count; ++i)
            {
                if (HelperFunctions.HelperFunctionsClass.ElementsInArray(allObjects[i].neighbours))
                {
                    continue;
                }

                else
                {
                    forcedTiles += DrawLegalNeighbour(allObjects[i]);
                }
            }

            Debug.Log(forcedTiles);
            if (forcedTiles == 0)
            {
                noForced = true;
                int ranind = r.Next(allObjects.Count);
                DrawLegalNeighbour(allObjects[ranind]);
            }

        }

        frame++;
    }   


    void ProceduralGeneration()
    {

    }


    int DrawLegalNeighbour(Tile t)
    {   
        
        List<int> edgeNoArray = new List<int>();

        for (int i=0; i < t.neighbours.Length; ++i)
        {
            if (!(t.neighbours[i] is Tile))
            {
                edgeNoArray.Add(i+1);
            }
        }

        int edgeNoIndex = r.Next(edgeNoArray.Count);
        int edgeNo = edgeNoArray[edgeNoIndex];

        // string tileToAdd = P3Forced.LegalTilesAtEdge(edgeNo, t);
        string tileToAdd = "";


        if (tileToAdd == "red or blue")
        {
            // Debug.Log("It happened");
        }

        if (tileToAdd == "red")
        {
            placement.P3TilePlacement("left", t, edgeNo, t.edges[edgeNo-1]);
            return 1;
        }

        else if (tileToAdd == "blue")
        {
            placement.P3TilePlacement("right", t, edgeNo, t.edges[edgeNo-1]);
            return 1;
        }

        else if (tileToAdd == "red or blue" && noForced)
        {
            
            Debug.Log("i am adding random");

            int sideIndex = r.Next(sideList.Count);
            string side = sideList[sideIndex];

            placement.P3TilePlacement(side, t, edgeNo, t.edges[edgeNo-1]);
            noForced = false;
            return 1;
        } 

        return 0;

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System;
using tilePlacement;
using forcedTiles;

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
            
            int forcedTiles = 0;
            bool noForced = false;

            foreach (tile t in allObjects)
            {
                if (helperFunctions.helperFunctionsClass.elementsInArray(t.neighbours))
                {
                    continue;
                }

                else
                {
                    forcedTiles += drawLegalNeighbour(t, noForced);
                }
            }

            if (forcedTiles == 0)
            {
                noForced = true;
            }

            // tileNeightDraw = r.Next(allObjects.Count);

            // drawLegalNeighbour(allObjects[tileNeightDraw]);
        }

        frame++;
    }   


    void proceduralGeneration()
    {

    }


    int drawLegalNeighbour(tile t, bool noForcedTiles)
    {   
        
        List<int> edgeNoArray = new List<int>();

        for (int i=0; i < t.neighbours.Length; ++i)
        {
            if (t.neighbours[i] == null)
            {
                edgeNoArray.Add(i+1);
            }
        }

        int edgeNo = r.Next(edgeNoArray.Count);
        edgeNo++;
        // edgeNo = 4;

        string tileToAdd = P3ForcedTiles.legalTilesAtEdge(edgeNo, t);


        Debug.Log(tileToAdd);
        Debug.Log(edgeNo);

        if (tileToAdd == "red")
        {
            tilePlacement2.P3TilePlacement("left", t, edgeNo, t.edges[edgeNo-1]);
            return 1;
        }

        else if (tileToAdd == "blue")
        {
            tilePlacement2.P3TilePlacement("right", t, edgeNo, t.edges[edgeNo-1]);
            return 1;
        }

        else if (tileToAdd == "red or blue" && noForcedTiles)
        {
            int sideIndex = r.Next(sideList.Count);
            string side = sideList[sideIndex];

            tilePlacement2.P3TilePlacement(side, t, edgeNo, t.edges[edgeNo-1]);
            return 1;
        }            

        return 0;

    }

}

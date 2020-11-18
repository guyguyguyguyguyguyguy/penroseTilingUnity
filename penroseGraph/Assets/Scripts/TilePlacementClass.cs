using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using HelperFunctions;

   
public class TilePlacementClass : MonoBehaviour
{

    public GameObject thinRhomb;
    public GameObject thickRhomb;

    Action<string, Tile, int, Vector3[]> updateMethod;

    void Start()
    {

        Debug.Log(Manager.tileType);

        if(Manager.tileType == "P2")
        {
            updateMethod = P2TilePlacement;

        }   

        else if(Manager.tileType == "P3")
        {
            updateMethod = P3TilePlacement;
        }
    }


    void Update()
    {
        if((Manager.allObjects.Count != 0))
        {
            if (Input.GetMouseButtonDown(0)) 
            {  
                Vector3 mouseClickCoor =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var closestTile = getClosestTile(Manager.allObjects, mouseClickCoor);

                if(closestTile.Item2 < 0.9)
                {   
                    updateMethod("left", closestTile.Item1, closestTile.Item3, closestTile.Item4);
                }

                else
                {
                    if (Manager.tileType == "P3")
                    {
                        GameObject newTile = (GameObject)Instantiate(thinRhomb);
                        newTile.SetActive(false);
                        ThinRhomb newTileScript = newTile.GetComponent<ThinRhomb>();
                        newTileScript.Init(mouseClickCoor);
                        newTile.SetActive(true);

                    }
                    
                    else if (Manager.tileType == "P2")
                    {
                        KiteTile newTile = new KiteTile();
                        newTile.Init(mouseClickCoor);
                    }
                }
            }


            else if(Input.GetMouseButtonDown(1))
            {
                Vector3 mouseClickCoor =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var closestTile = getClosestTile(Manager.allObjects, mouseClickCoor);

                if(closestTile.Item2 < 0.9)
                {
                    updateMethod("right", closestTile.Item1, closestTile.Item3, closestTile.Item4);
                }

                else
                {
                    if (Manager.tileType == "P3")
                    {
                        GameObject newTile = (GameObject)Instantiate(thickRhomb);
                        newTile.SetActive(false);
                        ThickRhomb newTileScript = newTile.GetComponent<ThickRhomb>();
                        newTileScript.Init(mouseClickCoor);
                        newTile.SetActive(true);
                    }
                    
                    else if (Manager.tileType == "P2")
                    {
                        DartTile newTile = new DartTile();
                        newTile.Init(mouseClickCoor);
                    }
                }
            }
        }
        
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mouseClickCoor =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
                if (Manager.tileType == "P3")
                {
                    GameObject newTile = (GameObject)Instantiate(thinRhomb);
                    newTile.SetActive(false);
                    ThinRhomb newTileScript = newTile.GetComponent<ThinRhomb>();
                    newTileScript.Init(mouseClickCoor);
                    newTile.SetActive(true);
                    
                }
                
                else if (Manager.tileType == "P2")
                {
                    KiteTile newTile = new KiteTile();
                    newTile.Init(mouseClickCoor);
                }
            }

            else if (Input.GetMouseButtonDown(1))
            {
                Vector3 mouseClickCoor =  Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (Manager.tileType == "P3")
                {
                        GameObject newTile = (GameObject)Instantiate(thickRhomb);
                        newTile.SetActive(false);
                        ThickRhomb newTileScript = newTile.GetComponent<ThickRhomb>();
                        newTileScript.Init(mouseClickCoor);
                }
                
                else if (Manager.tileType == "P2")
                {
                    DartTile newTile = new DartTile();
                    newTile.Init(mouseClickCoor);
                }
            }
        }
    }


    public static void P2TilePlacement(string mouseClick, Tile closestTile, int closestEdge, Vector3[] closestEdgeVec)
    {

        if(mouseClick == "left")
        {

        }

        else if(mouseClick == "right")
        {

        }
    }


    public static void P3TilePlacement(string mouseClick, Tile closestTile, int closestEdge, Vector3[] closestEdgeVec)
    {


        if(mouseClick == "left")
        {   
            addThinRhomb(closestTile.name, closestEdge, closestTile);
        }

        else if(mouseClick == "right")
        {
            // addThickRhomb(closestTile.name, closestEdge, closestEdgeVec, closestTile.rotation, closestTile.matchingCase, closestTile);
        }
    }
    

    static void addThinRhomb(string tileType, int closestEdge, Tile closestTile)
    {

        Vector3[] verticiesToAdd = new Vector3[4]; 
        Vector3[] newVertices = new Vector3[4];
        int rotateIndex;
        float angle;

        if (tileType == "thinRhomb")
        {
            newVertices = closestTile.tileVertices;
        }

        else if (tileType == "thickRhomb")
        {
            newVertices = closestTile.tileVertices;
            newVertices = HelperFunctionsClass.ThinToThick(newVertices[0]);
        }

        else
        {
            throw new Exception("What is this you are trying to add to? #madlad");
        }


        switch (closestEdge)
        {  
            case 1:

                rotateIndex = 0;
                angle = 0f;

                break;

            case 2:

                rotateIndex = 0;
                angle = 0f;

                break;


            case 3:

                rotateIndex = 0;
                angle = 0f;

                break;


            case 4:

                rotateIndex = 0;
                angle = 0f;

                break;
        }


        for (int i = 0; i < verticiesToAdd.Length; ++i)
        {
            verticiesToAdd[i] = transform.RotateAround(newVertices[i],  newVerticies[rotateIndex], angle);
        }

        GameObject newTile = (GameObject)Instantiate(thickRhomb);
        newTile.SetActive(false);
        ThickRhomb newTileScript = newTile.GetComponent<ThickRhomb>();
        newTileScript.Init(verticiesToAdd);
        newTile.SetActive(true);

    }


    static void addThickRhomb(string tileType, int closestEdge, Vector3[] closestEdgeVec, float currentRotation, int previousCase, Tile closestTile)
    {

        Vector3[] verticiesToAdd = new Vector3[4]; 
        Vector3[] newVertices = new Vector3[4];
        int rotateIndex;
        float angle;

        if (tileType == "thickRhomb")
        {
            newVertices = closestTile.tileVertices;
        }

        else if (tileType == "thinRhomb")
        {
            newVertices = closestTile.tileVertices;
            newVertices = HelperFunctionsClass.ThickToThin(newVertices[3]);
        }

        else
        {
            throw new Exception("What is this you are trying to add to? #madlad");
        }
        
    }



    static Tuple<Tile, float, int, Vector3[]> getClosestTile(List<Tile> tiles, Vector3 mousePos)
    {
        Tile closest = null;
        Vector3[] closestEdgeVec = new Vector3[2];
        int closestEdge = 0;
        float minDist = Mathf.Infinity;
        foreach (Tile t in tiles)
        {
            float dist = Vector2.Distance(t.centre, mousePos);
            if (dist < minDist)
            {
                closest = t;
                minDist = dist;
            }
        }

        float minDistToEdge = Mathf.Infinity;
        for (int i = 0; i < closest.edges.Count; ++i)
        {
            float distToEdge = Vector2.Distance(HelperFunctionsClass.EdgeCentre(closest.edges[i]), mousePos);

            if(distToEdge < minDistToEdge)
            {
                minDistToEdge = distToEdge;
                closestEdgeVec = closest.edges[i];
                closestEdge = i+1;
            }
        }
        
        return new Tuple< Tile, float, int, Vector3[]>(closest, minDist, closestEdge, closestEdgeVec);
    }  
}

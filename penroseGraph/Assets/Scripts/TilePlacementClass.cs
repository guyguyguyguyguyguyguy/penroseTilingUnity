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
                        GameObject newTile = (GameObject)Instantiate(thinRhomb, new Vector3(0, 0 , 0), Quaternion.identity);
                        newTile.SetActive(false);
                        newTile.GetComponent<ThinRhomb>().Init(mouseClickCoor);
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
                        GameObject newTile = (GameObject)Instantiate(thickRhomb, new Vector3(0, 0, 0), Quaternion.identity);
                        newTile.SetActive(false);
                        newTile.GetComponent<ThickRhomb>().Init(mouseClickCoor);
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
                    GameObject newTile = (GameObject)Instantiate(thinRhomb, new Vector3(0, 0 , 0), Quaternion.identity);
                    newTile.SetActive(false);
                    newTile.GetComponent<ThinRhomb>().Init(mouseClickCoor);
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
                    GameObject newTile = (GameObject)Instantiate(thickRhomb, new Vector3(0, 0, 0), Quaternion.identity);
                    newTile.SetActive(false);
                    newTile.GetComponent<ThickRhomb>().Init(mouseClickCoor);
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


    public static void P2TilePlacement(string mouseClick, Tile closestTile, int closestEdge, Vector3[] closestEdgeVec)
    {

        if(mouseClick == "left")
        {

        }

        else if(mouseClick == "right")
        {

        }
    }


    public void P3TilePlacement(string mouseClick, Tile closestTile, int closestEdge, Vector3[] closestEdgeVec)
    {


        if(mouseClick == "left")
        {   
            addThinRhomb(closestTile.name, closestEdge, closestTile);
        }

        else if(mouseClick == "right")
        {
            addThickRhomb(closestTile.name, closestEdge, closestTile);
        }
    }
    

    void addThinRhomb(string tileType, int closestEdge, Tile closestTile)
    {

        Vector3[] verticiesToAdd = new Vector3[4]; 
        Vector3[] newVertices = new Vector3[4];
        Vector3[] closestTileVers = closestTile.worldVertices;
        float currentAngle = closestTile.rotation;
        int rotateIndex = 5;
        float angle = 0f;

        var tileCondition = (tileType == "thinRhomb");

        Debug.Log(closestEdge);


        switch (closestEdge)
        {  
            case 1:

                rotateIndex = tileCondition ? 2 : 2 ;
                angle = tileCondition ? -36f : -162f;

                break;

            case 2:

                rotateIndex = tileCondition ? 2 : 1;
                angle = tileCondition ? 36f : -54f;

                break;


            case 3:

                rotateIndex =  tileCondition ? 3 : 1;
                angle = tileCondition ? -36f : -126f;

                break;


            case 4:

                rotateIndex = tileCondition ? 3 : 3;
                angle = tileCondition ? 36f : -18f;

                break;
        }

        float tileRotation = currentAngle + angle;

        if (tileType == "thinRhomb")
        {
            newVertices = HelperFunctionsClass.FlipThin(closestTileVers);

            tileRotation += 180f;
        }

        else if (tileType == "thickRhomb")
        {
            newVertices = closestTileVers;

            if (closestEdge == 2 || closestEdge == 4)
            {
                newVertices = HelperFunctionsClass.ThinFromThickDown(closestTileVers[rotateIndex]);
            }
            else
            {
                newVertices = HelperFunctionsClass.ThinFromThickUp(closestTileVers[rotateIndex]);
            }

            angle += currentAngle;

        }

        else
        {
            throw new Exception("What is this you are trying to add to? #madlad");
        }


        GameObject newTile = (GameObject)Instantiate(thinRhomb);
        newTile.GetComponent<ThinRhomb>().tileVertices = newVertices;
        newTile.GetComponent<ThinRhomb>().rotation = tileRotation;
        newTile.transform.RotateAround(closestTileVers[rotateIndex], new Vector3(0, 0, 1), angle);
    }


    void addThickRhomb(string tileType, int closestEdge, Tile closestTile)
    {

        Vector3[] verticiesToAdd = new Vector3[4]; 
        Vector3[] newVertices = new Vector3[4];
        Vector3[] closestTileVers = closestTile.worldVertices;
        float currentAngle = closestTile.rotation;
        int rotateIndex = 5;
        float angle = 0f;

        var tileCondition = (tileType == "thinRhomb");

        Debug.Log(closestEdge);

        switch (closestEdge)
        {
            case 1:

                rotateIndex = tileCondition ? 0 : 0 ;
                angle = tileCondition ? 18f : 72f;

                break;

            case 2:

                rotateIndex = tileCondition ? 2 : 1;
                angle = tileCondition ? 54f : -72f;

                break;


            case 3:

                rotateIndex =  tileCondition ? 3 : 1;
                angle = tileCondition ? 126f : 72f;

                break;


            case 4:

                rotateIndex = tileCondition ? 0 : 0;
                angle = tileCondition ? 162f : -72;

                break;
        }

        float tileRotation = currentAngle + angle;

        if (tileType == "thickRhomb")
        {
            newVertices = closestTile.worldVertices;
        }

        else if (tileType == "thinRhomb")
        {   
            newVertices = closestTile.tileVertices;

            if (closestEdge == 2 || closestEdge == 3)
            {
                newVertices = HelperFunctionsClass.ThickFromThinDown(closestTileVers[rotateIndex]);                
            }
            
            else
            {
                newVertices = HelperFunctionsClass.ThickFromThinUp(closestTileVers[rotateIndex]);
            }

            angle += currentAngle;

        }

        else
        {
            throw new Exception("What is this you are trying to add to? #madlad");
        }


        GameObject newTile = (GameObject)Instantiate(thickRhomb);
        newTile.GetComponent<ThickRhomb>().tileVertices = newVertices;
        newTile.GetComponent<ThickRhomb>().rotation = tileRotation;
        newTile.transform.RotateAround(closestTileVers[rotateIndex], new Vector3(0, 0, 1), angle);
        
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

            // foreach(Vector3 v in closest.edges[i])
            // {
            //     Debug.Log(v);
            // }

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


    public void InstantiateTile(string tileType, Vector3[] verticies, float tileRotation, bool mirrorImage)
    {
        
        GameObject newTile;
        Tile tileScript;


        float modifiedRotation = tileRotation + 180f;

        if (tileType == "thinRhomb")
        {
            newTile = (GameObject)Instantiate(thinRhomb);
            tileScript = newTile.GetComponent<ThinRhomb>();
        }

        else
        {
            newTile = (GameObject)Instantiate(thickRhomb);
            tileScript = newTile.GetComponent<ThickRhomb>();
        }

        tileScript.tileVertices = verticies;
        tileScript.rotation = modifiedRotation;

        if(!mirrorImage)
        {
            Vector3 centre = centreOfTile(verticies);
            newTile.transform.RotateAround(centre, new Vector3 (0, 0, 1), 180f);
        }

    }


    public Vector3 centreOfTile(Vector3[] vers)
    {
        Vector3[] worldVertices = new Vector3[4];
        Vector3 centre = new Vector3();

        for (int i = 0; i < 4; ++i)
        {
            worldVertices[i] = transform.TransformPoint(vers[i]);
        }


        foreach(Vector3 x in worldVertices)
        {
            centre += x;
        }

        return centre/4;
    }
}
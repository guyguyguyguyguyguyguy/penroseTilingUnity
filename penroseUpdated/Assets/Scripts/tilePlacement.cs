using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class tilePlacement : MonoBehaviour
{   
    Action<Vector3, tile, string, bool> updateMethod;

    void Start()
    {
        if(manager.tileType == "P2")
        {
            updateMethod = P2TilePlacement;

        }   

        else if(manager.tileType == "P3")
        {
            updateMethod = P3TilePlacement;
        }
    }


    void Update()
    {
        if((manager.allObjects.Count != 0))
        {
            if (Input.GetMouseButtonDown(0)) 
            {  
                Vector3 mouseClickCoor =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var closestTile = getClosestTile(manager.allObjects, mouseClickCoor);

                if((closestTile.Item2 - 30) < 0.9)
                {   
                    updateMethod(closestTile.Item3, closestTile.Item1, "left", closestTile.Item4);
                }
            }


            else if(Input.GetMouseButtonDown(1))
            {
                Vector3 mouseClickCoor =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var closestTile = getClosestTile(manager.allObjects, mouseClickCoor);

                // bool side = (Vector3.Distance(mouseClickCoor, closestTile.Item1.centre) < 0) ? true: false;

                if(closestTile.Item2 < 0.9)
                {
                    updateMethod(closestTile.Item3, closestTile.Item1, "right", closestTile.Item4);
                }
            }
        }
    }


    public static void P2TilePlacement(Vector3 neartestVertex, tile nearestTile, string mouseClick, bool topOrBottom)
    {

        if(mouseClick == "left")
        {

        }

        else if(mouseClick == "right")
        {

        }
    }


    public static void P3TilePlacement(Vector3 neartestVertex, tile nearestTile, string mouseClick, bool topOrBottom)
    {

        if(mouseClick == "left")
        {   
            addThinRhomb(neartestVertex, topOrBottom, nearestTile.centre, nearestTile.name);
        }

        else if(mouseClick == "right")
        {
            
        }
    }
    

    static Tuple<tile, float, Vector3, bool> getClosestTile(List<tile> tiles, Vector3 mousePos)
    {
        tile closest = null;
        Vector3 closestVer = Vector3.zero;
        float minDist = Mathf.Infinity;
        foreach (tile t in tiles)
        {
            float dist = Vector3.Distance(t.centre, mousePos);
            if (dist < minDist)
            {
                closest = t;
                minDist = dist;
            }
        }
        
        if(Mathf.Abs(Vector3.Distance(mousePos, closest.tileVertices[0])) < Mathf.Abs(Vector3.Distance(mousePos, closest.tileVertices[2])))
        {
            closestVer = closest.tileVertices[0];
        }
        else
        {
            closestVer = closest.tileVertices[2];
        }

        bool topOrBottom = (Mathf.Abs(Vector3.Distance(mousePos, closest.tileVertices[1])) < Mathf.Abs(Vector3.Distance(mousePos, closest.tileVertices[3]))) ? true : false; 

        return new Tuple< tile, float, Vector3, bool>(closest, minDist, closestVer, topOrBottom);

    }  

    static void addThinRhomb(Vector3 pivotVertex, bool topOrBottom, Vector3 centre, string triangleType)
    {
        thinRhomb newTile = new thinRhomb();

        // Not working for second generation, possibly need to add the previous tiles rotation?

        switch (triangleType)
        {
            case "thinRhomb":

                if(topOrBottom)
                {
                    newTile.Init(centre, false, true, -216 , pivotVertex);
                }
                else
                {
                    newTile.Init(centre, false, true, 216, pivotVertex);
                }

                break;

            case "thickRhomb":


                break;

            case "rightThick":


                break;

        }

    }
}

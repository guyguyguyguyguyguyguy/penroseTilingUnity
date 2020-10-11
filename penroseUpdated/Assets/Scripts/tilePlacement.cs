using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class tilePlacement : MonoBehaviour
{   
    Action<robTriangle, string, bool> updateMethod;

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
                var closestTriangle = getClosestTriangle(manager.allObjects, mouseClickCoor);
                // Need to play with as this does not consider the tile being orientated diferently
                bool side = (Vector3.Distance(mouseClickCoor, closestTriangle.Item1.centre) < 0) ? true: false;

                if(closestTriangle.Item2 < 0.9)
                {
                    updateMethod(closestTriangle.Item1, "left", side);
                }
            }


            else if(Input.GetMouseButtonDown(1))
            {
                Vector3 mouseClickCoor =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var closestTriangle = getClosestTriangle(manager.allObjects, mouseClickCoor);
                bool side = (Vector3.Distance(mouseClickCoor, closestTriangle.Item1.centre) < 0) ? true: false;

                if(closestTriangle.Item2 < 0.9)
                {
                    updateMethod(closestTriangle.Item1, "right", side);
                }
            }
        }
    }


    public static void P2TilePlacement(robTriangle nearestTriangle, string mouseClick, bool side)
    {

        if(mouseClick == "left")
        {
            addThinRhomb(nearestTriangle.worldVertex3, nearestTriangle.getTileType(), side);
        }

        else if(mouseClick == "right")
        {

        }
    }


    public static void P3TilePlacement(robTriangle nearestTriangle, string mouseClick, bool side)
    {

        if(mouseClick == "left")
        {

        }

        else if(mouseClick == "right")
        {
            
        }
    }
    

    static Tuple<robTriangle, float> getClosestTriangle(List<robTriangle> triangles, Vector3 mousePos)
    {
        robTriangle closest = null;
        float minDist = Mathf.Infinity;
        foreach (robTriangle t in triangles)
        {
            float dist = Vector3.Distance(t.centre, mousePos);
            if (dist < minDist)
            {
                closest = t;
                minDist = dist;
            }
        }

        return new Tuple<robTriangle, float>(closest, minDist);
    }  


    static void addThinRhomb(Vector3 pivot, string triangleType, bool side)
    {
        switch (triangleType)
        {
            case "topThin":

                float rotation = (side) ? x : y;

                thinRhomb newTile = new thinRhomb();
                newTile.Init();
                break;
            
            case "bottomThin":


                float rotation = (side) ? x : y;
                break;

            case "leftThick":


                float rotation = (side) ? x : y;
                break;

            case "rightThick":


                float rotation = (side) ? x : y;
                break;

        }

    }
}

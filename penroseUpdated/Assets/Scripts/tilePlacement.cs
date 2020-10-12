using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class tilePlacement : MonoBehaviour
{   
    Action<robTriangle, string> updateMethod;

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

                Debug.Log(closestTriangle.Item1.name);
                Debug.Log(closestTriangle.Item2);

                // Need to play with as this does not consider the tile being orientated diferently 
                // bool side = (Vector3.Distance(mouseClickCoor, closestTriangle.Item1.centre) < 0) ? true: false;

                if((closestTriangle.Item2 - 30) < 0.9)
                {   
                    updateMethod(closestTriangle.Item1, "left");
                }
            }


            else if(Input.GetMouseButtonDown(1))
            {
                Vector3 mouseClickCoor =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var closestTriangle = getClosestTriangle(manager.allObjects, mouseClickCoor);

                // bool side = (Vector3.Distance(mouseClickCoor, closestTriangle.Item1.centre) < 0) ? true: false;

                if(closestTriangle.Item2 < 0.9)
                {
                    updateMethod(closestTriangle.Item1, "right");
                }
            }
        }
    }


    public static void P2TilePlacement(robTriangle nearestTriangle, string mouseClick)
    {

        if(mouseClick == "left")
        {

        }

        else if(mouseClick == "right")
        {

        }
    }


    public static void P3TilePlacement(robTriangle nearestTriangle, string mouseClick)
    {

        if(mouseClick == "left")
        {   
            addThinRhomb(nearestTriangle.worldVertex3, nearestTriangle.centre, nearestTriangle.name);
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
            float dist = Vector3.Distance(t.worldVertex3, mousePos);
            if (dist < minDist)
            {
                closest = t;
                minDist = dist;
            }
        }

        return new Tuple<robTriangle, float>(closest, minDist);

    }  

    static void addThinRhomb(Vector3 pivot, Vector3 centre, string triangleType)
    {
        thinRhomb newTile = new thinRhomb();


        // Not workingggg

        switch (triangleType)
        {
            case "topThin":

                newTile.Init(centre, false, true, -216, pivot);
                break;
            
            case "bottomThin": 
                
                newTile.Init(centre, false, true, 216, pivot);
                break;

            case "leftThick":


                break;

            case "rightThick":


                break;

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperFunctions;
using System;

public class Manager : MonoBehaviour
{
    private static float GOLDENRATIO = (1 + Mathf.Sqrt(5))/2; 

    private static float REDTRIANGLEHEIGHT = helperFunctionsClass.heronsFormula(GOLDENRATIO, 1, GOLDENRATIO);
    private static float BLUETRIANGLEHEIGHT = helperFunctionsClass.heronsFormula(1, GOLDENRATIO, 1);


    void Start()
    {
        Debug.Log(REDTRIANGLEHEIGHT);
    }

    void Update()
    {   
        triangleMesh[] allObjects = UnityEngine.Object.FindObjectsOfType<triangleMesh>();

        if((allObjects.Length != 0))
        {
            if (Input.GetMouseButtonDown(0)) 
            {  
                Vector3 mouseClickCoor =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var closestTriangle = getClosestTriangle(allObjects, mouseClickCoor);
                
                if(closestTriangle.Item2 < 0.9f)
                {   
                    Tuple<Vector3[], string> snapResult = getSnapCoords(closestTriangle.Item1, closestTriangle.Item3, "red", mouseClickCoor);

                }
                else
                {
                    instantiateRedTriangle(mouseClickCoor);
                }
            }    

            else if(Input.GetMouseButtonDown(1))
            { 
                Vector3 mouseClickCoor =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var closestTriangle = getClosestTriangle(allObjects, mouseClickCoor);
                if(closestTriangle.Item2 < 0.9f)
                {
                    Tuple<Vector3[], string> snapResult = getSnapCoords(closestTriangle.Item1, closestTriangle.Item3, "blue", mouseClickCoor);
                    instantiateBlueTriangle(snapResult.Item1, mouseClickCoor, snapResult.Item2);
                }
                else
                {
                    instantiateBlueTriangle(mouseClickCoor);
                }
            }
        }
        else
        {   
            if (Input.GetMouseButtonDown(0)) 
            {  
                Vector3 mouseClickCoor =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
                instantiateRedTriangle(mouseClickCoor);
            }
            else if (Input.GetMouseButtonDown(1)) 
            {  
                Vector3 mouseClickCoor =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
                instantiateBlueTriangle(mouseClickCoor);
            } 
        }
    }

    void instantiateRedTriangle(Vector3 clickPos)
    {   

        float halfHeightRed = REDTRIANGLEHEIGHT/2;

        Vector3 vertex1 = clickPos;
        vertex1[0] -= 0.5f;
        vertex1[1] -= halfHeightRed;
        
        Vector3 vertex2 = clickPos;
        vertex2[0] += 0.5f;
        vertex2[1] -= halfHeightRed;

        Vector3 vertex3 = clickPos;
        vertex3[1] += halfHeightRed;

        Vector3[] verticies = new [] {vertex1, vertex2, vertex3};
        instantiateRedTriangle(verticies, clickPos, null, 0, 2, 1);
    }


    void instantiateBlueTriangle(Vector3 clickPos)
    {   

        float halfHeightBlue = BLUETRIANGLEHEIGHT/2;

        Vector3 vertex1 = clickPos;
        vertex1[0] -= GOLDENRATIO/2;
        vertex1[1] -= halfHeightBlue;
        
        Vector3 vertex2 = clickPos;
        vertex2[0] += GOLDENRATIO/2;
        vertex2[1] -= halfHeightBlue;

        Vector3 vertex3 = clickPos;
        vertex3[1] += halfHeightBlue;

        Vector3[] verticies = new [] {vertex1, vertex2, vertex3};
        instantiateBlueTriangle(verticies, clickPos, null);
    }


    void instantiateRedTriangle(Vector3[] verticies, Vector3 clickPos, string mirror, int t1, int t2, int t3)
    {   
        Vector3 vertex1 = verticies[0];
        Vector3 vertex2 = verticies[1];
        Vector3 vertex3 = verticies[2];

        GameObject obj = new GameObject();
        obj.SetActive(false);
        MeshFilter objFil= obj.AddComponent<MeshFilter>();
        MeshRenderer objRend = obj.AddComponent<MeshRenderer>();
        objRend.material = new Material(Shader.Find("Standard"));

        redTriangleMesh newTriangleMesh = obj.AddComponent<redTriangleMesh>();
        newTriangleMesh.Init(vertex1, vertex2, vertex3, t1, t2, t3, mirror);
        newTriangleMesh.centre = clickPos;

        obj.SetActive(true);
    }


    void instantiateBlueTriangle(Vector3[] verticies, Vector3 clickPos, string mirror)
    {
        Vector3 vertex1 = verticies[0];
        Vector3 vertex2 = verticies[1];
        Vector3 vertex3 = verticies[2];

        GameObject obj = new GameObject();
        obj.SetActive(false);
        MeshFilter objFil= obj.AddComponent<MeshFilter>();
        MeshRenderer objRend = obj.AddComponent<MeshRenderer>();
        objRend.material = new Material(Shader.Find("Standard"));

        blueTriangleMesh newTriangleMesh = obj.AddComponent<blueTriangleMesh>();
        newTriangleMesh.Init(vertex1, vertex2, vertex3);
        newTriangleMesh.centre = clickPos;
        newTriangleMesh.Label = mirror;

        obj.SetActive(true);
    }


    Tuple<triangleMesh, float, Vector3[]> getClosestTriangle(triangleMesh[] triangles, Vector3 mousePos)
    {
        triangleMesh closest = null;
        float minDist = Mathf.Infinity;
        foreach (triangleMesh t in triangles)
        {
            float dist = Vector3.Distance(t.centre, mousePos);
            if (dist < minDist)
            {
                closest = t;
                minDist = dist;
            }
        }

        float minDistVer = Mathf.Infinity;
        Vector3 nearestVertex = Vector3.zero;
        Vector3[] nearestVerticies = new Vector3[2];
        foreach (Vector3 v in closest.verticies)
        {
            float dist = Vector3.Distance(mousePos, v);
            if(dist < minDistVer)
            {
                minDistVer = dist;
                nearestVertex = v;
            }
        }

        nearestVerticies[0] = nearestVertex;
        nearestVerticies[1] = closest.verticies[2];

        return new Tuple<triangleMesh, float, Vector3[]>(closest, minDist, nearestVerticies);
    }   

    Tuple<Vector3[], string> getSnapCoords(triangleMesh closeTriangle, Vector3[] nearestEdges, string colour, Vector3 mousePos)
    {   
        
        // return the verticies of the new object based on closest triangle

        Vector3[] snapVerticies = new Vector3[3];
        string mirror = null;

        switch(colour)
        {
            case "blue" when closeTriangle.name == "redTriangle":
                


                break;
            
            case "blue" when closeTriangle.name == "blueTriangle":

                break;

            case "red" when closeTriangle.name == "redTriangle":

                if(closeTriangle.Label == "mirror")
                {   

                }
                else
                {   
                    float x = 0;
                    float y = 0;
                    Vector3 newVertex = new Vector3 (x, y, -10f); 
                    newVertex += nearestEdges[0];

                    snapVerticies[1] = newVertex;
                    snapVerticies[0] = nearestEdges[0];
                    snapVerticies[2] = nearestEdges[1];

                    Debug.Log(newVertex);
                    Debug.Log(nearestEdges[0]);
                    Debug.Log(nearestEdges[1]);
                    mirror = "mirror";

                    instantiateRedTriangle(snapVerticies, mousePos, mirror, 1, 2, 0);
                }

                break;

            case "red" when closeTriangle.name == "blueTriangle":

                break;
        }

        return new Tuple<Vector3[], string> (snapVerticies, mirror);
    }
}

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

    // not sure where to keep this or at every update use  triangleMesh[] allObjects = UnityEngine.Object.FindObjectsOfType<triangleMesh>();
    public static List<triangleMesh> allObjects = new List<triangleMesh>();


    void Start()
    {
        // Debug.Log(REDTRIANGLEHEIGHT);
    }

    void Update()
    {   
        if((allObjects.Count != 0))
        {
            if (Input.GetMouseButtonDown(0)) 
            {  
                Vector3 mouseClickCoor =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var closestTriangle = getClosestTriangle(allObjects, mouseClickCoor);
                
                if(closestTriangle.Item2 < 0.9f)
                {   

                    // Closest triangle does not update
                    // Also drawing is all out of whack (possible use flip will be better than chaning way it is drawn)

                    Vector3 distance = mouseClickCoor - closestTriangle.Item1.centre;
                    if(distance[1] < 0)
                    {   
                        Vector3[] verticies = closestTriangle.Item1.verticies;
                        verticies[2][2] -= 2*REDTRIANGLEHEIGHT; 

                        instantiateRedTriangle(verticies, mouseClickCoor, !closestTriangle.Item1.mirror, 180);
                    }

                    else
                    {
                        if(distance[0] > 0)
                        {
                            string side = "R";
                            instantiateRedTriangle(closestTriangle.Item1.verticies, mouseClickCoor, !closestTriangle.Item1.mirror, 36);
                        }

                        else if(distance[0] <= 0)
                        {
                            string side = "L";
                            instantiateRedTriangle(closestTriangle.Item1.verticies, mouseClickCoor, !closestTriangle.Item1.mirror, -36);
                        }

                    }
                }
                else
                {
                    instantiateRedTriangle(mouseClickCoor, false);
                }
            }    

            else if(Input.GetMouseButtonDown(1))
            { 
                Vector3 mouseClickCoor =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var closestTriangle = getClosestTriangle(allObjects, mouseClickCoor);
                if(closestTriangle.Item2 < 0.9f)
                {   

                    // FIX!
                    // Tuple<Vector3[], bool> snapResult = getSnapCoords(closestTriangle.Item1, closestTriangle.Item3, "blue", mouseClickCoor);
                    // instantiateBlueTriangle(snapResult.Item1, mouseClickCoor, false);
                }
                else
                {
                    instantiateBlueTriangle(mouseClickCoor, false);
                }
            }
        }
        else
        {   
            if (Input.GetMouseButtonDown(0)) 
            {  
                Vector3 mouseClickCoor =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
                instantiateRedTriangle(mouseClickCoor, false);
            }
            else if (Input.GetMouseButtonDown(1)) 
            {  
                Vector3 mouseClickCoor =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
                instantiateBlueTriangle(mouseClickCoor, false);
            } 
        }
    }

    void instantiateRedTriangle(Vector3 clickPos, bool mirrorImage)
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
        instantiateRedTriangle(verticies, clickPos, mirrorImage, 0);
    }


    void instantiateBlueTriangle(Vector3 clickPos, bool mirrorImage)
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
        instantiateBlueTriangle(verticies, clickPos, mirrorImage);
    }


    void instantiateRedTriangle(Vector3[] verticies, Vector3 clickPos, bool mirrorImage, float angle)
    {   
        Vector3 vertex1 = verticies[0];
        Vector3 vertex2 = verticies[1];
        Vector3 vertex3 = verticies[2];

        Debug.Log(vertex1);


        GameObject obj = new GameObject();
        obj.SetActive(false);
        MeshFilter objFil= obj.AddComponent<MeshFilter>();
        MeshRenderer objRend = obj.AddComponent<MeshRenderer>();
        objRend.material = new Material(Shader.Find("Standard"));

        redTriangleMesh newTriangleMesh = obj.AddComponent<redTriangleMesh>();
        newTriangleMesh.Init(vertex1, vertex2, vertex3, mirrorImage);

        newTriangleMesh.transform.RotateAround(vertex3, new Vector3(0, 0, 1), angle);
        newTriangleMesh.centre = clickPos;

        obj.SetActive(true);
    }


    void instantiateBlueTriangle(Vector3[] verticies, Vector3 clickPos, bool mirrorImage)
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
        newTriangleMesh.Init(vertex1, vertex2, vertex3, mirrorImage);
        newTriangleMesh.centre = clickPos;

        obj.SetActive(true);
    }


    Tuple<triangleMesh, float> getClosestTriangle(List<triangleMesh> triangles, Vector3 mousePos)
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

        return new Tuple<triangleMesh, float>(closest, minDist);
    }   
}

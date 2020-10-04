using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperFunctions;
using System;

public class Manager : MonoBehaviour
{   
    public int _id = 0;

    private static float GOLDENRATIO = (1 + Mathf.Sqrt(5))/2; 

    private static float REDTRIANGLEHEIGHT = helperFunctionsClass.heronsFormula(1, 1/GOLDENRATIO, 1);
    private static float BLUETRIANGLEHEIGHT = helperFunctionsClass.heronsFormula(1, GOLDENRATIO, 1);

    // not sure where to keep this or at every update use  triangleMesh[] allObjects = UnityEngine.Object.FindObjectsOfType<triangleMesh>();
    public static List<triangleMesh> allObjects = new List<triangleMesh>();


    void Start()
    {

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

                    // Somehow centre doesnt know if it is flipped, so, for example, left of the centre becomes bottom of the triangle

                    Vector3 distance = mouseClickCoor - closestTriangle.Item1.centre;

                    if(distance[1] < 0)
                    {   
                        
                    }

                    else
                    {
                        if(distance[0] > 0)
                        {
                            if(closestTriangle.Item1.name == "redTriangle")
                            {
                                instantiateRedTriangle(closestTriangle.Item1.worldVerticies, !closestTriangle.Item1.mirror, + 36, true);
                            }

                            else if(closestTriangle.Item1.name == "blueTriangle")
                            {   
                                // calculating the diference in height from centre is wrong but don't know why
                                if(!closestTriangle.Item1.mirror)
                                {
                                    Vector3[] verticies = helperFunctionsClass.blueToRed(closestTriangle.Item1.worldVerticies[1]);
                                    instantiateRedTriangle(verticies,closestTriangle.Item1.mirror, closestTriangle.Item1.rotation - 144, false);
                                }
                                else
                                {
                                    // illegal
                                }
                            }
                        }

                        else if(distance[0] <= 0)
                        {
                            if(closestTriangle.Item1.name == "redTriangle")
                            {
                                instantiateRedTriangle(closestTriangle.Item1.worldVerticies, !closestTriangle.Item1.mirror, -36, true);
                            }
                            
                            else if(closestTriangle.Item1.name == "blueTriangle")
                            {   
                                if(closestTriangle.Item1.mirror)
                                {
                                    Vector3[] verticies = helperFunctionsClass.blueToRed(closestTriangle.Item1.worldVerticies[1]);
                                    instantiateRedTriangle(verticies, closestTriangle.Item1.mirror, closestTriangle.Item1.rotation + 144, true);
                                }
                                else
                                {
                                    // illegal
                                }
                            }
                        }

                    }
                }
                else
                {
                    instantiateRedTriangle(mouseClickCoor, false, 0, false);
                }
            }    

            else if(Input.GetMouseButtonDown(1))
            { 
                Vector3 mouseClickCoor =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var closestTriangle = getClosestTriangle(allObjects, mouseClickCoor);
                if(closestTriangle.Item2 < 0.9f)
                {   
                    Vector3 distance = mouseClickCoor - closestTriangle.Item1.centre;

                    if(distance[1] < 0)
                    {   
                        
                    }
                    else
                    {
                        if(distance[0] > 0)
                        {
                            if(closestTriangle.Item1.name == "blueTriangle")
                            {
                                instantiateBlueTriangle(closestTriangle.Item1.worldVerticies,!closestTriangle.Item1.mirror, 108, true);
                            }

                            else if(closestTriangle.Item1.name == "redTriangle")
                            {
                                Vector3[] verticies = helperFunctionsClass.redToBlue(closestTriangle.Item1.worldVerticies[1]);
                                instantiateBlueTriangle(verticies, closestTriangle.Item1.mirror, closestTriangle.Item1.rotation + 144, false);
                            }
                        }

                        else if(distance[0] <= 0)
                        {
                            if(closestTriangle.Item1.name == "blueTriangle")
                            {
                                instantiateBlueTriangle(closestTriangle.Item1.worldVerticies,!closestTriangle.Item1.mirror, -108, true);
                            }

                            else if(closestTriangle.Item1.name == "redTriangle")
                            {
                                Vector3[] verticies = helperFunctionsClass.redToBlue(closestTriangle.Item1.worldVerticies[0]);
                                instantiateBlueTriangle(verticies, closestTriangle.Item1.mirror, closestTriangle.Item1.rotation - 144, false);
                            }
                        }
                    }
                }
                else
                {
                    instantiateBlueTriangle(mouseClickCoor, false, 0, false);
                }
            }
        }
        else
        {   
            if (Input.GetMouseButtonDown(0)) 
            {  
                Vector3 mouseClickCoor =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
                instantiateRedTriangle(mouseClickCoor, false, 0, false);
            }
            else if (Input.GetMouseButtonDown(1)) 
            {  
                Vector3 mouseClickCoor =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
                instantiateBlueTriangle(mouseClickCoor, false, 0, false);
            } 
        }
    }

    void instantiateRedTriangle(Vector3 clickPos, bool mirrorImage, float angle, bool snap)
    {   
        float halfHeightRed = REDTRIANGLEHEIGHT/2;

        Vector3 vertex1 = clickPos;
        vertex1[0] -= 0.5f * (1/GOLDENRATIO);
        vertex1[1] -= halfHeightRed;
        
        Vector3 vertex2 = clickPos;
        vertex2[0] += 0.5f * (1/GOLDENRATIO);   
        vertex2[1] -= halfHeightRed;

        Vector3 vertex3 = clickPos;
        vertex3[1] += halfHeightRed;

        Vector3[] verticies = new [] {vertex1, vertex2, vertex3};
        instantiateRedTriangle(verticies, mirrorImage, angle, snap);
    }


    void instantiateBlueTriangle(Vector3 clickPos, bool mirrorImage, float angle, bool snap)
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
        instantiateBlueTriangle(verticies, mirrorImage, angle, snap);
    }


    void instantiateRedTriangle(Vector3[] verticies, bool mirrorImage, float angle, bool snap)
    {   
        _id +=1;
        
        Vector3 vertex1 = verticies[0];
        Vector3 vertex2 = verticies[1];
        Vector3 vertex3 = verticies[2];

        GameObject obj = new GameObject();
        obj.SetActive(false);
        MeshFilter objFil= obj.AddComponent<MeshFilter>();
        MeshRenderer objRend = obj.AddComponent<MeshRenderer>();
        objRend.material = new Material(Shader.Find("Standard"));

        redTriangleMesh newTriangleMesh = obj.AddComponent<redTriangleMesh>();
        newTriangleMesh.Init(vertex1, vertex2, vertex3, mirrorImage, snap);

        newTriangleMesh.transform.RotateAround(vertex3, new Vector3(0, 0, 1), angle);
        newTriangleMesh._id = _id;
        newTriangleMesh.rotation = angle;

        obj.SetActive(true);
    }


    void instantiateBlueTriangle(Vector3[] verticies, bool mirrorImage, float angle, bool snap)
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
        newTriangleMesh.Init(vertex1, vertex2, vertex3, mirrorImage, snap);
        newTriangleMesh.transform.RotateAround(vertex3, new Vector3(0, 0, 1), angle);
        newTriangleMesh._id = _id;
        newTriangleMesh.rotation = angle;

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

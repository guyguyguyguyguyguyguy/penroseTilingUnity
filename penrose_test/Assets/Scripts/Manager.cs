using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperFunctions;
using System;

public class Manager : MonoBehaviour
{
    private static float GOLDENRATIO = (1 + Mathf.Sqrt(5))/2; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        triangleMesh[] allObjects = UnityEngine.Object.FindObjectsOfType<triangleMesh>();

        if (Input.GetMouseButtonDown(0)) 
        {   
            Vector3 mouseClickCoor =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // var closestTriangle = getClosestTriangle(allObjects, mouseClickCoor);
            instantiateRedTriangle(mouseClickCoor);
            // if(closestTriangle.Item2 < 0.5f)
            // {   
            //     Vector3[] snapCoords = getSnapCoords(closestTriangle.Item1, "red");
            //     instantiateRedTriangle(snapCoords);
            // }
            // else
            // {
            //     instantiateRedTriangle(mouseClickCoor);
            // }
        }    

        else if(Input.GetMouseButtonDown(1))
        { 
            Vector3 mouseClickCoor =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // var closestTriangle = getClosestTriangle(allObjects, mouseClickCoor);
            instantiateBlueTriangle(mouseClickCoor);
            // if(closestTriangle.Item2 < 0.5f)
            // {
            //     Vector3[] snapCoords = getSnapCoords(closestTriangle.Item1, "blue");
            //     instantiateBlueTriangle(snapCoords);
            // }
            // else
            // {
            //     instantiateBlueTriangle(mouseClickCoor);
            // }
        }
    }

    void instantiateRedTriangle(Vector3 clickPos)
    {   

        float halfHeightRed = helperFunctionsClass.heronsFormula(GOLDENRATIO, 1, GOLDENRATIO) / 2;

        Vector3 vertex1 = clickPos;
        vertex1[0] -= 0.5f;
        vertex1[1] -= halfHeightRed;
        
        Vector3 vertex2 = clickPos;
        vertex2[0] += 0.5f;
        vertex2[1] -= halfHeightRed;

        Vector3 vertex3 = clickPos;
        vertex3[1] += halfHeightRed;

        GameObject obj = new GameObject();
        obj.SetActive(false);
        MeshFilter objFil= obj.AddComponent<MeshFilter>();
        MeshRenderer objRend = obj.AddComponent<MeshRenderer>();
        objRend.material = new Material(Shader.Find("Standard"));

        redTriangleMesh newTriangleMesh = obj.AddComponent<redTriangleMesh>();
        newTriangleMesh.Init(vertex1, vertex2, vertex3);

        obj.SetActive(true);
    }


    void instantiateBlueTriangle(Vector3 clickPos)
    {   

        float halfHeightBlue = helperFunctionsClass.heronsFormula(1, GOLDENRATIO, 1) / 2;

        Vector3 vertex1 = clickPos;
        vertex1[0] -= GOLDENRATIO/2;
        vertex1[1] -= halfHeightBlue;
        
        Vector3 vertex2 = clickPos;
        vertex2[0] += GOLDENRATIO/2;
        vertex2[1] -= halfHeightBlue;

        Vector3 vertex3 = clickPos;
        vertex3[1] += halfHeightBlue;

        GameObject obj = new GameObject();
        obj.SetActive(false);
        MeshFilter objFil= obj.AddComponent<MeshFilter>();
        MeshRenderer objRend = obj.AddComponent<MeshRenderer>();
        objRend.material = new Material(Shader.Find("Standard"));

        blueTriangleMesh newTriangleMesh = obj.AddComponent<blueTriangleMesh>();
        newTriangleMesh.Init(vertex1, vertex2, vertex3);

        obj.SetActive(true);
    }


    void instantiateRedTriangle(Vector3[] verticies)
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
        newTriangleMesh.Init(vertex1, vertex2, vertex3);

        obj.SetActive(true);
    }


    void instantiateBlueTriangle(Vector3[] verticies)
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

        obj.SetActive(true);
    }


    Tuple<triangleMesh, float, Vector3> getClosestTriangle(triangleMesh[] triangles, Vector3 mousePos)
    {
        triangleMesh closest = null;
        float minDist = Mathf.Infinity;
        foreach (triangleMesh t in triangles)
        {
            float dist = Vector3.Distance(t.transform.position, mousePos);
            if (dist < minDist)
            {
                closest = t;
                minDist = dist;
            }
        }

        float minDistVer = Mathf.Infinity;
        Vector3 nearestVertex = Vector3.zero;
        foreach (Vector3 v in closest.verticies)
        {
            float dist = Vector3.Distance(mousePos, v);
            if(dist < minDistVer)
            {
                minDistVer = dist;
                nearestVertex = v;
            }
        }

        return new Tuple<triangleMesh, float, Vector3>(closest, minDist, nearestVertex);
    }   

    // Vector3[] getSnapCoords(triangleMesh closeTriangle, string colour)
    // {   

    //     // return the verticies of the new object based on closest triangle

    //     switch(colour)
    //     {
    //         case "blue" when closeTriangle.name == "redTriangle":
                

    //             break;
            
    //         case "blue" when closeTriangle.name == "blueTriangle":

    //             break;

    //         case "red" when closeTriangle.name == "redTriangle":

    //             break;

    //         case "red" when closeTriangle.name == "blueTriangle":

    //             break;
    //     }

    //     return snapVerticies;
    // }
}

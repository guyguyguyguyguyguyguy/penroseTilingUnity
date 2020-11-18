using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HelperFunctions;

public class Drawer : MonoBehaviour
{   
    public Vector3[] vertices = null;
    public int[] triangles = null;

    protected Mesh awesomeMesh;
    protected Renderer rend; 


    void Awake()
    {   
        awesomeMesh = GetComponent<MeshFilter>().sharedMesh;
        rend = GetComponent<Renderer>();
    }

   
    void Update()
    {   
        awesomeMesh = new Mesh();
        GetComponent<MeshFilter>().sharedMesh = awesomeMesh;
        awesomeMesh.Clear();
        awesomeMesh.vertices = vertices;
        awesomeMesh.triangles = triangles;

        // Need to ensure that this is updated first before the tiles, how?
        if(Input.GetKeyDown(KeyCode.Space))
        {
            RedTile.redTag = 0;
            BlueTile.blueTag = 0;

            vertices = null;
            triangles = null;
        }
    }


    public void AddToRend(Vector3[] vertices, int[] triangles)
    {   
        HelperFunctionsClass.AddToArray<Vector3>(ref this.vertices, vertices);
        HelperFunctionsClass.AddToArray<int>(ref this.triangles, triangles);
    }
}

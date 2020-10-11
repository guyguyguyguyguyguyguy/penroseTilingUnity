using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperFunctions;

public class drawer : MonoBehaviour
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


    void Start()
    {
        
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
            redTile.redTag = 0;
            blueTile.blueTag = 0;

            vertices = null;
            triangles = null;
        }

    }


    public void addToRend(Vector3[] vertices, int[] triangles)
    {   
        helperFunctionsClass.addToArray<Vector3>(ref this.vertices, vertices);
        helperFunctionsClass.addToArray<int>(ref this.triangles, triangles);
    }
}

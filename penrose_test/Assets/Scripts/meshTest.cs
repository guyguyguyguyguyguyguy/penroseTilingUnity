using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshTest : MonoBehaviour
{   
    private static float GOLDENRATIO = (1 + Mathf.Sqrt(5))/2;
    private Vector3 vertex1;
    private Vector3 vertex2;
    private Vector3 vertex3;
    public Vector3[] verticies;
    public int[] triangles;

    public meshTest()
    {
        vertex1 = new Vector3(0,0,-10);
        vertex2 = new Vector3(GOLDENRATIO,0,-10);
        float x = 1/(2*GOLDENRATIO);
        float y = Mathf.Sqrt(1-(x * x));
        vertex3 = new Vector3(x,y,-10);
    }
    
    public meshTest(Vector3 ver1, Vector3 ver2, Vector3 ver3){
        
        vertex1 = ver1;
        vertex2 = ver2;
        vertex3 = ver3;
    }
    Mesh awesomeMesh;
    Renderer rend; 

    // Start is called before the first frame update
    void Start()
    {
        // verticies = new Vector3[3];
        // verticies[0] = new Vector3(0,0,-10);
        // verticies[1] = new Vector3(GOLDENRATIO,0,-10);
        // float x = 1/(2*GOLDENRATIO);
        // float y = Mathf.Sqrt(1-(x * x));
        // verticies[2] = new Vector3(x,y,-10);

        verticies = new Vector3[3];
        verticies[0] = vertex1;
        verticies[1] = vertex2;
        verticies[2] = vertex3;

        triangles = new int[3];
        triangles[0] = 0;
        triangles[1] = 2;
        triangles[2] = 1;

        awesomeMesh = new Mesh();
        GetComponent<MeshFilter>().sharedMesh = awesomeMesh;
        awesomeMesh.Clear();
        awesomeMesh.vertices = verticies;
        awesomeMesh.triangles = triangles;

        rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", Random.ColorHSV());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

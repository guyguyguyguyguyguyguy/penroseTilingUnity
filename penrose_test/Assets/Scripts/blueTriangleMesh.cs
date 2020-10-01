using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperFunctions;

public class blueTriangleMesh : triangleMesh
{   

    protected override void Awake()
    {

    }

    // Start is called before the first frame update
    protected override void Start()
    {   
        this.name = "blueTriangle"; 

        worldVertex1 = transform.TransformPoint(vertex1);
        worldVertex2 = transform.TransformPoint(vertex2);
        worldVertex3 = transform.TransformPoint(vertex3);

        vertex1[2] = -10f;
        vertex2[2] = -10f;
        vertex3[2] = -10f;

        verticies = new Vector3[3];
        verticies[0] = vertex1;
        verticies[1] = vertex2;
        verticies[2] = vertex3;



        awesomeMesh = new Mesh();
        GetComponent<MeshFilter>().sharedMesh = awesomeMesh;
        awesomeMesh.Clear();
        awesomeMesh.vertices = verticies;
        awesomeMesh.triangles = triangles;

        rend = GetComponent<Renderer>();
        Color newColour;
        ColorUtility.TryParseHtmlString("#6667FF", out newColour);
        rend.material.SetColor("_Color", newColour);


        outlineL = _drawLine(worldVertex1, worldVertex3, Color.black, "outlineL");
        outlineR = _drawLine(worldVertex3, worldVertex2, Color.black, "outlineR");
    }

    protected override  void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            deflate();

            Destroy(gameObject);
            Destroy(outlineL);
            Destroy(outlineR);
        }
    }

    public override void deflate()
    {   
        Vector3 C = worldVertex2;
        Vector3 B = worldVertex1; 
        Vector3 A = worldVertex3;
        Vector3 Q = B + (A - B) / GOLDENRATIO;
        Vector3 R = B + (C - B) / GOLDENRATIO;

        if(Label == "mirror")
        {
        _deflate(typeof(blueTriangleMesh), R, B, Q);
        _deflate(typeof(redTriangleMesh), Q, A, R);
        _deflate(typeof(blueTriangleMesh), C, A, R, 1, 2, 0, "mirror");
        }

        else
        {
        _deflate(typeof(blueTriangleMesh), R, B, Q, 1, 2, 0, "mirror");
        _deflate(typeof(redTriangleMesh), Q, A, R, 1, 2, 0, "mirror");
        _deflate(typeof(blueTriangleMesh), C, A, R);
        }
    }

}

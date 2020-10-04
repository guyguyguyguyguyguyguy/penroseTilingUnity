using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperFunctions;

public class redTriangleMesh : triangleMesh
{   

    new private static float height = helperFunctionsClass.heronsFormula(1, 1/GOLDENRATIO, 1);

    protected override void Awake()
    {

    }

    // Start is called before the first frame update
    protected override void Start()
    {   
        this.name = "redTriangle";

        worldVertex1 = transform.TransformPoint(vertex1);
        worldVertex2 = transform.TransformPoint(vertex2);
        worldVertex3 = transform.TransformPoint(vertex3);

        worldVerticies = new Vector3[3];
        worldVerticies[0] = worldVertex1;
        worldVerticies[1] = worldVertex2;
        worldVerticies[2] = worldVertex3;

        this.centre = centreOfTile();
        

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
        ColorUtility.TryParseHtmlString("#FF5958", out newColour);
        rend.material.SetColor("_Color", newColour);

        outlineL = _drawLine(worldVertex1, worldVertex3, Color.black, "outlineL");
        outlineR = _drawLine(worldVertex3, worldVertex2, Color.black, "outlineR");

    }

    protected override void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            
            deflate();

            Destroy(gameObject);
            Destroy(outlineL);
            Destroy(outlineR);
        }
    }

    public override void deflate()
    {   
        Vector3 A = worldVertex3;
        Vector3 B = worldVertex1; 
        Vector3 C = worldVertex2;
        Vector3 P = A + (B - A) / GOLDENRATIO;
        
        if(mirror)
        {
            _deflate(typeof(redTriangleMesh), P, B, C, true);
            _deflate(typeof(blueTriangleMesh), C, A, P,true);
        }
        else
        {
            _deflate(typeof(redTriangleMesh), P, B, C, false);
            _deflate(typeof(blueTriangleMesh), C, A, P, false);
        }
    }

    public override Vector3 thirdVertexCalc(Vector3 origin, Vector3 secondVertex)
    {
        Vector3 thirdVertc = Vector3.zero;
        float AB = Vector3.Distance(origin, secondVertex);

        float x = AB * Mathf.Cos(36 * Mathf.PI/180) + origin[0];
        float y = AB * Mathf.Sin(36 * Mathf.PI/180) + origin[1];

        thirdVertc[0] = x;
        thirdVertc[1] = y;
        thirdVertc[2] = -10f;

        return thirdVertc;
    }
}

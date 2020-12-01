using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HelperFunctions;

public class ThickRhomb : Tile
{

    void Start()
    {

        // Collider does not work for placed tiles???? whyyyy


        Vector2[] colPoints = GetComponent<PolygonCollider2D>().points;

        for (int i = 0; i < 4; ++i)
        {
            Vector3 worldVer = transform.TransformPoint(tileVertices[i]);
            worldVertices[i] = worldVer;

            Vector2 colliderPoint = worldVer;
            colPoints.SetValue(colliderPoint, i);
        }

        (colPoints[1], colPoints[2]) = (colPoints[2], colPoints[1]);
        GetComponent<PolygonCollider2D>().points = colPoints;

        RobTriangle[] tris = createP3Tile("blue", worldVertices[0], worldVertices[1], worldVertices[2], worldVertices[3], rotation);

        nonMirrorTri = tris[0];
        mirrorTri = tris[1];

        centre = centreOfTile();

        _drawLine();

        labelEdges();
        FindNeighbours();

        Manager.allObjects.Add(this);

    }


    public void Init(Vector3 clickPos)
    {
        name = "thickRhomb";

        Vector3 ver1 = clickPos - new Vector3 ( 0, 0.5f * HelperFunctionsClass.blueBase ); 
        Vector3 ver2 = clickPos + new Vector3 ( 0, 0.5f * HelperFunctionsClass.blueBase );
        Vector3 ver3 = clickPos - new Vector3 ( HelperFunctionsClass.blueHeight, 0 );
        Vector3 ver4 = clickPos + new Vector3 ( HelperFunctionsClass.blueHeight, 0 );


        tileVertices = new Vector3[] {ver1, ver2, ver3, ver4};
    }


    public void InitUser(Vector3 ver1, Vector3 ver2, Vector3 ver3, Vector3 ver4)
    {
        name = "thickRhomb";

        tileVertices = new Vector3[] {ver1, ver2, ver3, ver4};

    }


    public void InitDeflate(Vector3 ver1, Vector3 ver2, Vector3 ver3, Vector3 ver4, int matchCase)
    {
        name = "thickRhomb";

        tileVertices = new Vector3[] {ver1, ver2, ver3, ver4};
    }
}


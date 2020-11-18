using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HelperFunctions;

public class ThinRhomb : Tile
{

    public void Init(Vector3 clickPos)
    {
        name = "thinRhomb";

        Vector3 ver1 = clickPos - new Vector3 ( (0.5f * HelperFunctionsClass.redBase), 0 ); 
        Vector3 ver2 = clickPos + new Vector3 ( (0.5f * HelperFunctionsClass.redBase), 0 );
        Vector3 ver3 = clickPos + new Vector3 ( 0, HelperFunctionsClass.redHeight);
        Vector3 ver4 = clickPos - new Vector3 ( 0, HelperFunctionsClass.redHeight );

        ver1 = transform.TransformPoint(ver1);
        ver2 = transform.TransformPoint(ver2);
        ver3 = transform.TransformPoint(ver3);
        ver4 = transform.TransformPoint(ver4);

        tileVertices = new Vector3[] {ver1, ver2, ver3, ver4};

        createP3Tile("red", ver1, ver2, ver3, ver4);

        centre = centreOfTile();

        _drawLine();

        labelEdges();
        FindNeighbours();

        Manager.allObjects.Add(this);
    }


    public void InitUser(Vector3 ver1, Vector3 ver2, Vector3 ver3, Vector3 ver4, int matchEdge)
    {
        name = "thinRhomb";

        tileVertices = new Vector3[] {ver1, ver2, ver3, ver4};

        createP3Tile("red", ver1, ver2, ver3, ver4);
        centre = centreOfTile();


        _drawLine();


        labelEdges();
        FindNeighbours();

        Manager.allObjects.Add(this);
    }


    public void InitDeflate(Vector3 ver1, Vector3 ver2, Vector3 ver3, Vector3 ver4, int matchCase)
    {
        name = "thinRhomb";

        tileVertices = new Vector3[] {ver1, ver2, ver3, ver4};
        centre = centreOfTile();
        matchingCase = matchCase;

        labelEdges();
        FindNeighbours();

        _drawLine();


        Manager.allObjects.Add(this);
    }
}

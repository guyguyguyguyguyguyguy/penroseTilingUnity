using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HelperFunctions;

public class ThickRhomb : Tile
{
    void Start()
    {
        for (int i = 0; i < 4; ++i)
        {
            worldVertices[i] = transform.TransformPoint(tileVertices[i]);
        }

        createP3Tile("blue", worldVertices[0], worldVertices[1], worldVertices[2], worldVertices[3]);

        centre = centreOfTile();

        _drawLine();

        labelEdges();
        FindNeighbours();

        Manager.allObjects.Add(this);

    }


    void Update()
    {

    }

    public void Init(Vector3 clickPos)
    {
        name = "thickRhomb";

        Vector3 ver1 = clickPos - new Vector3 ( (0.5f * HelperFunctionsClass.redBase), 0 ); 
        Vector3 ver2 = clickPos + new Vector3 ( (0.5f * HelperFunctionsClass.redBase), 0 );
        Vector3 ver3 = clickPos + new Vector3 ( 0, HelperFunctionsClass.redHeight);
        Vector3 ver4 = clickPos - new Vector3 ( 0, HelperFunctionsClass.redHeight );


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


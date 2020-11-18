using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HelperFunctions;

public class ThickRhomb : Tile
{

    public void Init(Vector3 clickPos)
    {
        name = "thickRhomb";

        Vector3 ver1 = clickPos - new Vector3 ( 0, HelperFunctionsClass.blueBase * 0.5f ); 
        Vector3 ver2 = clickPos + new Vector3 ( 0, HelperFunctionsClass.blueBase * 0.5f );
        Vector3 ver3 = clickPos - new Vector3 ( HelperFunctionsClass.blueHeight, 0 );
        Vector3 ver4 = clickPos + new Vector3 ( HelperFunctionsClass.blueHeight, 0 );

        tileVertices = new Vector3[] {ver1, ver2, ver3, ver4};

        createP3Tile("blue", ver1, ver2, ver3, ver4);


        centre = centreOfTile();

        labelEdges();
        FindNeighbours();

        Manager.allObjects.Add(this);
    }


    public void InitUser(Vector3 ver1, Vector3 ver2, Vector3 ver3, Vector3 ver4, float angleRotation, int matchCase)
    {
        name = "thickRhomb";

        tileVertices = new Vector3[] {ver1, ver2, ver3, ver4};

        createP3Tile("blue", ver1, ver2, ver3, ver4);     
        centre = centreOfTile();

        labelEdges();
        FindNeighbours();

        Manager.allObjects.Add(this);
    }


    public void InitDeflate(Vector3 ver1, Vector3 ver2, Vector3 ver3, Vector3 ver4, int matchCase)
    {
        name = "thickRhomb";

        tileVertices = new Vector3[] {ver1, ver2, ver3, ver4};
        centre = centreOfTile();
        matchingCase = matchCase;

        labelEdges();
        FindNeighbours();

        Manager.allObjects.Add(this);

    }
}


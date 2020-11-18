using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HelperFunctions;

public class DartTile : Tile
{

    public void Init(Vector3 clickPos)
    {
        name = "dartTile";

        // tileVertices = createP2Tile("blue", clickPos);

        centre = centreOfTile();
        // roation = 0;

        labelEdges();

        Manager.allObjects.Add(this);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HelperFunctions;

public class KiteTile : Tile
{

    public void Init(Vector3 clickPos)
    {
        name = "kiteTile";

        // tileVertices = createP2Tile("red", clickPos);

        centre = centreOfTile();
        // roation = 0;

        labelEdges();

        Manager.allObjects.Add(this);
    }

}

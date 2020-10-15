using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperFunctions;

public class dartTile : tile
{

    public void Init(Vector3 clickPos)
    {
        name = "dartTile";

        tileVertices = createP2Tile("blue", clickPos);

        centre = centreOfTile();
        // roation = 0;

        labelEdges();

        manager.allObjects.Add(this);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperFunctions;

public class kiteTile : tile
{

    public void Init(Vector3 clickPos)
    {
        name = "kiteTile";

        tileVertices = createP2Tile("red", clickPos);

        centre = centreOfTile();
        // roation = 0;

        labelEdges();

        manager.allObjects.Add(this);
    }

}

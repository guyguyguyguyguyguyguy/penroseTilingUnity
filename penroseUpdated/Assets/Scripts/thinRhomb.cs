using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperFunctions;

public class thinRhomb : tile
{

    public void Init(Vector3 clickPos)
    {
        name = "thinRhomb";

        tileVertices = createP3Tile("red", clickPos);

        centre = centreOfTile();
        rotation = -288;

        labelEdges();

        manager.allObjects.Add(this);
    }


    public void InitUser(Vector3 ver1, Vector3 ver2, Vector3 ver3, Vector3 ver4, float angleRotation, int matchCase)
    {
        name = "thinRhomb";

        tileVertices = createP3Tile("red", ver1, ver2, ver3, ver4);        
        rotation = angleRotation;
        centre = centreOfTile();
        matchingCase = matchCase;

        labelEdges();

        manager.allObjects.Add(this);
    }

}

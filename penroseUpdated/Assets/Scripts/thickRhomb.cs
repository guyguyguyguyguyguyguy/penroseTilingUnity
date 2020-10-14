using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperFunctions;

public class thickRhomb : tile
{

    public void Init(Vector3 clickPos)
    {
        Init(clickPos, false, true);
    }

    public void Init(Vector3 clickPos, bool leftMirror, bool rightMirror)
    {
        Init(clickPos, leftMirror, rightMirror, 0f, new Vector3(0, 0, -Mathf.PI));
    }

    public void Init(Vector3 clickPos, bool leftMirror, bool rightMirror, float pivotangle, Vector3 pivot)
    {

        name = "thickRhomb";

        tileVertices = createP3Tile("blue", clickPos);

        centre = centreOfTile();
        rotation = -270;

        labelEdges();

        manager.allObjects.Add(this);
    }

        public void InitUser(Vector3 ver1, Vector3 ver2, Vector3 ver3, Vector3 ver4, float angleRotation, int matchCase)
    {
        name = "thickRhomb";

        tileVertices = createP3Tile("blue", ver1, ver2, ver3, ver4);        
        rotation = angleRotation;
        centre = centreOfTile();
        matchingCase = matchCase;

        labelEdges();

        manager.allObjects.Add(this);
    }

}


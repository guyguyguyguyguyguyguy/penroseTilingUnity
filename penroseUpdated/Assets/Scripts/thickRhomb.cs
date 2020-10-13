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

        Vector3[] rightVertices = createP3Tile("blue", clickPos, -90, pivotangle,  "rightThick", rightMirror, pivot);
        Vector3[] leftVertices = createP3Tile("blue", clickPos, 90f, pivotangle, "leftThick", leftMirror, pivot);

        // tileVertices = new Vector3[] {leftVertices[2], leftVertices[1], rightVertices[2], leftVertices[0]};

        tileVertices = new Vector3[] {leftVertices[0], leftVertices[2] ,leftVertices[1], rightVertices[2]};

        centre = centreOfTile();
        rotation = pivotangle;

        manager.allObjects.Add(this);
    }



    protected override void Start()
    {  

    }


    protected override void Update()
    {
        
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperFunctions;

public class thinRhomb : tile
{

    public void Init(Vector3 clickPos)
    {
        Init(clickPos, false, true);
    }

    public void Init(Vector3 clickPos, bool topMirror, bool bottomMirror)
    {
        Init(clickPos, topMirror, bottomMirror, 0f, new Vector3(0, 0, -Mathf.PI));
    }

    public void Init(Vector3 clickPos, bool topMirror, bool bottomMirror, float pivotangle, Vector3 pivot)
    {
        centre = clickPos;

        createP3Tile("red", clickPos, 0f, pivotangle,  "topThin", topMirror, pivot);
        createP3Tile("red", clickPos, 180f, pivotangle, "bottomThin", bottomMirror, pivot);
    }


    protected override void Start()
    {  

    }


    protected override void Update()
    {
        
    }
}

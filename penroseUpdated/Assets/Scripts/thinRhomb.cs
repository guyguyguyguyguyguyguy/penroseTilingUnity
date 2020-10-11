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
        centre = clickPos;

        createP3Tile("red", clickPos, 0, "topThin", topMirror);
        createP3Tile("red", clickPos, 180, "bottomThin", bottomMirror);
    }


    protected override void Start()
    {  

    }


    protected override void Update()
    {
        
    }
}

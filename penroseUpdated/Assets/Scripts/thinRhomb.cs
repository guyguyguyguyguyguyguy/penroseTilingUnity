using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperFunctions;

public class thinRhomb : tile
{

    public void Init(Vector3 clickPos)
    {
        centre = clickPos;

        createP3Tile("red", clickPos, 0, "topTriangle", false, false);
        createP3Tile("red", clickPos, 180, "bottomTriangle", true, true);
    }


    protected override void Start()
    {  

    }


    protected override void Update()
    {
        
    }
}

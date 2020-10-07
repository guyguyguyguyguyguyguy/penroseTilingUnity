using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperFunctions;

public class thickRhomb : tile
{

    public void Init(Vector3 clickPos)
    {
        centre = clickPos;

        createP3Tile("blue", clickPos, -90, "leftTriangle", false, false);
        createP3Tile("blue", clickPos, 90, "rightTriangle", true, true);
    }


    protected override void Start()
    {  

    }


    protected override void Update()
    {
        
    }
}


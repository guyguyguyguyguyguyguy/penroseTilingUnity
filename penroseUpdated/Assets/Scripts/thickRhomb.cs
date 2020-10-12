using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperFunctions;

public class thickRhomb : tile
{

    public void Init(Vector3 clickPos)
    {
        centre = clickPos;

        createP3Tile("blue", clickPos, -90, "leftThick", false);
        createP3Tile("blue", clickPos, 90, "rightThick", true);
    }


    protected override void Start()
    {  

    }


    protected override void Update()
    {
        
    }
}


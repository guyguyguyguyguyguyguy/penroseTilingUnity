using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperFunctions;

public class kiteTile : tile
{

    public void Init(Vector3 clickPos)
    {
        centre = clickPos - new Vector3(0, 0.5f *helperFunctionsClass.redSides);

        createP2Tile("red", clickPos, -18, "leftKite", true, true);
        createP2Tile("red", clickPos, 18, "rightKite", false, false);
    }


    protected override void Start()
    {  

    }


    protected override void Update()
    {
        
    }
}

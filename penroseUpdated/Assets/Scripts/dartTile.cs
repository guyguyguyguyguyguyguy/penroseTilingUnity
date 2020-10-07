using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperFunctions;

public class dartTile : tile
{

    public void Init(Vector3 clickPos)
    {
        centre = clickPos - new Vector3(0, 0.5f * helperFunctionsClass.blueSides);

        createP2Tile("blue", clickPos, -126, "leftTriangle", false, false);
        createP2Tile("blue", clickPos, 126, "rightTriangle", true, true);

    }


    protected override void Start()
    {  

    }


    protected override void Update()
    {
        
    }
}

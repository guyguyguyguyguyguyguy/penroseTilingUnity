using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperFunctions;

public class kiteTile : tile
{

    public void Init(Vector3 clickPos)
    {
        centre = clickPos;

        createTile("red", clickPos, -18, "leftTriangle");
        createTile("red", clickPos, 18, "rightTriangle");
    }


    protected override void Start()
    {  

    }


    protected override void Update()
    {
        
    }
}

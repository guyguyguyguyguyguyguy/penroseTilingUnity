using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperFunctions;

public class dartTile : tile
{

    public void Init(Vector3 clickPos)
    {
        centre = clickPos;

        createTile("blue", clickPos, -126, "leftTriangle");
        createTile("blue", clickPos, 126, "rightTriangle");

    }


    protected override void Start()
    {  

    }


    protected override void Update()
    {
        
    }
}

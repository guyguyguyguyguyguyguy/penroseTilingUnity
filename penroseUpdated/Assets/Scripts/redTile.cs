using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using helperFunctions;

public class redTile : robTriangle
{   
    public static int redTag = 0;

    protected override void Start()
    {

    }


    protected override void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            deflate();

            Destroy(gameObject);
            Destroy(outlineL);
            Destroy(outlineR);
            redTag--;

            manager.allObjects.Remove(this);
        }
    }

    public override void deflate()
    {   
        Vector3 A = worldVertex3 * helperFunctionsClass.GOLDENRATIO;
        Vector3 B = worldVertex1 * helperFunctionsClass.GOLDENRATIO; 
        Vector3 C = worldVertex2 * helperFunctionsClass.GOLDENRATIO;
        Vector3 P = A + (B - A) / helperFunctionsClass.GOLDENRATIO;
        
        // if(mirror)
        // {
        //     _deflate(typeof(redTriangleMesh), P, B, C, true);
        //     _deflate(typeof(blueTriangleMesh), C, A, P,true);
        // }
        // else
        // {
        //     _deflate(typeof(redTriangleMesh), P, B, C, false);
        //     _deflate(typeof(blueTriangleMesh), C, A, P, false);
        // }
    }
}

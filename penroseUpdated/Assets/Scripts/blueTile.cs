using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using helperFunctions;

public class blueTile : robTriangle
{   
    public static int blueTag = 0;

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
            blueTag--;

            manager.allObjects.Remove(this);
        }
    }

    public override void deflate()
    {   
        Vector3 C = worldVertex2 * helperFunctionsClass.GOLDENRATIO;
        Vector3 B = worldVertex1 * helperFunctionsClass.GOLDENRATIO; 
        Vector3 A = worldVertex3 * helperFunctionsClass.GOLDENRATIO;
        Vector3 Q = B + (A - B) / helperFunctionsClass.GOLDENRATIO;
        Vector3 R = B + (C - B) / helperFunctionsClass.GOLDENRATIO;

    //     if(mirror)
    //     {
    //     _deflate(typeof(blueTriangleMesh), R, B, Q, false);
    //     _deflate(typeof(redTriangleMesh), Q, A, R, false);
    //     _deflate(typeof(blueTriangleMesh), C, A, R, true);
    //     }

    //     else
    //     {
    //     _deflate(typeof(blueTriangleMesh), R, B, Q, true);
    //     _deflate(typeof(redTriangleMesh), Q, A, R, true);
    //     _deflate(typeof(blueTriangleMesh), C, A, R, false);
    //     }
    }
}

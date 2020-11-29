using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using HelperFunctions;
using System.Text.RegularExpressions;

public class RedTile : RobTriangle
{   
    public static int redTag = 0;


    public override void deflate()
    {   
        Vector3 A = vertices[2] * HelperFunctionsClass.GOLDENRATIO;
        Vector3 B = vertices[0] * HelperFunctionsClass.GOLDENRATIO; 
        Vector3 C = vertices[1] * HelperFunctionsClass.GOLDENRATIO;


        if(typeOfTiling == "P3")
        {

            Vector3 P = A + (B - A) / HelperFunctionsClass.GOLDENRATIO;

            if(mirrored)
            {
                _deflate("thinRhomb", B, P, C, true, "thinRhomb", redTag, tileRotation - 72f);
                _deflate("thinRhomb", A, C, P,true, "thickRhomb", BlueTile.blueTag, tileRotation - 18f);
            }

  

            else
            {
                _deflate("thinRhomb", P, B, C, false, "thinRhomb", redTag, tileRotation + 72f);
                _deflate("thinRhomb", C, A, P, false, "thickRhomb", BlueTile.blueTag, tileRotation +198f);
            }

  
        }
        
        else if(typeOfTiling == "Kite" || typeOfTiling == "Dart")
        {
            // // for tests
            // A += new Vector3(1, 0);
            // B += new Vector3(1, 0);
            // C += new Vector3(1, 0);

            // Vector3 P = A + (B -A) / HelperFunctionsClass.GOLDENRATIO;
            // Vector3 Q = C + (A - C) / HelperFunctionsClass.GOLDENRATIO;

            // if(mirrored)
            // {
            //     _deflate(typeof(RedTile), B, P, C, true, "leftKite", redTag);
            //     redTag++;
            //     Debug.Log("doing this non-mirror one");
            //     _deflate(typeof(RedTile), P, Q, C, false, "rightKite", redTag); 
            //     redTag++;
            //     _deflate(typeof(BlueTile), P, A, Q, true, "rightDart", BlueTile.blueTag);
            //     BlueTile.blueTag++;
            // }

            // else
            // {
            //     _deflate(typeof(RedTile), P, B, C, false, "rightKite", redTag);
            //     redTag++;
            //     Debug.Log("doing this mirror one");
            //     _deflate(typeof(RedTile), Q, P, C, true, "leftKite", redTag);
            //     redTag++;
            //     _deflate(typeof(BlueTile), A, P, Q, false, "leftDart", BlueTile.blueTag);
            //     BlueTile.blueTag++;
            // }
        }
    }   

    public override int tagNo()
    {
        return redTag;
    }
}

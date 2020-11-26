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
        Vector3 A = vertex3 * HelperFunctionsClass.GOLDENRATIO;
        Vector3 B = vertex1 * HelperFunctionsClass.GOLDENRATIO; 
        Vector3 C = vertex2 * HelperFunctionsClass.GOLDENRATIO;


        if(typeOfTiling == "P3")
        {
            // // for tests
            // A += new Vector3(1, 0);
            // B += new Vector3(1, 0);
            // C += new Vector3(1, 0);

            Vector3 P = A + (B - A) / HelperFunctionsClass.GOLDENRATIO;

            if(mirrored)
            {
                // Initalise new tile with the required verticies and give it a matchingCase so the user can add to pattern after deflation 

                _deflate("thinRhomb", B, P, C, true, "bottomThin", redTag);
                redTag++;
                _deflate("thickRhomb", A, C, P,true, "rightThick", BlueTile.blueTag);
                BlueTile.blueTag++;
            }

  

            else
            {
                _deflate("thinRhomb", P, B, C, false, "topThin", redTag);
                redTag++;
                _deflate("thickRhomb", C, A, P, false, "leftThick", BlueTile.blueTag);
                BlueTile.blueTag++;
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

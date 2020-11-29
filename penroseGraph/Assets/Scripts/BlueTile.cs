using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using HelperFunctions;
using System.Text.RegularExpressions;

public class BlueTile : RobTriangle
{   
    public static int blueTag = 0;


    public override void deflate()
    {   
        // Difficulty is to not have doublings from two adjacent tiles

        Vector3 C = vertices[1] * HelperFunctionsClass.GOLDENRATIO;
        Vector3 B = vertices[0] * HelperFunctionsClass.GOLDENRATIO; 
        Vector3 A = vertices[2] * HelperFunctionsClass.GOLDENRATIO;


        if(typeOfTiling == "P3")
        {

            Vector3 Q = B + (A - B) / HelperFunctionsClass.GOLDENRATIO;
            Vector3 R = B + (C - B) / HelperFunctionsClass.GOLDENRATIO;

            if(mirrored)
            {
                _deflate("thickRhomb", R, B, Q, false, "thickRhomb", blueTag, tileRotation);
                _deflate("thickRhomb", Q, A, R, false, "thinRhomb", RedTile.redTag, tileRotation - 126);
                _deflate("thickRhomb", A, C, R, true, "thickRhomb", blueTag, tileRotation + 36f);
            }

            else
            {
                _deflate("thickRhomb", B, R, Q, true, "thickRhomb", blueTag, tileRotation);
                _deflate("thickRhomb", A, Q, R, true, "thinRhomb", RedTile.redTag, tileRotation - 54);
                _deflate("thickRhomb", C, A, R, false, "thickRhomb", blueTag, tileRotation - 36f);
            }
        }

        else if(typeOfTiling == "Dart" || typeOfTiling == "Kite")
        {

            // // for tests
            // A += new Vector3(1, 0);
            // B += new Vector3(1, 0);
            // C += new Vector3(1, 0);

            // Vector3 P = B + (C - B) / HelperFunctionsClass.GOLDENRATIO;

            // if(mirrored)
            // {
            //     _deflate("thinRhomb", A, P, B, false, "rightKite", RedTile.redTag);
            //     RedTile.redTag++;
            //     _deflate("thickRhomb", A, C, P, true, "rightDart", blueTag);
            //     blueTag++;
            // }
            
            // else
            // {
            //     _deflate("thinRhomb", P, A, B, true, "leftKite", RedTile.redTag);
            //     RedTile.redTag++;
            //     _deflate("thickRhomb", C, A, P, false, "leftDart", blueTag);
            //     blueTag++;
            // }
        }



    }

    public override int tagNo()
    {
        return blueTag;
    }

    void OnCollisionEnter(Collision colision)
    {
        Debug.Log("I am being hit");
    }
}

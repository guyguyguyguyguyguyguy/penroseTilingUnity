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


        // string typeOfTiling = Regex.Match(name, @"([A-Z]\w+)").Groups[0].Value;
        Vector3 C = vertex2 * HelperFunctionsClass.GOLDENRATIO;
        Vector3 B = vertex1 * HelperFunctionsClass.GOLDENRATIO; 
        Vector3 A = vertex3 * HelperFunctionsClass.GOLDENRATIO;


        if(typeOfTiling == "P3")
        {
            // // for tests
            // A += new Vector3(1, 0);
            // B += new Vector3(1, 0);
            // C += new Vector3(1, 0);

            Vector3 Q = B + (A - B) / HelperFunctionsClass.GOLDENRATIO;
            Vector3 R = B + (C - B) / HelperFunctionsClass.GOLDENRATIO;

            if(mirrored)
            {
                _deflate("thickRhomb", R, B, Q, false, "leftThick", blueTag);
                blueTag++;
                _deflate("ThinRhomb", Q, A, R, false, "topThin", RedTile.redTag);
                RedTile.redTag++;
                _deflate("thickRhomb", A, C, R, true, "rightThick", blueTag);
                blueTag++;
            }

            else
            {
                _deflate("thickRhomb", B, R, Q, true, "rightThick", blueTag);
                blueTag++;
                _deflate("thinRhomb", A, Q, R, true, "bottomThin", RedTile.redTag);
                RedTile.redTag++;
                _deflate("thickRhomb", C, A, R, false, "leftThick", blueTag);
                blueTag++;
            }
        }

        else if(typeOfTiling == "Dart" || typeOfTiling == "Kite")
        {

            // // for tests
            // A += new Vector3(1, 0);
            // B += new Vector3(1, 0);
            // C += new Vector3(1, 0);

            Vector3 P = B + (C - B) / HelperFunctionsClass.GOLDENRATIO;

            if(mirrored)
            {
                _deflate("thinRhomb", A, P, B, false, "rightKite", RedTile.redTag);
                RedTile.redTag++;
                _deflate("thickRhomb", A, C, P, true, "rightDart", blueTag);
                blueTag++;
            }
            
            else
            {
                _deflate("thinRhomb", P, A, B, true, "leftKite", RedTile.redTag);
                RedTile.redTag++;
                _deflate("thickRhomb", C, A, P, false, "leftDart", blueTag);
                blueTag++;
            }
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

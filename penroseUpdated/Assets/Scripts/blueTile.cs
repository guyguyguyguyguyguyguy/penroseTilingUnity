using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using helperFunctions;
using System.Text.RegularExpressions;

public class blueTile : robTriangle
{   
    public static int blueTag = 0;

    protected override void Start()
    {   
        typeOfTiling = Regex.Match(name, @"([A-Z]\w+)").Groups[0].Value;

        if(typeOfTiling == "Thin" || typeOfTiling == "Thick")
        {
            _drawLine(worldVertex1, worldVertex3, Color.black, "leftLine");
            _drawLine(worldVertex2, worldVertex3, Color.black, "rightLine");
        }
        else if(typeOfTiling == "Kite" || typeOfTiling == "Dart")
        {
            _drawLine(worldVertex1, worldVertex2, Color.black, "baseLine");
            _drawLine(worldVertex2, worldVertex3, Color.black, "rightLine");
        }

    }


    protected override void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            deflate();

            Destroy(gameObject);
            Destroy(outlineL);
            Destroy(outlineR);

            // manager.allObjects.Remove(this);
        }
    }

    public override void deflate()
    {   
        // string typeOfTiling = Regex.Match(name, @"([A-Z]\w+)").Groups[0].Value;
        Vector3 C = worldVertex2 * helperFunctionsClass.GOLDENRATIO;
        Vector3 B = worldVertex1 * helperFunctionsClass.GOLDENRATIO; 
        Vector3 A = worldVertex3 * helperFunctionsClass.GOLDENRATIO;


        if(typeOfTiling == "Thick" || typeOfTiling == "Thin")
        {
            // // for tests
            // A += new Vector3(1, 0);
            // B += new Vector3(1, 0);
            // C += new Vector3(1, 0);

            Vector3 Q = B + (A - B) / helperFunctionsClass.GOLDENRATIO;
            Vector3 R = B + (C - B) / helperFunctionsClass.GOLDENRATIO;

            if(mirrored)
            {
                _deflate(typeof(blueTile), R, B, Q, false, "leftThick", blueTag);
                blueTag++;
                _deflate(typeof(redTile), Q, A, R, false, "topThin", redTile.redTag);
                redTile.redTag++;
                _deflate(typeof(blueTile), A, C, R, true, "rightThick", blueTag);
                blueTag++;
            }

            else
            {
                _deflate(typeof(blueTile), B, R, Q, true, "rightThick", blueTag);
                blueTag++;
                _deflate(typeof(redTile), A, Q, R, true, "bottomThin", redTile.redTag);
                redTile.redTag++;
                _deflate(typeof(blueTile), C, A, R, false, "leftThick", blueTag);
                blueTag++;
            }
        }

        else if(typeOfTiling == "Dart" || typeOfTiling == "Kite")
        {

            // // for tests
            // A += new Vector3(1, 0);
            // B += new Vector3(1, 0);
            // C += new Vector3(1, 0);

            Vector3 P = B + (C - B) / helperFunctionsClass.GOLDENRATIO;

            if(mirrored)
            {
                _deflate(typeof(redTile), A, P, B, false, "rightKite", redTile.redTag);
                redTile.redTag++;
                _deflate(typeof(blueTile), A, C, P, true, "RightDart", blueTag);
                blueTag++;
            }
            
            else
            {
                _deflate(typeof(redTile), P, A, B, true, "leftKite", redTile.redTag);
                redTile.redTag++;
                _deflate(typeof(blueTile), C, A, P, false, "leftDart", blueTag);
                blueTag++;
            }
        }



    }

    public override int tagNo()
    {
        return blueTag;
    }
}

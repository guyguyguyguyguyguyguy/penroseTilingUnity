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
        _drawLine(worldVertex1, worldVertex3, Color.black, "leftLine");
        _drawLine(worldVertex2, worldVertex3, Color.black, "rightLine");
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
        string typeOfTiling = Regex.Match(name, @"([A-Z]\w+)").Groups[0].Value;
        Vector3 C = worldVertex2 * helperFunctionsClass.GOLDENRATIO;
        Vector3 B = worldVertex1 * helperFunctionsClass.GOLDENRATIO; 
        Vector3 A = worldVertex3 * helperFunctionsClass.GOLDENRATIO;


        if(typeOfTiling == "Thick" || typeOfTiling == "Thin")
        {
            // for tests
            A += new Vector3(1, 0);
            B += new Vector3(1, 0);
            C += new Vector3(1, 0);

            Vector3 Q = B + (A - B) / helperFunctionsClass.GOLDENRATIO;
            Vector3 R = B + (C - B) / helperFunctionsClass.GOLDENRATIO;

            if(mirror)
            {
                _deflate(typeof(blueTile), R, B, Q, false, "deflatedThick", blueTag);
                blueTag++;
                _deflate(typeof(redTile), Q, A, R, false, "deflatedThick", redTile.redTag);
                redTile.redTag++;
                _deflate(typeof(blueTile), C, A, R, true, "deflatedThick", blueTag);
                blueTag++;
            }

            else
            {
                _deflate(typeof(blueTile), R, B, Q, true, "deflatedThick", blueTag);
                blueTag++;
                _deflate(typeof(redTile), Q, A, R, true, "deflatedThick", redTile.redTag);
                redTile.redTag++;
                _deflate(typeof(blueTile), C, A, R, false, "deflatedThick", blueTag);
                blueTag++;
            }
        }

        else if(typeOfTiling == "Dart" || typeOfTiling == "Kite")
        {

            // for tests
            A += new Vector3(1, 0);
            B += new Vector3(1, 0);
            C += new Vector3(1, 0);

            Vector3 P = B + (C - B) / helperFunctionsClass.GOLDENRATIO;

            if(mirror)
            {
                _deflate(typeof(redTile), A, P, B, false, "deflatedDart", redTile.redTag);
                _deflate(typeof(blueTile), A, C, P, false, "deflatedDart", blueTag);
            }
            
            else
            {
                _deflate(typeof(redTile), A, P, B, true, "deflatedDart", redTile.redTag);
                _deflate(typeof(blueTile), A, C, P, true, "deflatedDart", blueTag);
            }
        }



    }

    public override int tagNo()
    {
        return blueTag;
    }
}

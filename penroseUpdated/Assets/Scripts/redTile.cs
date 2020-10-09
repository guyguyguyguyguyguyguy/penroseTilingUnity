using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using helperFunctions;
using System.Text.RegularExpressions;

public class redTile : robTriangle
{   
    public static int redTag = 0;

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
            redTag--;

            manager.allObjects.Remove(this);
        }
    }

    public override void deflate()
    {   
        string typeOfTiling = Regex.Match(name, @"([A-Z]\w+)").Groups[0].Value;
        Vector3 A = worldVertex3 * helperFunctionsClass.GOLDENRATIO;
        Vector3 B = worldVertex1 * helperFunctionsClass.GOLDENRATIO; 
        Vector3 C = worldVertex2 * helperFunctionsClass.GOLDENRATIO;


        if(typeOfTiling == "Thin" || typeOfTiling == "Thick")
        {
            // for tests
            A += new Vector3(1, 0);
            B += new Vector3(1, 0);
            C += new Vector3(1, 0);

            Vector3 P = A + (B - A) / helperFunctionsClass.GOLDENRATIO;

            if(mirror)
            {
                _deflate(typeof(redTile), P, B, C, true, "deflatedKite", redTag);
                redTag++;
                _deflate(typeof(blueTile), C, A, P,true, "deflatedKite", blueTile.blueTag);
                blueTile.blueTag++;
            }

            else
            {
                _deflate(typeof(redTile), P, B, C, false, "deflatedKite", redTag);
                redTag++;
                _deflate(typeof(blueTile), C, A, P, false, "deflatedKite", blueTile.blueTag);
                blueTile.blueTag++;
            }
        }
        
        else if(typeOfTiling == "Kite" || typeOfTiling == "Dart")
        {
            // for tests
            A += new Vector3(1, 0);
            B += new Vector3(1, 0);
            C += new Vector3(1, 0);

            Vector3 P = A + (B -A) / helperFunctionsClass.GOLDENRATIO;
            Vector3 Q = C + (A - C) / helperFunctionsClass.GOLDENRATIO;

            if(mirror)
            {
                _deflate(typeof(redTile), P, B, C, true, "deflatedKite", redTag);
                _deflate(typeof(redTile), P, Q, C, false, "deflatedKite", redTag);
                _deflate(typeof(blueTile), A, P, Q, true, "deflatedKite", blueTile.blueTag);
            }

            else
            {
                _deflate(typeof(redTile), P, B, C, false, "deflatedKite", redTag);
                _deflate(typeof(redTile), P, Q, C, true, "deflatedKite", redTag);
                _deflate(typeof(blueTile), A, P, Q, false, "deflatedKite", blueTile.blueTag);
            }
        }



    }

    public override int tagNo()
    {
        return redTag;
    }
}

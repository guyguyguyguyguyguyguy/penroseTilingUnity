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
        Vector3 A = worldVertex3 * helperFunctionsClass.GOLDENRATIO;
        Vector3 B = worldVertex1 * helperFunctionsClass.GOLDENRATIO; 
        Vector3 C = worldVertex2 * helperFunctionsClass.GOLDENRATIO;


        if(typeOfTiling == "Thin" || typeOfTiling == "Thick")
        {
            // // for tests
            // A += new Vector3(1, 0);
            // B += new Vector3(1, 0);
            // C += new Vector3(1, 0);

            Vector3 P = A + (B - A) / helperFunctionsClass.GOLDENRATIO;

            float rotate1;
            float rotate2;

            int matchingCase1;
            int matchingCase2;

            thickRhomb newTile1 = new thickRhomb();  
            thinRhomb newTile2 = new thinRhomb();

            if(mirrored)
            {
                // Initalise new tile with the required verticies and give it a matchingCase so the user can add to pattern after deflation 

                // _deflate(typeof(redTile), B, P, C, true, "bottomThin", redTag);
                // redTag++;
                // _deflate(typeof(blueTile), A, C, P,true, "rightThick", blueTile.blueTag);
                // blueTile.blueTag++;

                Vector3 ver4 = helperFunctionsClass.fourthVer(C, B, P);
                Vector3 ver5 = helperFunctionsClass.fourthVer(P, C, A);

                switch(matchingCase)
                {
                    case 1:
                        
                        rotate1 = tileRotation - 144;
                        rotate2 = tileRotation - 180;

                        matchingCase1 = 1;
                        matchingCase2 = 1;

                    break;

                    case 2:
                        
                        rotate1 = tileRotation - 72;
                        rotate2 = tileRotation + 108;

                        matchingCase1 = 2;
                        matchingCase2 = 2;

                    break;

                    case 3:
                        
                        rotate1 = tileRotation - 144;
                        rotate2 = tileRotation + 108;

                        matchingCase1 = 3;
                        matchingCase2 = 3;

                    break;

                    case 4:
                        
                        rotate1 = tileRotation - 72;
                        rotate2 = tileRotation + 108;

                        matchingCase1 = 4;
                        matchingCase2 = 4;

                    break;

                    default:
                        
                        rotate1 = tileRotation + 180;
                        rotate2 = tileRotation + 108;

                        matchingCase1 = 5;
                        matchingCase2 = 1;

                    break;
                }

                newTile1.InitUser(A, C, P, ver5, rotate1, matchingCase1);
                newTile2.InitUser(B, P, C, ver4, rotate2, matchingCase2);
            }

            else
            {
                // _deflate(typeof(redTile), P, B, C, false, "topThin", redTag);
                // redTag++;
                // _deflate(typeof(blueTile), C, A, P, false, "leftThick", blueTile.blueTag);
                // blueTile.blueTag++;

                Vector3 ver4 = helperFunctionsClass.fourthVer(C, P, B);
                Vector3 ver5 = helperFunctionsClass.fourthVer(P, A, C);

                switch(matchingCase)
                {
                    case 1:
                        
                        rotate1 = tileRotation + 72;
                        rotate2 = tileRotation - 108;

                        matchingCase1 = 1;
                        matchingCase2 = 1;

                    break;

                    case 2:
                        
                        rotate1 = tileRotation + 144;
                        rotate2 = tileRotation - 108;

                        matchingCase1 = 2;
                        matchingCase2 = 2;

                    break;

                    case 3:

                        rotate1 = tileRotation + 72;
                        rotate2 = tileRotation - 108;

                        matchingCase1 = 3;
                        matchingCase2 = 3;

                    break;

                    case 4:

                        rotate1 = tileRotation + 144;
                        rotate2 = tileRotation - 108;

                        matchingCase1 = 4;
                        matchingCase2 = 4;

                    break;

                    default:
                        
                        rotate1 = tileRotation - 36;
                        rotate2 = tileRotation - 36;

                        matchingCase1 = 3;
                        matchingCase2 = 5;
                        
                    break;
                }

                newTile1.InitUser(A, C, ver5, P, rotate1, matchingCase1);
                newTile2.InitUser(B, P, ver4, C, rotate2, matchingCase2);
            }
        }
        
        else if(typeOfTiling == "Kite" || typeOfTiling == "Dart")
        {
            // // for tests
            // A += new Vector3(1, 0);
            // B += new Vector3(1, 0);
            // C += new Vector3(1, 0);

            Vector3 P = A + (B -A) / helperFunctionsClass.GOLDENRATIO;
            Vector3 Q = C + (A - C) / helperFunctionsClass.GOLDENRATIO;

            if(mirrored)
            {
                _deflate(typeof(redTile), B, P, C, true, "leftKite", redTag);
                redTag++;
                Debug.Log("doing this non-mirror one");
                _deflate(typeof(redTile), P, Q, C, false, "rightKite", redTag); 
                redTag++;
                _deflate(typeof(blueTile), P, A, Q, true, "rightDart", blueTile.blueTag);
                blueTile.blueTag++;
            }

            else
            {
                _deflate(typeof(redTile), P, B, C, false, "rightKite", redTag);
                redTag++;
                Debug.Log("doing this mirror one");
                _deflate(typeof(redTile), Q, P, C, true, "leftKite", redTag);
                redTag++;
                _deflate(typeof(blueTile), A, P, Q, false, "leftDart", blueTile.blueTag);
                blueTile.blueTag++;
            }
        }
    }

    public override int tagNo()
    {
        return redTag;
    }
}

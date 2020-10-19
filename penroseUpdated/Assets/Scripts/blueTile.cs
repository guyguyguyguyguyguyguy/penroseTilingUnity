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

            float rotate1;
            float rotate2;
            float rotate3;

            int matchingCase1;
            int matchingCase2;
            int matchingCase3;

            thickRhomb newTile1 = new thickRhomb();  
            thickRhomb newTile2 = new thickRhomb();
            thinRhomb newTile3 = new thinRhomb();

            if(mirrored)
            {
                // _deflate(typeof(blueTile), R, B, Q, false, "leftThick", blueTag);
                // blueTag++;
                // _deflate(typeof(redTile), Q, A, R, false, "topThin", redTile.redTag);
                // redTile.redTag++;
                // _deflate(typeof(blueTile), A, C, R, true, "rightThick", blueTag);
                // blueTag++;

                Vector3 ver4 = helperFunctionsClass.fourthVer(Q, B, R);
                Vector3 ver5 = helperFunctionsClass.fourthVer(R, A, Q);
                Vector3 ver6 = helperFunctionsClass.fourthVer(R, A, C);


                // Sort this angle and matching case

                switch(matchingCase)
                {
                    case 1:
                        
                        rotate1 = tileRotation + 180;
                        rotate2 = tileRotation - 180;
                        rotate3 = tileRotation ;

                        matchingCase1 = 1;
                        matchingCase2 = 5;
                        matchingCase3 = 1;

                    break;

                    case 2:
                        
                        rotate1 = tileRotation - 180;
                        rotate2 = tileRotation + 72;
                        rotate3 = tileRotation - 72;

                        matchingCase1 = 2;
                        matchingCase2 = 5;
                        matchingCase3 = 2;

                    break;

                    case 3:
                        
                        rotate1 = tileRotation - 180;
                        rotate2 = tileRotation;
                        rotate3 = tileRotation;

                        matchingCase1 = 3;
                        matchingCase2 = 5;
                        matchingCase3 = 3;

                    break;

                    case 4:
                        
                        rotate1 = tileRotation - 180;
                        rotate2 = tileRotation - 108;
                        rotate3 = tileRotation -72;

                        matchingCase1 = 4;
                        matchingCase2 = 5;
                        matchingCase3 = 4;

                    break;

                    default:
                        
                        rotate1 = tileRotation + 180;
                        rotate2 = tileRotation;
                        rotate3 = tileRotation + 36;

                        matchingCase1 = 5;
                        matchingCase2 = 2;
                        matchingCase3 = 1;

                    break;
                }

                newTile1.InitUser(B, R, ver4, Q, rotate1, matchingCase1);
                newTile2.InitUser(A, C, R, ver6, rotate2 , matchingCase2);
                newTile3.InitUser(A, Q, ver5, R, rotate3, matchingCase3);

            }

            else
            {
                // _deflate(typeof(blueTile), B, R, Q, true, "rightThick", blueTag);
                // blueTag++;
                // _deflate(typeof(redTile), A, Q, R, true, "bottomThin", redTile.redTag);
                // redTile.redTag++;
                // _deflate(typeof(blueTile), C, A, R, false, "leftThick", blueTag);
                // blueTag++;

                Vector3 ver4 = helperFunctionsClass.fourthVer(Q, B, R);
                Vector3 ver5 = helperFunctionsClass.fourthVer(R, A, Q);
                Vector3 ver6 = helperFunctionsClass.fourthVer(R, A, C);

                switch(matchingCase)
                {
                    case 1:
                        
                        rotate1 = tileRotation + 180;
                        rotate2 = tileRotation + 108;
                        rotate3 = tileRotation +72;

                        matchingCase1 = 1;
                        matchingCase2 = 5;
                        matchingCase3 = 1;

                    break;

                    case 2:
                        
                        rotate1 = tileRotation - 180;
                        rotate2 = tileRotation ;
                        rotate3 = tileRotation ;

                        matchingCase1 = 2;
                        matchingCase2 = 5;
                        matchingCase3 = 2;

                    break;

                    case 3:

                        rotate1 = tileRotation + 180;
                        rotate2 = tileRotation - 72;
                        rotate3 = tileRotation + 72;

                        matchingCase1 = 3;
                        matchingCase2 = 5;
                        matchingCase3 = 3;

                    break;

                    case 4:

                        rotate1 = tileRotation + 180;
                        rotate2 = tileRotation - 180;
                        rotate3 = tileRotation ;

                        matchingCase1 = 4;
                        matchingCase2 = 5;
                        matchingCase3 = 4;

                    break;

                    default:
                        
                        rotate1 = tileRotation + 180;
                        rotate2 = tileRotation - 180;
                        rotate3 = tileRotation -72;

                        matchingCase1 = 5;
                        matchingCase2 = 1;
                        matchingCase3 = 3;
                        
                    break;
                }
                
                newTile1.InitUser(B, R, Q, ver4, rotate1, matchingCase1);
                newTile2.InitUser(A, C, ver6, R, rotate2, matchingCase2);
                newTile3.InitUser(A, Q, R, ver5, rotate3, matchingCase3);
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
                _deflate(typeof(blueTile), A, C, P, true, "rightDart", blueTag);
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

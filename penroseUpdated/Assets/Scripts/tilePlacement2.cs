using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using helperFunctions;


namespace tilePlacement
{    
    public class tilePlacement2 : MonoBehaviour
    {

        Action<string, tile, int, Vector3[]> updateMethod;

        void Start()
        {

            Debug.Log(manager.tileType);

            if(manager.tileType == "P2")
            {
                updateMethod = P2TilePlacement;

            }   

            else if(manager.tileType == "P3")
            {
                updateMethod = P3TilePlacement;
            }
        }


        void Update()
        {
            if((manager.allObjects.Count != 0))
            {
                if (Input.GetMouseButtonDown(0)) 
                {  
                    Vector3 mouseClickCoor =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    var closestTile = getClosestTile(manager.allObjects, mouseClickCoor);

                    if(closestTile.Item2 < 0.9)
                    {   
                        updateMethod("left", closestTile.Item1, closestTile.Item3, closestTile.Item4);
                    }

                    else
                    {
                        if (manager.tileType == "P3")
                        {
                            thinRhomb newTile = new thinRhomb();
                            newTile.Init(mouseClickCoor);
                        }
                        
                        else if (manager.tileType == "P2")
                        {
                            kiteTile newTile = new kiteTile();
                            newTile.Init(mouseClickCoor);
                        }
                    }
                }


                else if(Input.GetMouseButtonDown(1))
                {
                    Vector3 mouseClickCoor =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    var closestTile = getClosestTile(manager.allObjects, mouseClickCoor);

                    if(closestTile.Item2 < 0.9)
                    {
                        updateMethod("right", closestTile.Item1, closestTile.Item3, closestTile.Item4);
                    }

                    else
                    {
                        if (manager.tileType == "P3")
                        {
                            thickRhomb newTile = new thickRhomb();
                            newTile.Init(mouseClickCoor);
                        }
                        
                        else if (manager.tileType == "P2")
                        {
                            dartTile newTile = new dartTile();
                            newTile.Init(mouseClickCoor);
                        }
                    }
                }
            }
            
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 mouseClickCoor =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
                
                    if (manager.tileType == "P3")
                    {
                        thinRhomb newTile = new thinRhomb();
                        newTile.Init(mouseClickCoor);
                    }
                    
                    else if (manager.tileType == "P2")
                    {
                        kiteTile newTile = new kiteTile();
                        newTile.Init(mouseClickCoor);
                    }
                }

                else if (Input.GetMouseButtonDown(1))
                {
                    Vector3 mouseClickCoor =  Camera.main.ScreenToWorldPoint(Input.mousePosition);

                    if (manager.tileType == "P3")
                    {
                        thickRhomb newTile = new thickRhomb();
                        newTile.Init(mouseClickCoor);
                    }
                    
                    else if (manager.tileType == "P2")
                    {
                        dartTile newTile = new dartTile();
                        newTile.Init(mouseClickCoor);
                    }
                }
            }
        }


        public static void P2TilePlacement(string mouseClick, tile closestTile, int closestEdge, Vector3[] closestEdgeVec)
        {

            if(mouseClick == "left")
            {

            }

            else if(mouseClick == "right")
            {

            }
        }


        public static void P3TilePlacement(string mouseClick, tile closestTile, int closestEdge, Vector3[] closestEdgeVec)
        {

            if(mouseClick == "left")
            {   
                addThinRhomb(closestTile.name, closestEdge, closestEdgeVec, closestTile.rotation, closestTile.matchingCase, closestTile);
            }

            else if(mouseClick == "right")
            {
                addThickRhomb(closestTile.name, closestEdge, closestEdgeVec, closestTile.rotation, closestTile.matchingCase, closestTile);
            }
        }
        

        static void addThinRhomb(string tileType, int closestEdge, Vector3[] closestEdgeVec, float currentRotation, int previousCase, tile closestTile)
        {
            thinRhomb newTile = new thinRhomb();

            Vector3 ver1;
            Vector3 ver2;
            Vector3 ver3;
            Vector3 ver4;

            float rotation;
            // Debug.Log(closestEdge);


        if(tileType == "thinRhomb")
        {
            switch(closestEdge)
            {    
                    case 1:
                    
                        ver1 = closestEdgeVec[0];
                        ver4 = closestEdgeVec[1];

                        if(previousCase == 1)
                        {
                            rotation = currentRotation + 144;
                        }

                        else if(previousCase == 2)
                        {
                            rotation = currentRotation + 108;
                        }
                        
                        else if (previousCase == 3)
                        {
                            rotation = currentRotation + 324;
                        }

                        else if (previousCase == 4)
                        {
                            rotation = currentRotation - 72;
                        }

                        else
                        {
                            rotation = currentRotation + 144;
                        }


                        ver3 = helperFunctionsClass.thirdVer(ver1, rotation, helperFunctionsClass.redSides);
                        
                        ver2 = helperFunctionsClass.fourthVer(ver1, ver3, ver4);

                        newTile.InitUser(ver1, ver2, ver3, ver4, rotation, closestEdge);

                        break;

                    case 2:

                        ver2 = closestEdgeVec[1];
                        ver4 = closestEdgeVec[0];

                        if (previousCase == 1)
                        {
                            rotation = currentRotation - 108; 
                            
                        }

                        else if (previousCase == 2)
                        {
                            rotation = currentRotation - 144;
                        }

                        else if (previousCase == 3)
                        {
                            rotation = currentRotation + 72;
                        }

                        else if (previousCase == 4)
                        {
                            rotation = currentRotation + 36;
                        }

                        else
                        {
                            rotation = currentRotation - 108;
                        }

                        ver3 = helperFunctionsClass.thirdVer(ver2, rotation, helperFunctionsClass.redSides);
                        
                        ver1 = helperFunctionsClass.fourthVer(ver2, ver3, ver4);

                        newTile.InitUser(ver1, ver2, ver3, ver4, rotation, closestEdge);

                    break;

                    case 3:

                        ver3 = closestEdgeVec[1];
                        ver2 = closestEdgeVec[0];

                        if(previousCase == 1)
                        {
                            rotation = currentRotation + 324;
                        }

                        else if(previousCase == 2)
                        {   
                            rotation = - 108;
                        }
                        else if (previousCase == 3)
                        {
                            rotation = currentRotation + 144;
                        }

                        else if (previousCase == 4)
                        {
                            rotation = currentRotation + 108;
                        }

                        else
                        {
                            rotation = currentRotation + 324; 
                        }
                        

                        ver4 = helperFunctionsClass.thirdVer(ver2, rotation, helperFunctionsClass.redSides);

                        ver1 = helperFunctionsClass.fourthVer(ver2, ver3, ver4);

                        newTile.InitUser(ver1, ver2, ver3, ver4, rotation, closestEdge);

                    break;

                    case 4:

                        if(previousCase == 1)
                        {
                            rotation = currentRotation + 72;
                        }

                        else if(previousCase == 2)
                        {   
                            rotation = currentRotation + 36;
                        }
                        else if (previousCase == 3)
                        {
                            rotation = currentRotation - 108;
                        }

                        else if (previousCase == 4)
                        {
                            rotation = currentRotation -144;
                        }

                        else
                        {
                            rotation = currentRotation + 72; 
                        }

                        ver3 = closestEdgeVec[0];
                        ver1 = closestEdgeVec[1];

                        ver4 = helperFunctionsClass.thirdVer(ver1, rotation, helperFunctionsClass.redSides);

                        ver2 = helperFunctionsClass.fourthVer(ver1, ver3, ver4);

                        newTile.InitUser(ver1, ver2, ver3, ver4, rotation, closestEdge);


                    break;
            }
        }

        else if(tileType == "thickRhomb")
        {
                switch(closestEdge)
            {
                    case 1:

                        ver1 = closestEdgeVec[0];
                        ver4 = closestEdgeVec[1];

                        if(previousCase == 1)
                        {
                            rotation = currentRotation + 144;
                        }

                        else if(previousCase == 2)
                        {
                            rotation = currentRotation + 36;
                        }
                        
                        else if (previousCase == 3)
                        {
                            rotation = currentRotation + 324;
                        }

                        else if (previousCase == 4)
                        {
                            rotation = currentRotation - 144;
                        }

                        else
                        {
                            rotation = currentRotation + 180;
                        }


                        ver3 = helperFunctionsClass.thirdVer(ver1, rotation, helperFunctionsClass.redSides);
                        
                        ver2 = helperFunctionsClass.fourthVer(ver1, ver3, ver4);

                        newTile.InitUser(ver1, ver2, ver3, ver4, rotation, closestEdge);

                    break;

                    case 2:

                        ver2 = closestEdgeVec[0];
                        ver3 = closestEdgeVec[1];

                        if(previousCase == 1)
                        {
                            rotation = currentRotation + 72;
                        }

                        else if(previousCase == 2)
                        {
                            rotation = currentRotation -36;
                        }
                        
                        else if (previousCase == 3)
                        {
                            rotation = currentRotation - 108;
                        }

                        else if (previousCase == 4)
                        {
                            rotation = currentRotation - 216;
                        }

                        else
                        {
                            rotation = currentRotation + 108;
                        }


                        ver4 = helperFunctionsClass.thirdVer(ver2, rotation, helperFunctionsClass.redSides);
                        
                        ver1 = helperFunctionsClass.fourthVer(ver2, ver3, ver4);

                        newTile.InitUser(ver1, ver2, ver3, ver4, rotation, 3);

                    break;

                    case 3:

                        ver4 = closestEdgeVec[0];
                        ver2 = closestEdgeVec[1];

                        if(previousCase == 1)
                        {
                            rotation = currentRotation - 144;
                        }

                        else if(previousCase == 2)
                        {
                            rotation = currentRotation + 108;
                        }
                        
                        else if (previousCase == 3)
                        {
                            rotation = currentRotation + 36;
                        }

                        else if (previousCase == 4)
                        {
                            rotation = currentRotation - 72;
                        }

                        else
                        {
                            rotation = currentRotation - 108;
                        }


                        ver3 = helperFunctionsClass.thirdVer(ver2, rotation, helperFunctionsClass.redSides);
                        
                        ver1 = helperFunctionsClass.fourthVer(ver2, ver3, ver4);

                        newTile.InitUser(ver1, ver2, ver3, ver4, rotation, 2);

                    break;

                    case 4:

                        ver3 = closestEdgeVec[0];
                        ver1 = closestEdgeVec[1];

                        if(previousCase == 1)
                        {
                            rotation = currentRotation + 144;
                        }

                        else if(previousCase == 2)
                        {
                            rotation = currentRotation + 36;
                        }
                        
                        else if (previousCase == 3)
                        {
                            rotation = currentRotation -36;
                        }

                        else if (previousCase == 4)
                        {
                            rotation = currentRotation - 144;
                        }

                        else
                        {
                            rotation = currentRotation - 180;
                        }


                        ver4 = helperFunctionsClass.thirdVer(ver1, rotation, helperFunctionsClass.redSides);
                        
                        ver2 = helperFunctionsClass.fourthVer(ver1, ver3, ver4);

                        newTile.InitUser(ver1, ver2, ver3, ver4, rotation, 4);
                    break;
            }
        }

        closestTile.neighbours[closestEdge-1] = newTile;

    }


        static void addThickRhomb(string tileType, int closestEdge, Vector3[] closestEdgeVec, float currentRotation, int previousCase, tile closestTile)
        {
            thickRhomb newTile = new thickRhomb();

            Vector3 ver1;
            Vector3 ver2;
            Vector3 ver3;
            Vector3 ver4;

            float rotation;
            // Debug.Log(closestEdge);

            if(tileType == "thinRhomb")
        {
            switch(closestEdge)
            {
                    case 1:

                        ver1 = closestEdgeVec[0];
                        ver4 = closestEdgeVec[1];
                        
                        if (previousCase == 1)
                        {
                            rotation = currentRotation + 72;
                        }

                        else if (previousCase == 2)
                        {
                            rotation = currentRotation + 36 ;
                        }

                        else if (previousCase == 3)
                        {
                            rotation = currentRotation - 108;
                        }
                        
                        else if (previousCase == 4)
                        {
                            rotation = currentRotation - 144;
                        }

                        else
                        {
                            rotation = currentRotation + 72;
                        }

                        ver2 = helperFunctionsClass.thirdVer(ver4, rotation, helperFunctionsClass.redSides);

                        ver3 = helperFunctionsClass.fourthVer(ver4, ver2, ver1);

                        newTile.InitUser(ver1, ver2, ver3, ver4, rotation, closestEdge);

                    break;

                    case 2:

                        ver2 = closestEdgeVec[0];
                        ver3 = closestEdgeVec[1];
                        
                        if (previousCase == 1)
                        {
                            rotation = currentRotation - 72;
                        }

                        else if (previousCase == 2)
                        {
                            rotation = currentRotation - 108;
                        }

                        else if (previousCase == 3)
                        {
                            rotation = currentRotation + 108;
                        }
                        
                        else if (previousCase == 4)
                        {
                            rotation = currentRotation + 72;
                        }

                        else
                        {
                            rotation = currentRotation - 72;
                        }

                        ver1 = helperFunctionsClass.thirdVer(ver3, rotation, helperFunctionsClass.redSides);

                        ver4 = helperFunctionsClass.fourthVer(ver3, ver2, ver1);

                        newTile.InitUser(ver1, ver2, ver3, ver4, rotation, 3);
                        
                    break;

                    case 3:

                        ver4 = closestEdgeVec[0];
                        ver2 = closestEdgeVec[1];
                        
                        if (previousCase == 1)
                        {
                            rotation = currentRotation - 72;
                        }

                        else if (previousCase == 2)
                        {
                            rotation = currentRotation - 108;
                        }

                        else if (previousCase == 3)
                        {
                            rotation = currentRotation + 108;
                        }
                        
                        else if (previousCase == 4)
                        {
                            rotation = currentRotation + 72;
                        }

                        else
                        {
                            rotation = currentRotation - 72;
                        }

                        ver1= helperFunctionsClass.thirdVer(ver4, rotation, helperFunctionsClass.redSides);

                        ver3 = helperFunctionsClass.fourthVer(ver4, ver2, ver1);

                        newTile.InitUser(ver1, ver2, ver3, ver4, rotation, 2);

                    break;

                    case 4:

                        ver3 = closestEdgeVec[0];
                        ver1 = closestEdgeVec[1];
                        
                        if (previousCase == 1)
                        {
                            rotation = currentRotation + 144;
                        }

                        else if (previousCase == 2)
                        {
                            rotation = currentRotation + 108;
                        }

                        else if (previousCase == 3)
                        {
                            rotation = currentRotation - 36;
                        }
                        
                        else if (previousCase == 4)
                        {
                            rotation = currentRotation - 72;
                        }

                        else
                        {
                            rotation = currentRotation + 144;
                        }

                        ver2 = helperFunctionsClass.thirdVer(ver3, rotation, helperFunctionsClass.redSides);

                        ver4 = helperFunctionsClass.fourthVer(ver3, ver2, ver1);

                        newTile.InitUser(ver1, ver2, ver3, ver4, rotation, 4);

                    break;
            }
        }

        else if(tileType == "thickRhomb")
        {
                switch(closestEdge)
            {
                    case 1:

                        ver1 = closestEdgeVec[0];
                        ver4 = closestEdgeVec[1];
                        
                        if (previousCase == 1)
                        {
                            rotation = currentRotation + 72;
                        }

                        else if (previousCase == 2)
                        {
                            rotation = currentRotation -36 ;
                        }

                        else if (previousCase == 3)
                        {
                            rotation = currentRotation - 108;
                        }
                        
                        else if (previousCase == 4)
                        {
                            rotation = currentRotation + 144;
                        }

                        else
                        {
                            rotation = currentRotation + 108;
                        }

                        ver2 = helperFunctionsClass.thirdVer(ver4, rotation, helperFunctionsClass.redSides);

                        ver3 = helperFunctionsClass.fourthVer(ver4, ver2, ver1);

                        newTile.InitUser(ver1, ver2, ver3, ver4, rotation, closestEdge);

                    break;

                    case 2:

                        ver2 = closestEdgeVec[1];
                        ver4 = closestEdgeVec[0];
                        
                        if (previousCase == 1)
                        {
                            rotation = currentRotation +36;
                        }

                        else if (previousCase == 2)
                        {
                            rotation = currentRotation -72;
                        }

                        else if (previousCase == 3)
                        {
                            rotation = currentRotation - 144;
                        }

                        else if (previousCase == 4)
                        {
                            rotation = currentRotation + 108;
                        }

                        else
                        {
                            rotation = currentRotation +72;
                        }

                        ver1 = helperFunctionsClass.thirdVer(ver4, rotation, helperFunctionsClass.redSides);

                        ver3 = helperFunctionsClass.fourthVer(ver4, ver2, ver1);

                        newTile.InitUser(ver1, ver2, ver3, ver4, rotation, closestEdge);

                    break;

                    case 3:

                        ver2 = closestEdgeVec[0];
                        ver3 = closestEdgeVec[1];
                        
                        if (previousCase == 1)
                        {
                            rotation = currentRotation - 108;
                        }

                        else if (previousCase == 2)
                        {
                            rotation = currentRotation + 144;
                        }

                        else if (previousCase == 3)
                        {
                            rotation = currentRotation + 72;
                        }
                        
                        else if (previousCase == 4)
                        {
                            rotation = currentRotation -36;
                        }

                        else
                        {
                            rotation = currentRotation - 72;
                        }

                        ver1 = helperFunctionsClass.thirdVer(ver3, rotation, helperFunctionsClass.redSides);

                        ver4 = helperFunctionsClass.fourthVer(ver3, ver2, ver1);

                        newTile.InitUser(ver1, ver2, ver3, ver4, rotation, closestEdge);
                    break;

                    case 4:

                        ver1 = closestEdgeVec[1];
                        ver3 = closestEdgeVec[0];
                        
                        if (previousCase == 1)
                        {
                            rotation = currentRotation - 144;
                        }

                        else if (previousCase == 2)
                        {
                            rotation = currentRotation + 108;
                        }

                        else if (previousCase == 3)
                        {
                            rotation = currentRotation + 36;
                        }

                        else if (previousCase == 4)
                        {
                            rotation = currentRotation - 72;
                        }

                        else
                        {
                            rotation = currentRotation - 108;
                        }

                        ver2 = helperFunctionsClass.thirdVer(ver3, rotation, helperFunctionsClass.redSides);

                        ver4 = helperFunctionsClass.fourthVer(ver3, ver2, ver1);

                        newTile.InitUser(ver1, ver2, ver3, ver4, rotation, closestEdge);

                    break;  
            }
        }

        closestTile.neighbours[closestEdge-1] = newTile;

    }



        static Tuple<tile, float, int, Vector3[]> getClosestTile(List<tile> tiles, Vector3 mousePos)
        {
            tile closest = null;
            Vector3[] closestEdgeVec = new Vector3[2];
            int closestEdge = 0;
            float minDist = Mathf.Infinity;
            foreach (tile t in tiles)
            {
                float dist = Vector2.Distance(t.centre, mousePos);
                if (dist < minDist)
                {
                    closest = t;
                    minDist = dist;
                }
            }

            float minDistToEdge = Mathf.Infinity;
            for (int i = 0; i < closest.edges.Count; ++i)
            {
                float distToEdge = Vector2.Distance(helperFunctionsClass.edgeCentre(closest.edges[i]), mousePos);

                if(distToEdge < minDistToEdge)
                {
                    minDistToEdge = distToEdge;
                    closestEdgeVec = closest.edges[i];
                    closestEdge = i+1;
                }
            }
            
            return new Tuple< tile, float, int, Vector3[]>(closest, minDist, closestEdge, closestEdgeVec);
        }  
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperFunctions;

public class tile : MonoBehaviour
{
    public Vector3 centre;
    public Vector3[] tileVertices;
    public float rotation;
    public string name;

    protected virtual void Start()
    {
        
    }


    protected virtual void Update()
    {

    }

    protected void createP2Tile(string tileType, Vector3 clickPos, float angle, string name, bool mirror)
    {
        Vector3 ver1 = new Vector3();
        Vector3 ver2 = new Vector3();
        Vector3 ver3 = new Vector3();

        GameObject newTileObj = new GameObject();
        newTileObj.SetActive(false);
        newTileObj.name = name;

        if(tileType == "red")
        {
            redTile newTile = newTileObj.AddComponent<redTile>(); 

            ver1 = clickPos + new Vector3(-(0.5f * helperFunctionsClass.redBase), - helperFunctionsClass.redHieght);
            ver2 = clickPos + new Vector3((0.5f * helperFunctionsClass.redBase), - helperFunctionsClass.redHieght);
            ver3 = clickPos;

            Vector3 rotatedVer1 = helperFunctionsClass.rotatedVector(clickPos, ver1, angle);
            Vector3 rotatedVer2 = helperFunctionsClass.rotatedVector(clickPos, ver2, angle);
            Vector3 rotatedVer3 = helperFunctionsClass.rotatedVector(clickPos, ver3, angle);

            newTile.Init(rotatedVer1, rotatedVer2, rotatedVer3, mirror, redTile.redTag);
            newTileObj.SetActive(true);
            redTile.redTag++;

        }

        else if(tileType == "blue")
        {
            blueTile newTile = newTileObj.AddComponent<blueTile>(); 
            
            ver1 = clickPos + new Vector3(-(0.5f * helperFunctionsClass.blueBase), - helperFunctionsClass.blueHeight);
            ver2 = clickPos + new Vector3((0.5f * helperFunctionsClass.blueBase), - helperFunctionsClass.blueHeight);
            ver3 = clickPos;

            Vector3 rotatedVer1 = helperFunctionsClass.rotatedVector(clickPos, ver1, angle);
            Vector3 rotatedVer2 = helperFunctionsClass.rotatedVector(clickPos, ver2, angle);
            Vector3 rotatedVer3 = helperFunctionsClass.rotatedVector(clickPos, ver3, angle);

            newTile.Init(rotatedVer1, rotatedVer2, rotatedVer3, mirror, blueTile.blueTag);
            newTileObj.SetActive(true);
            blueTile.blueTag++;
        }
    }


    protected void createP3Tile(string tileType, Vector3 clickPos, float angle, string name, bool mirror)
    {
        createP3Tile(tileType, clickPos, angle, 0f, name, mirror, new Vector3(0, 0, -Mathf.PI));
    }


    protected Vector3[] createP3Tile(string tileType, Vector3 clickPos, float angle, float anglePivot, string name, bool mirror, Vector3 pivot)
    {
        Vector3 ver1 = new Vector3();
        Vector3 ver2 = new Vector3();
        Vector3 ver3 = new Vector3();
        
        Vector3 rotatedVer1 = new Vector3();
        Vector3 rotatedVer2 = new Vector3();
        Vector3 rotatedVer3 = new Vector3();

        GameObject newTileObj = new GameObject();
        newTileObj.SetActive(false);
        newTileObj.name = name;

        if(tileType == "red")
        {
            redTile newTile = newTileObj.AddComponent<redTile>(); 

            ver1 = clickPos + new Vector3(- 0.5f * helperFunctionsClass.redBase, 0);
            ver2 = clickPos + new Vector3(0.5f *helperFunctionsClass.redBase, 0);
            ver3 = clickPos + new Vector3(0, helperFunctionsClass.redHieght);

            rotatedVer1 = helperFunctionsClass.rotatedVector(clickPos, ver1, angle);
            rotatedVer2 = helperFunctionsClass.rotatedVector(clickPos, ver2, angle);
            rotatedVer3 = helperFunctionsClass.rotatedVector(clickPos, ver3, angle);


            // var boundedBox = helperFunctionsClass.boundedBoxFunc(helperFunctionsClass.redHieght*2, 54);

            // // Need to sort this, if its on the bottom of the tile its minus, if its on the top its plus


            if(pivot[2] != -Mathf.PI)
            {
                rotatedVer1 = helperFunctionsClass.rotatedVector(pivot, rotatedVer1, anglePivot);
                rotatedVer2 = helperFunctionsClass.rotatedVector(pivot, rotatedVer2, anglePivot);
                rotatedVer3 = helperFunctionsClass.rotatedVector(pivot, rotatedVer3, anglePivot);
            }

            //     if((pivot[1] - rotatedVer1[1]) < 0) 
            //     {
            //         rotatedVer1 -= new Vector3(boundedBox.Item2, boundedBox.Item1);
            //         rotatedVer2 -= new Vector3(boundedBox.Item2, boundedBox.Item1);
            //         rotatedVer3 -= new Vector3(boundedBox.Item2, boundedBox.Item1);
            //     }

            //     else
            //     {
            //         rotatedVer1 -= new Vector3(boundedBox.Item2, - boundedBox.Item1);
            //         rotatedVer2 -= new Vector3(boundedBox.Item2, - boundedBox.Item1);
            //         rotatedVer3 -= new Vector3(boundedBox.Item2, - boundedBox.Item1);
            //     }
            // }

            newTile.Init(rotatedVer1, rotatedVer2, rotatedVer3, mirror, redTile.redTag);
            newTile.centre = clickPos;
            newTileObj.SetActive(true);
            redTile.redTag++;
        }

        else if(tileType == "blue")
        {
            blueTile newTile = newTileObj.AddComponent<blueTile>(); 
            ver1 = clickPos + new Vector3(-(0.5f * helperFunctionsClass.blueBase), 0);
            ver2 = clickPos + new Vector3((0.5f * helperFunctionsClass.blueBase), 0);
            ver3 = clickPos + new Vector3(0, helperFunctionsClass.blueHeight);

            rotatedVer1 = helperFunctionsClass.rotatedVector(clickPos, ver1, angle);
            rotatedVer2 = helperFunctionsClass.rotatedVector(clickPos, ver2, angle);
            rotatedVer3 = helperFunctionsClass.rotatedVector(clickPos, ver3, angle);

            if(pivot[2] != -Mathf.PI)
            {
                rotatedVer1 = helperFunctionsClass.rotatedVector(pivot, rotatedVer1, anglePivot);
                rotatedVer2 = helperFunctionsClass.rotatedVector(pivot, rotatedVer2, anglePivot);
                rotatedVer3 = helperFunctionsClass.rotatedVector(pivot, rotatedVer3, anglePivot);
            }

            // var boundedBox = helperFunctionsClass.boundedBoxFunc(helperFunctionsClass.redHieght*2, 54);

            newTile.Init(rotatedVer1, rotatedVer2, rotatedVer3, mirror, blueTile.blueTag);
            newTile.centre = clickPos;
            newTileObj.SetActive(true);
            blueTile.blueTag++;
        }
    
    return new Vector3[] {rotatedVer1, rotatedVer2, rotatedVer3};
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperFunctions;

public class tile : MonoBehaviour
{
    public Vector3 centre;

    protected virtual void Start()
    {
        
    }


    protected virtual void Update()
    {

    }

    protected void createP2Tile(string tileType, Vector3 clickPos, float angle, string name, bool mirror, bool snap)
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

            newTile.Init(rotatedVer1, rotatedVer2, rotatedVer3, mirror, snap, redTile.redTag);
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

            newTile.Init(rotatedVer1, rotatedVer2, rotatedVer3, mirror, snap, blueTile.blueTag);
            newTileObj.SetActive(true);
            blueTile.blueTag++;
        }
    }

    protected void createP3Tile(string tileType, Vector3 clickPos, float angle, string name, bool mirror, bool snap)
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

            ver1 = clickPos + new Vector3(- 0.5f * helperFunctionsClass.redBase, 0);
            ver2 = clickPos + new Vector3(0.5f *helperFunctionsClass.redBase, 0);
            ver3 = clickPos + new Vector3(0, helperFunctionsClass.redHieght);

            Vector3 rotatedVer1 = helperFunctionsClass.rotatedVector(clickPos, ver1, angle);
            Vector3 rotatedVer2 = helperFunctionsClass.rotatedVector(clickPos, ver2, angle);
            Vector3 rotatedVer3 = helperFunctionsClass.rotatedVector(clickPos, ver3, angle);

            newTile.Init(rotatedVer1, rotatedVer2, rotatedVer3, mirror, snap, redTile.redTag);
            newTileObj.SetActive(true);
            redTile.redTag++;

        }

        else if(tileType == "blue")
        {
            blueTile newTile = newTileObj.AddComponent<blueTile>(); 
            ver1 = clickPos + new Vector3(-(0.5f * helperFunctionsClass.blueBase), 0);
            ver2 = clickPos + new Vector3((0.5f * helperFunctionsClass.blueBase), 0);
            ver3 = clickPos + new Vector3(0, helperFunctionsClass.blueHeight);

            Vector3 rotatedVer1 = helperFunctionsClass.rotatedVector(clickPos, ver1, angle);
            Vector3 rotatedVer2 = helperFunctionsClass.rotatedVector(clickPos, ver2, angle);
            Vector3 rotatedVer3 = helperFunctionsClass.rotatedVector(clickPos, ver3, angle);

            newTile.Init(rotatedVer1, rotatedVer2, rotatedVer3, mirror, snap, blueTile.blueTag);
            newTileObj.SetActive(true);
            blueTile.blueTag++;
        }
    }
}

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

    protected void createTile(string tileType, Vector3 clickPos, float angle, string name)
    {
        createTile(tileType, clickPos, angle, name, 2);
    }
    

    protected void createTile(string tileType, Vector3 clickPos, float angle, string name, int pivot)
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

            Vector3[] vertices = new Vector3[3]{ver1, ver2, ver3};
            Vector3[] rotatedVer = new Vector3[3];
            for(int i =0; i < 3; ++i) 
            {
                if(i != pivot)
                {
                    rotatedVer[i] = helperFunctionsClass.rotatedVector(vertices[pivot], vertices[i], angle);
                }
                else
                {
                    rotatedVer[i] = vertices[i];
                }
            }

            newTile.Init(rotatedVer[0], rotatedVer[1], rotatedVer[2], false, false, redTile.redTag);
            newTileObj.SetActive(true);
            redTile.redTag++;

        }

        else if(tileType == "blue")
        {
            blueTile newTile = newTileObj.AddComponent<blueTile>(); 
            ver1 = clickPos + new Vector3(-(0.5f * helperFunctionsClass.blueBase), - helperFunctionsClass.blueHeight);
            ver2 = clickPos + new Vector3((0.5f * helperFunctionsClass.blueBase), - helperFunctionsClass.blueHeight);
            ver3 = clickPos;
            
            Vector3[] vertices = new Vector3[3]{ver1, ver2, ver3};
            Vector3[] rotatedVer = new Vector3[3];
            for(int i =0; i < 3; ++i) 
            {
                if(i != pivot)
                {
                    rotatedVer[i] = helperFunctionsClass.rotatedVector(vertices[pivot], vertices[i], angle);
                }
                else
                {
                    rotatedVer[i] = vertices[i];
                }
            }

            newTile.Init(rotatedVer[0], rotatedVer[1], rotatedVer[2], false, false, blueTile.blueTag);
            newTileObj.SetActive(true);
            blueTile.blueTag++;
        }
    }
}

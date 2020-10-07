using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperFunctions;

public class thickRhomb : tile
{

    public void Init(Vector3 clickPos)
    {
        centre = clickPos;

        // createTile("blue", clickPos, )

        GameObject leftTileObj = new GameObject();
        leftTileObj.SetActive(false);
        leftTileObj.name = "leftBlueTile";
        blueTile leftTile = leftTileObj.AddComponent<blueTile>();

        Vector3 ver1 = clickPos + new Vector3(0, -(0.5f * helperFunctionsClass.blueBase));
        Vector3 ver2 = clickPos + new Vector3(0, (0.5f * helperFunctionsClass.blueBase));
        Vector3 ver3 = clickPos + new Vector3(- helperFunctionsClass.blueHeight, 0);

        leftTile.Init(ver1, ver2, ver3, false, false, blueTile.blueTag);
        leftTileObj.SetActive(true);
        blueTile.blueTag++;


        GameObject rightTileObj = new GameObject();
        rightTileObj.SetActive(false);
        rightTileObj.name = "bottomRedTile";
        blueTile rightTile = rightTileObj.AddComponent<blueTile>();

        Vector3 ver4 = clickPos + new Vector3(0, - (0.5f * helperFunctionsClass.blueBase));
        Vector3 ver5 = clickPos + new Vector3(0, (0.5f * helperFunctionsClass.blueBase));
        Vector3 ver6 = clickPos + new Vector3(helperFunctionsClass.blueHeight, 0);

        rightTile.Init(ver4,ver5, ver6, true, false, redTile.redTag);
        rightTileObj.SetActive(true);
        blueTile.blueTag++;
    }


    protected override void Start()
    {  

    }


    protected override void Update()
    {
        
    }
}


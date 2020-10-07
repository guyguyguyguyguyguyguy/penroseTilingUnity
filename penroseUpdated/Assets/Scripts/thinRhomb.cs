using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperFunctions;

public class thinRhomb : tile
{

    public void Init(Vector3 clickPos)
    {
        centre = clickPos;

        GameObject topTileObj = new GameObject();
        topTileObj.SetActive(false);
        topTileObj.name = "topRedTile";
        redTile topTile = topTileObj.AddComponent<redTile>();

        Vector3 ver1 = clickPos + new Vector3(-(0.5f * helperFunctionsClass.redBase), 0);
        Vector3 ver2 = clickPos + new Vector3((0.5f * helperFunctionsClass.redBase), 0);
        Vector3 ver3 = clickPos + new Vector3(0, helperFunctionsClass.redHieght);

        topTile.Init(ver1, ver2, ver3, false, false, redTile.redTag);
        topTileObj.SetActive(true);
        redTile.redTag++;


        GameObject bottomTileObj = new GameObject();
        bottomTileObj.SetActive(false);
        bottomTileObj.name = "bottomRedTile";
        redTile bottomTile = bottomTileObj.AddComponent<redTile>();

        Vector3 ver4 = clickPos + new Vector3(- (0.5f * helperFunctionsClass.redBase), 0);
        Vector3 ver5 = clickPos + new Vector3((0.5f * helperFunctionsClass.redBase), 0);
        Vector3 ver6 = clickPos + new Vector3(0, -helperFunctionsClass.redHieght);

        bottomTile.Init(ver4,ver5, ver6, true, false, redTile.redTag);
        bottomTileObj.SetActive(true);
        redTile.redTag++;
    }


    protected override void Start()
    {  

    }


    protected override void Update()
    {
        
    }
}

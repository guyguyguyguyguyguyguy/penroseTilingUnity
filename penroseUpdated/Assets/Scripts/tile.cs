using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperFunctions;

public class tile : MonoBehaviour
{
    public Vector3 centre;
    public Vector3[] tileVertices;
    public float rotation;
    public float rotation2;
    public Vector3[] edge1;
    public Vector3[] edge2;
    public Vector3[] edge3;
    public Vector3[] edge4;
    public List<Vector3[]> edges = new List<Vector3[]>();
    public int matchingCase;

    public new string name;

    protected Vector3[] createP2Tile(string tileType, Vector3 clickPos)
    {
        Vector3 ver1 = new Vector3();
        Vector3 ver2 = new Vector3();
        Vector3 ver3 = new Vector3();

        Vector3 rotatedVer1 = new Vector3();
        Vector3 rotatedVer2 = new Vector3();
        Vector3 rotatedVer3 = new Vector3();
        Vector3 rotatedVer4 = new Vector3();

        GameObject nonMirror = new GameObject();
        GameObject mirror = new GameObject();

        nonMirror.SetActive(false);
        mirror.SetActive(false);

        if(tileType == "red")
        {
            nonMirror.name = "rightKite";
            mirror.name  = "leftKite";

            redTile rightTriangle = nonMirror.AddComponent<redTile>();
            redTile leftTriangle = mirror.AddComponent<redTile>();


            ver1 = clickPos + new Vector3(-(0.5f * helperFunctionsClass.redBase), - helperFunctionsClass.redHieght);
            ver2 = clickPos + new Vector3((0.5f * helperFunctionsClass.redBase), - helperFunctionsClass.redHieght);
            ver3 = clickPos;

            rotatedVer1 = helperFunctionsClass.rotatedVector(clickPos, ver1, 18);
            rotatedVer2 = helperFunctionsClass.rotatedVector(clickPos, ver2, 18);
            rotatedVer3 = helperFunctionsClass.rotatedVector(clickPos, ver3, 18);
            rotatedVer4 = helperFunctionsClass.rotatedVector(clickPos, ver1, -18);

            rightTriangle.Init(rotatedVer1, rotatedVer2, rotatedVer3, false, redTile.redTag);
            redTile.redTag++;
            leftTriangle.Init(rotatedVer4, rotatedVer1, rotatedVer3, true, redTile.redTag);
            redTile.redTag++;

        }

        else if(tileType == "blue")
        {
            nonMirror.name = "leftDart";
            mirror.name  = "rightDart";

            blueTile leftTriangle = nonMirror.AddComponent<blueTile>();
            blueTile rightTriangle = mirror.AddComponent<blueTile>();
            
            ver1 = clickPos + new Vector3(-(0.5f * helperFunctionsClass.blueBase), - helperFunctionsClass.blueHeight);
            ver2 = clickPos + new Vector3((0.5f * helperFunctionsClass.blueBase), - helperFunctionsClass.blueHeight);
            ver3 = clickPos;

            rotatedVer1 = helperFunctionsClass.rotatedVector(clickPos, ver1, 126);
            rotatedVer2 = helperFunctionsClass.rotatedVector(clickPos, ver2, 126);
            rotatedVer3 = helperFunctionsClass.rotatedVector(clickPos, ver3, 126);
            rotatedVer4 = helperFunctionsClass.rotatedVector(clickPos, ver2, -126);


            leftTriangle.Init(rotatedVer2, rotatedVer4, rotatedVer3, false, blueTile.blueTag);
            blueTile.blueTag++;
            rightTriangle.Init(rotatedVer1, rotatedVer2, rotatedVer3, true, blueTile.blueTag);
            blueTile.blueTag++;
        }
        
        nonMirror.SetActive(true);
        mirror.SetActive(true);

        return new Vector3[] {rotatedVer1, rotatedVer3, rotatedVer2, rotatedVer4};
    }





    protected Vector3[] createP3Tile(string tileType, Vector3 clickPos)
    {
        Vector3 ver1 = new Vector3();
        Vector3 ver2 = new Vector3();
        Vector3 ver3 = new Vector3();

        Vector3 rotatedVer1 = new Vector3();
        Vector3 rotatedVer2 = new Vector3();
        Vector3 rotatedVer3 = new Vector3();
        Vector3 rotatedVer4 = new Vector3();

        GameObject nonMirror = new GameObject();
        GameObject mirror = new GameObject();

        nonMirror.SetActive(false);
        mirror.SetActive(false);

        if(tileType == "red")
        {
            nonMirror.name = "topThin";
            mirror.name = "bottomThin";

            redTile topTriangle = nonMirror.AddComponent<redTile>();
            redTile botTriangle = mirror.AddComponent<redTile>();


            ver1 = clickPos + new Vector3(- 0.5f * helperFunctionsClass.redBase, 0);
            ver2 = clickPos + new Vector3(0.5f *helperFunctionsClass.redBase, 0);
            ver3 = clickPos + new Vector3(0, helperFunctionsClass.redHieght);
            rotatedVer4 = helperFunctionsClass.rotatedVector(clickPos, ver3, 180f);

            rotatedVer1 = ver1;
            rotatedVer2 = ver2;
            rotatedVer3 = ver3;

            topTriangle.Init(rotatedVer1, rotatedVer2, rotatedVer3, true, redTile.redTag);
            topTriangle.tileRotation = -288;
            topTriangle.matchingCase = 5;
            redTile.redTag++;
            botTriangle.Init(rotatedVer2, rotatedVer1, rotatedVer4, false, redTile.redTag);
            topTriangle.tileRotation = -288;
            botTriangle.matchingCase = 5;
            redTile.redTag++;
        }

        else if(tileType == "blue")
        {   
            nonMirror.name = "leftThick";
            mirror.name = "rightThick";

            blueTile leftTriangle = nonMirror.AddComponent<blueTile>();
            blueTile rightTriangle = mirror.AddComponent<blueTile>();

            ver1 = clickPos + new Vector3(-(0.5f * helperFunctionsClass.blueBase), 0);
            ver2 = clickPos + new Vector3((0.5f * helperFunctionsClass.blueBase), 0);
            ver3 = clickPos + new Vector3(0, helperFunctionsClass.blueHeight);

            rotatedVer1 = helperFunctionsClass.rotatedVector(clickPos, ver1, 90f);
            rotatedVer2 = helperFunctionsClass.rotatedVector(clickPos, ver2, 90f);
            rotatedVer3 = helperFunctionsClass.rotatedVector(clickPos, ver3, 90f);
            rotatedVer4 = helperFunctionsClass.rotatedVector(clickPos, ver3, -90f);


            leftTriangle.Init(rotatedVer1, rotatedVer2, rotatedVer3, true, blueTile.blueTag);
            leftTriangle.tileRotation = -270;
            leftTriangle.matchingCase = 5;
            blueTile.blueTag++;
            rightTriangle.Init(rotatedVer2, rotatedVer1, rotatedVer4, false, blueTile.blueTag);
            rightTriangle.tileRotation = -270;
            rightTriangle.matchingCase = 5;
            blueTile.blueTag++;
        }

        nonMirror.SetActive(true);
        mirror.SetActive(true);

        return new Vector3[] {rotatedVer1, rotatedVer3, rotatedVer2, rotatedVer4};
    }


    public Vector3[] createP3Tile(string tileType, Vector3 ver1, Vector3 ver2, Vector3 ver3, Vector3 ver4, float tileRotation, int tileMatchingEdge)
    {

        GameObject nonMirror = new GameObject();
        GameObject mirror = new GameObject();

        nonMirror.SetActive(false);
        mirror.SetActive(false);

        if(tileType == "red")
        {
            nonMirror.name = "topThin";
            mirror.name = "bottomThin";

            redTile topTriangle = nonMirror.AddComponent<redTile>();
            redTile botTriangle = mirror.AddComponent<redTile>();


            topTriangle.Init(ver1, ver2, ver3, true, redTile.redTag);
            topTriangle.tileRotation = tileRotation;
            topTriangle.matchingCase = tileMatchingEdge;
            redTile.redTag++;
            botTriangle.Init(ver2, ver1, ver4, false, redTile.redTag);
            botTriangle.tileRotation = tileRotation;
            botTriangle.matchingCase = tileMatchingEdge;
            redTile.redTag++;
        }

        else if(tileType == "blue")
        {   
            nonMirror.name = "leftThick";
            mirror.name = "rightThick";

            blueTile leftTriangle = nonMirror.AddComponent<blueTile>();
            blueTile rightTriangle = mirror.AddComponent<blueTile>();


            leftTriangle.Init(ver1, ver2, ver3, true, blueTile.blueTag);
            leftTriangle.tileRotation = tileRotation;
            leftTriangle.matchingCase = tileMatchingEdge;
            blueTile.blueTag++;
            rightTriangle.Init(ver2, ver1, ver4, false, blueTile.blueTag);
            rightTriangle.tileRotation = tileRotation;
            rightTriangle.matchingCase = tileMatchingEdge;
            blueTile.blueTag++;
        }

        nonMirror.SetActive(true);
        mirror.SetActive(true);
    

        return new Vector3[] {ver1, ver3, ver2, ver4};

    }

    protected Vector3 centreOfTile()
    {   
        Vector3 centre = new Vector3();

        foreach(Vector3 x in this.tileVertices)
        {
            centre += x;
        }

        return centre/4;

    }

    protected void labelEdges()
    {
        edge1 = new Vector3[] {tileVertices[0], tileVertices[1]};
        edge2 = new Vector3[] {tileVertices[1], tileVertices[2]};
        edge3 = new Vector3[] {tileVertices[2], tileVertices[3]};
        edge4 = new Vector3[] {tileVertices[3], tileVertices[0]};


        edges.Add(edge1);
        edges.Add(edge2);
        edges.Add(edge3);
        edges.Add(edge4);
    } 
}

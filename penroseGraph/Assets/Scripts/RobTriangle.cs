using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HelperFunctions;


public class RobTriangle
{
    protected float height;
    protected int deflationStep = 1;
    protected static float x3;
    protected static float y3;
    protected BlueDrawer BlueDrawerObj;
    // protected RedDrawer RedDrawerObj;


    public int _id;
    public bool mirrored;
    public float tileRotation;
    public int matchingCase;
    public string typeOfTiling;
    public Vector3 vertex1;
    public Vector3 vertex2;
    public Vector3 vertex3;
    public Vector3[] vertices;
    public int[] triangles;

    public TilePlacementClass TP;


    public RobTriangle()
    {
        TP = GameObject.Find("TilePlacement").GetComponent<TilePlacementClass>();
    }

    public void Init(Vector3 ver1, Vector3 ver2, Vector3 ver3, bool mirrorImage, int tagNo)
    {   
        if(mirrorImage)
        {   
            Init(ver2, ver1, ver3, 1, 2, 0, mirrorImage, tagNo);
        }
        else
        {  
            Init(ver1, ver2, ver3, 0, 2, 1, mirrorImage, tagNo);
        }
    }


    public void Init(Vector3 ver1, Vector3 ver2, Vector3 ver3, int t1, int t2, int t3, bool mirrorImage, int tagNo)
    {
        mirrored = mirrorImage;

        ver1[2] = 10f;
        ver2[2] = 10f;
        ver3[2] = 10f;

        vertices = new Vector3[3];
        vertices[0] = ver1;
        vertices[1] = ver2;
        vertices[2] = ver3;

        triangles = new int[3];
        triangles[0] = t1 + (tagNo *3);
        triangles[1] = t2 + (tagNo *3);
        triangles[2] = t3 + (tagNo*3);

        typeOfTiling = Manager.tileType;

        vectorsTrianglesToDrawer(this.GetType(), vertices, triangles);
    }


    public virtual void deflate()
    {

    }


    public void _deflate(string typeTile, Vector3 v1, Vector3 v2, Vector3 v3, bool mirrorImage, string name, int tagNo)
    {  
        this.deflationStep +=1;

        Vector3 v4 = HelperFunctionsClass.FourthVer(v1, v2, v3);

        Vector3[] vers = new Vector3[] { v1, v2, v3, v4 };

        // Fix this, because if i instantiate, then it doesn't have access to the prefabs

        TP.InstantiateTile(typeTile, vers, tileRotation);
    }


    protected void vectorsTrianglesToDrawer(System.Type typeTile, Vector3[] verticesToAdd, int[] triangles)
    {   

        if(typeTile == typeof(BlueTile))
        {   
            BlueDrawer drawBlue = Manager.blueDrawObj.GetComponent<BlueDrawer>();
            drawBlue.AddToRend(verticesToAdd, triangles);
        }

        else if(typeTile == typeof(RedTile))
        {  
            RedDrawer drawRed = Manager.redDrawObj.GetComponent<RedDrawer>();
            drawRed.AddToRend(verticesToAdd, triangles);
        }

    }


    public virtual int tagNo()
    {
        return 0;
    }

    public string getTileType()
    {
        return typeOfTiling;
    }
}

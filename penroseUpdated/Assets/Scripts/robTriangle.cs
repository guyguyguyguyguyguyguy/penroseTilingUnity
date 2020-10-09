using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robTriangle : MonoBehaviour
{
    protected float height;
    protected int deflationStep = 1;
    protected Vector3 vertex1;
    protected Vector3 vertex2;
    protected static float x3;
    protected static float y3;
    protected Vector3 vertex3;
    protected GameObject outlineL; 
    protected GameObject outlineR; 
    protected blueDrawer blueDrawerObj;
    // protected redDrawer redDrawerObj;


    public int _id;
    public bool mirror;
    public float rotation;
    public Vector3 centre;
    public Vector3 worldVertex1;
    public Vector3 worldVertex2;
    public Vector3 worldVertex3;
    public Vector3[] vertices;
    public int[] triangles;
    public Vector3[] worldVerticies;

    void Awake()
    {
        worldVertex1 = transform.TransformPoint(vertex1);
        worldVertex2 = transform.TransformPoint(vertex2);
        worldVertex3 = transform.TransformPoint(vertex3);

        worldVerticies = new Vector3[3];
        worldVerticies[0] = worldVertex1;
        worldVerticies[1] = worldVertex2;
        worldVerticies[2] = worldVertex3;

        this.centre = centreOfTile();

        worldVertex1[2] = 10f;
        worldVertex2[2] = 10f;
        worldVertex3[2] = 10f;

        vectorsTrianglesToDrawer(this.GetType(), worldVerticies, triangles);

        manager.allObjects.Add(this);
    }


    public void Init(Vector3 ver1, Vector3 ver2, Vector3 ver3, bool mirrorImage, bool snap, int tagNo)
    {   
        if(!snap)
        {
            if(mirrorImage)
            {
                Init(ver1, ver2, ver3, 1, 2, 0, mirrorImage, tagNo);
            }
            else
            {
                Init(ver1, ver2, ver3, 0, 2, 1, mirrorImage, tagNo);
            }
        }
        else
        {
            if(mirrorImage)
            {
                Init(ver2, ver1, ver3, 1, 2, 0, mirrorImage, tagNo);
            }
            else
            {
                Init(ver2, ver1, ver3, 0, 2, 1, mirrorImage, tagNo);
            }
        }
    }


    public void Init(Vector3 ver1, Vector3 ver2, Vector3 ver3, int t1, int t2, int t3, bool mirrorImage, int tagNo)
    {
        mirror = mirrorImage;

        vertex1 = ver1;
        vertex2 = ver2;
        vertex3 = ver3;

        vertices = new Vector3[3];
        vertices[0] = ver1;
        vertices[1] = ver2;
        vertices[2] = ver3;

        triangles = new int[3];
        triangles[0] = t1 + (tagNo *3);
        triangles[1] = t2 + (tagNo *3);
        triangles[2] = t3 + (tagNo*3);
    }


    protected virtual void Start()
    {
        
    }


    protected virtual void Update()
    {
        
    }


    public virtual void deflate()
    {

    }

    public void _deflate(System.Type typeTile, Vector3 v1, Vector3 v2, Vector3 v3, bool mirrorImage, string name, int tagNo)
    {  
        this.deflationStep +=1;

        GameObject newTileObj = new GameObject();
        newTileObj.SetActive(false);
        newTileObj.name = name;
        robTriangle newTile = (robTriangle)newTileObj.AddComponent(typeTile); 

        newTile.Init(v1, v2, v3, mirror, false, tagNo);
        newTileObj.SetActive(true);
    }


    protected GameObject _drawLine(Vector3 start, Vector3 end, Color color, string name)
    {   
        GameObject outline = new GameObject();
        outline.transform.SetParent(this.transform);
        outline.name = name;
        outline.transform.position = start;
        outline.AddComponent<LineRenderer>();
        LineRenderer lr = outline.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Standard"));
        lr.sortingOrder = 1;
        lr.sortingLayerName = "Foreground";
        lr.material.color = color;
        lr.startWidth = 0.43f * 0.034f;
        lr.endWidth = 0.43f * 0.034f;
        start[2] = -10f;
        end[2] = -10f;
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);

        return outline;
    }

    protected Vector3 centreOfTile()
    {   
        Vector3 centre = new Vector3();

        foreach(Vector3 x in this.worldVerticies)
        {
            centre += x;
        }

        return centre/3;

    }

    protected void vectorsTrianglesToDrawer(System.Type typeTile, Vector3[] vertices, int[] triangles)
    {   

        if(typeTile == typeof(blueTile))
        {   
            blueDrawer drawBlue = manager.blueDrawObj.GetComponent<blueDrawer>();
            drawBlue.addToRend(vertices, triangles);
        }

        else if(typeTile == typeof(redTile))
        {  
            redDrawer drawRed = manager.redDrawObj.GetComponent<redDrawer>();
            drawRed.addToRend(vertices, triangles);
        }

    }

    public virtual int tagNo()
    {
        return 0;
    }
}

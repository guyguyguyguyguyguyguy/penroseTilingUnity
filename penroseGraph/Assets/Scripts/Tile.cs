using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HelperFunctions;

public class Tile : MonoBehaviour
{

    // Maybe add rotation instead of working out the verticies 


    public Vector3 centre;
    public Vector3[] tileVertices = new Vector3[4];
    public float rotation;
    public float rotation2;
    public Vector3[] edge1;
    public Vector3[] edge2;
    public Vector3[] edge3;
    public Vector3[] edge4;
    public List<Vector3[]> edges = new List<Vector3[]>();
    public int matchingCase;
    public Vector3[] worldVertices = new Vector3[4];
    
    protected GameObject outlineL; 
    protected GameObject outlineR; 

    protected RobTriangle mirrorTri;
    protected RobTriangle nonMirrorTri;
    

    //Add collider


    public Tile[] neighbours = new Tile[4];

    public new string name;

    void Awake()
    {
        
    }


    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(this);

            Deflate();

            Destroy(outlineL);
            Destroy(outlineR);
        }
    }


    public RobTriangle[] createP3Tile(string tileType, Vector3 ver1, Vector3 ver2, Vector3 ver3, Vector3 ver4, float rotation)
    {
        if(tileType == "red")
        {
            RedTile topTile = new RedTile();
            topTile.Init(ver1, ver2, ver3, true, RedTile.redTag);
            topTile.tileRotation = rotation;
            RedTile.redTag++;
            
            RedTile bottomTile = new RedTile();
            bottomTile.Init(ver2, ver1, ver4, false, RedTile.redTag);
            bottomTile.tileRotation = rotation;
            RedTile.redTag++;

            return new RobTriangle[] { topTile, bottomTile };
        }

        else if(tileType == "blue")
        {   
            BlueTile leftTile = new BlueTile();
            leftTile.Init(ver1, ver2, ver3, true, BlueTile.blueTag);
            leftTile.tileRotation = rotation;
            BlueTile.blueTag++;

            BlueTile rightTile = new BlueTile();
            rightTile.Init(ver2, ver1, ver4, false, BlueTile.blueTag);
            rightTile.tileRotation = rotation;
            BlueTile.blueTag++;
            
            return new RobTriangle[] { rightTile, leftTile };
        }

        return new RobTriangle[] { };

    }


    protected Vector3 centreOfTile()
    {   
        Vector3 centre = new Vector3();

        foreach(Vector3 x in this.worldVertices)
        {
            centre += x;
        }

        return centre/4;

    }

    
    protected void Deflate()
    {
        RedTile.redTag = 0;
        BlueTile.blueTag = 0;

        mirrorTri.deflate();
        nonMirrorTri.deflate();
    }


    protected void labelEdges()
    {
        edge1 = new Vector3[] {worldVertices[0], worldVertices[2]};
        edge2 = new Vector3[] {worldVertices[2], worldVertices[1]};
        edge3 = new Vector3[] {worldVertices[1], worldVertices[3]};
        edge4 = new Vector3[] {worldVertices[3], worldVertices[0]};


        edges.Add(edge1);
        edges.Add(edge2);
        edges.Add(edge3);
        edges.Add(edge4);
    } 


    protected void _drawLine()
    {   

        // TODO: add this to the prefab!!!

        // GameObject outline = new GameObject();
        // outline.transform.SetParent(this.transform);
        // outline.name = name;
        // outline.transform.position = start;
        // LineRenderer lr = outline.AddComponent<LineRenderer>();

        // lr.material = new Material(Shader.Find("Standard"));
        // lr.sortingOrder = 1;
        // lr.sortingLayerName = "Foreground";
        // lr.material.color = color;
        // lr.startWidth = 0.43f * 0.034f;
        // lr.endWidth = 0.43f * 0.034f;
        // start[2] = -10f;
        // end[2] = -10f;
        // lr.SetPosition(0, start);
        // lr.SetPosition(1, end);

        // return outline;
    }


    protected void FindNeighbours()
    {
        // something with raycasting
    }


    // protected void findNeighbours()
    // {
    //     foreach (tile t in manager.allObjects)
    //     {
    //         foreach (Vector3[] otherEdge in t.edges)
    //         {
    //             for (int i = 0; i < edges.Count; ++i)
    //             {
    //                 // For some reason says that edges are empty but they are not??? Maybe need to impliment for each tile class
    //                 if(otherEdge == edges[i])
    //                 {
    //                     neighbours[i] = t;
    //                     Debug.Log("I found a neighbour");
    //                 }
    //             }
    //         }
    //     }
    // }

    // protected void findNeighbours()
    // {   

    //     // Issues after deflation

    //     int noNeigh = 0;

    //     foreach (tile t in manager.allObjects)
    //     {
    //         if (Vector3.Distance(this.centre, t.centre) < (helperFunctionsClass.redHieght *2))
    //         {
                
    //             for (int j = 0; j < t.edges.Count; ++j)
    //             {
    //                 for (int i = 0; i < this.edges.Count; ++i)
    //                 {
    //                     // Debug.Log("there are things close enough");

    //                     if(helperFunctionsClass.equalEdges(t.edges[j], this.edges[i]))
    //                     {
    //                         this.neighbours[i] = t;

    //                         noNeigh++;

    //                         t.neighbours[j] = this;
    //                     }
    //                 }
    //             }
    //         }
    //     }
    //     // Debug.Log(noNeigh);
    // }
}

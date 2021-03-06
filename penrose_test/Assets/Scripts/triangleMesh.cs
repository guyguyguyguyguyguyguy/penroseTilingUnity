﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperFunctions;

public class triangleMesh : MonoBehaviour
{
    protected static float GOLDENRATIO = (1 + Mathf.Sqrt(5))/2; 

    public int _id;
    protected float height;

    protected int deflationStep = 1;

    protected Vector3 vertex1;
    protected Vector3 vertex2;
    protected static float x3;
    protected static float y3;
    protected Vector3 vertex3;


    public string Name; 
    public bool mirror;
    public float rotation;
    public Vector3 centre;
    public Vector3 worldVertex1;
    public Vector3 worldVertex2;
    public Vector3 worldVertex3;

    public Vector3[] verticies;
    public int[] triangles;
    public Vector3[] worldVerticies;

    protected Mesh awesomeMesh;
    protected Renderer rend; 
    
    protected GameObject outlineL; 
    protected GameObject outlineR; 


    void Awake()
    {

    }

    public void Init(Vector3 ver1, Vector3 ver2, Vector3 ver3, bool mirrorImage, bool snap)
    {   
        if(!snap)
        {
            if(mirrorImage)
            {
                Init(ver1, ver2, ver3, 1, 2, 0, mirrorImage);
            }
            else
            {
                Init(ver1, ver2, ver3, 0, 2, 1, mirrorImage);
            }
        }
        else
        {
            if(mirrorImage)
            {
                Init(ver2, ver1, ver3, 1, 2, 0, mirrorImage);
            }
            else
            {
                Init(ver2, ver1, ver3, 0, 2, 1, mirrorImage);
            }
        }
    }

    public void Init(Vector3 ver1, Vector3 ver2, Vector3 ver3, int t1, int t2, int t3, bool mirrorImage)
    {
        mirror = mirrorImage;

        vertex1 = ver1;
        vertex2 = ver2;
        vertex3 = ver3;

        triangles = new int[3];
        triangles[0] = t1;
        triangles[1] = t2;
        triangles[2] = t3;

        Manager.allObjects.Add(this);

    }
    
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public virtual void deflate()
    {

    }

    // public void _deflate(System.Type typeTri, Vector3 v1, Vector3 v2, Vector3 v3)
    // {  
    //     _deflate(typeTri, v1, v2, v3, mirror);
    // }


    public void _deflate(System.Type typeTri, Vector3 v1, Vector3 v2, Vector3 v3, bool mirrorImage)
    {  
        this.deflationStep +=1;

        Material m_Material = GetComponent<Renderer>().material;

        GameObject obj = new GameObject();
        obj.SetActive(false);

        MeshFilter objFil= obj.AddComponent<MeshFilter>();
        MeshRenderer objRend = obj.AddComponent<MeshRenderer>();
        objRend.material = m_Material;
        triangleMesh newTriangleMesh = (triangleMesh)obj.AddComponent(typeTri);
        newTriangleMesh.Init(v1, v2, v3, mirrorImage, false);
  
        obj.SetActive(true);
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
        lr.sortingLayerName = "Foreground";
        lr.material.color = color;
        // lr.startWidth = 0.034f /(Mathf.Exp(this.deflationStep));
        // lr.endWidth = 0.034f / (Mathf.Exp(this.deflationStep));
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

    public virtual Vector3 thirdVertexCalc(Vector3 origin, Vector3 secondVertex)
    {
        return Vector3.zero;
    }

}

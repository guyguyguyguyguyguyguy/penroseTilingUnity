using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triangleMesh : MonoBehaviour
{
    protected static float GOLDENRATIO = (1 + Mathf.Sqrt(5))/2; 
    protected Vector3 vertex1;
    protected Vector3 vertex2;
    protected static float x3;
    protected static float y3;
    protected Vector3 vertex3;


    public string Name; 
    public string Label;
    public Vector3 worldVertex1;
    public Vector3 worldVertex2;
    public Vector3 worldVertex3;

    public Vector3[] verticies;
    public int[] triangles;

    protected Mesh awesomeMesh;
    protected Renderer rend; 


    public void Init(Vector3 ver1, Vector3 ver2, Vector3 ver3)
    {
        Init(ver1, ver2, ver3, 0, 2, 1, null);
    }

    public void Init(Vector3 ver1, Vector3 ver2, Vector3 ver3, int t1, int t2, int t3, string label)
    {
        Label = label;

        vertex1 = ver1;
        vertex2 = ver2;
        vertex3 = ver3;

        triangles = new int[3];
        triangles[0] = t1;
        triangles[1] = t2;
        triangles[2] = t3;

    }

    protected virtual void Awake()
    {

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

    public void _deflate(System.Type typeTri, Vector3 v1, Vector3 v2, Vector3 v3)
    {  
        _deflate(typeTri, v1, v2, v3, 0, 2, 1, null);
    }


    public void _deflate(System.Type typeTri, Vector3 v1, Vector3 v2, Vector3 v3, int t1, int t2, int t3, string label)
    {  
        Material m_Material = GetComponent<Renderer>().material;

        GameObject obj = new GameObject();
        obj.SetActive(false);
        MeshFilter objFil= obj.AddComponent<MeshFilter>();
        MeshRenderer objRend = obj.AddComponent<MeshRenderer>();
        objRend.material = m_Material;
        triangleMesh newTriangleMesh = (triangleMesh)obj.AddComponent(typeTri);
        newTriangleMesh.Init(v1, v2, v3, t1, t2, t3, label);
  
        obj.SetActive(true);
    }
}

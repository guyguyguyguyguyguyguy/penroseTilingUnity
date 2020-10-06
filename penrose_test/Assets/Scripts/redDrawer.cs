using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redDrawer : MonoBehaviour
{   
    public Vector3[] verticies;
    public int[] triangles;
    public Vector3[] worldVerticies;

    protected MeshFilter awesomeMesh;
    protected Renderer rend;


    void Awake()
    {
        rend = this.gameObject.GetComponent<MeshRenderer>();
        rend.material = new Material(Shader.Find("Standard"));

        Color newColour;
        ColorUtility.TryParseHtmlString("#FF5958", out newColour);
        rend.material.SetColor("_Color", newColour);

    }

    void Start()
    {

    }


    void Update()
    {
        // awesomeMesh = new Mesh();
        // GetComponent<MeshFilter>().sharedMesh = awesomeMesh;
        // awesomeMesh.Clear();
        // awesomeMesh.vertices = verticies;
        // awesomeMesh.triangles = triangles;

        // rend = GetComponent<Renderer>();
        // Color newColour;
        // ColorUtility.TryParseHtmlString("#FF5958", out newColour);
        // rend.material.SetColor("_Color", newColour);

    }
}

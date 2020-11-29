using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDrawer : Drawer
{
 
    void Start()
    {   
        Material blueMaterial = Resources.Load("Materials/BlueOutlineMat", typeof(Material)) as Material;

        Color newColour;
        ColorUtility.TryParseHtmlString("#65fff3", out newColour);
        rend.material.SetColor("_Color", newColour);
        GetComponent<Renderer>().material = blueMaterial;
    }

}

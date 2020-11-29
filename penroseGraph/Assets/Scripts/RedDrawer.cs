using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDrawer : Drawer
{

    void Start()
    {
        Material redMaterial = Resources.Load("Materials/RedOutlineMat", typeof(Material)) as Material;
        
        Color newColour;
        ColorUtility.TryParseHtmlString("#ffb265", out newColour);
        rend.material.SetColor("_Color", newColour);
        GetComponent<Renderer>().material = redMaterial;
    }


}

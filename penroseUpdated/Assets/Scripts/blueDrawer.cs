using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueDrawer : drawer
{

    void Start()
    {   
        Color newColour;
        ColorUtility.TryParseHtmlString("#6667FF", out newColour);
        rend.material.SetColor("_Color", newColour);
    }

}

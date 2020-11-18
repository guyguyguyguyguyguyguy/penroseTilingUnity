using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDrawer : Drawer
{

    void Start()
    {
        Color newColour;
        ColorUtility.TryParseHtmlString("#FF5958", out newColour);
        rend.material.SetColor("_Color", newColour);
    }


}

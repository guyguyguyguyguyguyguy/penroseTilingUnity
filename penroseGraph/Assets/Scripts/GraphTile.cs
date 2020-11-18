using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Globals;

public class GraphTile
{
    public string hashLabel;
    public string[] neighbours = new string[4];

    public GraphTile(string tileType)
    {
        AssignHashLabel(tileType);
    }

    void AssignHashLabel(string tileType)
    {
        hashLabel = tileType + Variables.tileCounter.ToString();
        ++Variables.tileCounter;
    }

}
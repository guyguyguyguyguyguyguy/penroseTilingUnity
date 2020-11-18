using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Globals;
using System.Linq;

public class TilingGraph
{
    public IDictionary<string, GraphTile> tileHashMap = new Dictionary<string, GraphTile>();
    
    public void AddTile(string tileType)
    {
        string[] emptyNeighbours = new string[] { };
        int[] emptyEdgeNo = new int[] { };
        AddTile(tileType, emptyNeighbours, emptyEdgeNo);
    }

    public void AddTile(string tileType, string[] neighbours, int[] edgeNo)
    {
        GraphTile t = new GraphTile(tileType);
        tileHashMap[t.hashLabel] = t;
        AddToNeighbours(t, neighbours, edgeNo);
    }

    public void AddToNeighbours(GraphTile newTile, string[] neighbours, int[] edgeNo)
    {
        for (int i = 0; i < neighbours.Length; ++i)
        {
            tileHashMap[neighbours[i]].neighbours[edgeNo[i]] = newTile.hashLabel;
            newTile.neighbours[i] = neighbours[i];
        }
    }

    
    public void Deflation()
    {
      // TODO
    }
}

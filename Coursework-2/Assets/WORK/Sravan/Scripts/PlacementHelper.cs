using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlacementHelper 
{

    public static List<Direction> FindNeighbour(Vector3Int position, ICollection<Vector3Int> collecction)
    {
        List<Direction> neighbourDirections = new List<Direction>();
        if (collecction.Contains(position+Vector3Int.right))
        {
            neighbourDirections.Add(Direction.Right);
        }
        if (collecction.Contains(position - Vector3Int.right))
        {
            neighbourDirections.Add(Direction.Left);
        }
        if (collecction.Contains(position + new Vector3Int(0,0,1)))
        {
            neighbourDirections.Add(Direction.Up);
        }
        if (collecction.Contains(position + new Vector3Int(0, 0, -1)))
        {
            neighbourDirections.Add(Direction.Down);
        }

        return neighbourDirections;
    }
}

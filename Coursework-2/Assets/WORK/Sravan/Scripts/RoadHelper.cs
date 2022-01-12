using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadHelper : MonoBehaviour
{
    public GameObject roadStraight;
    public GameObject roadCorner;
    public GameObject road3way;
    public GameObject road4way;
    public GameObject roadEnd;

    Dictionary<Vector3Int, GameObject> roadDictionary = new Dictionary<Vector3Int, GameObject>();

    HashSet<Vector3Int> fixRoadCandidates = new HashSet<Vector3Int>();

    /// <summary>
    /// Placing the prefab instead of the line renderer
    /// </summary>
    /// <param name="startPosition">Start poisition</param>
    /// <param name="direction"> instead of end, it is direction</param>
    /// <param name="length">length of instantiate</param>
    public void PlaceStreetPosition(Vector3 startPosition, Vector3Int direction, int length)
    {
        var rotation = Quaternion.identity;
        if (direction.x==0)
        {
            rotation = Quaternion.Euler(0, 90, 0);
        }

        for (int i = 0; i < length; i++)
        {
            var position = Vector3Int.RoundToInt(startPosition + direction * i);
            if (roadDictionary.ContainsKey(position))
            {
                continue;
            }

            var road = Instantiate(roadStraight, position, rotation, transform);
            roadDictionary.Add(position, road);

            if (i==0||i==length-1)
            {
                fixRoadCandidates.Add(position);
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ProceduralCity/Rule")]
public class Rules : ScriptableObject
{
    /// <summary>
    /// char of the string which replaced form the results
    /// </summary>
    public string letter;

    /// <summary>
    /// Array of the different rules
    /// </summary>
    [SerializeField]private string[] results = null;

    /// <summary>
    /// Boolean for randomize the result
    /// </summary>
    [SerializeField] private bool randomResult = false;

    /// <summary>
    /// Checks rules 
    /// </summary>
    /// <returns>first elemet in the rule</returns>
    public string GetResult()
    {
        if (randomResult)
        {
            int randomIndex = Random.Range(0, results.Length);
            return results[randomIndex];
        }

        return results[0];
    }
}

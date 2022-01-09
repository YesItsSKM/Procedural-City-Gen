using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleVisualizer : MonoBehaviour
{
    public LSystemsGenerator LSystemsGenerator;
    List<Vector3> positions = new List<Vector3>();
    public GameObject prefab;
    public Material lineMaterial;

    private int length = 8;
    private float angle = 90;

    public int Length
    {
        get
        {
            if (length > 0)
            {
                return length;
            }
            else
            {
                return 1;
            }
        }
        set => length = value;
    }

    private void Start()
    {
        var sequence = LSystemsGenerator.GenerateSentence();
        VisualizeSequence(sequence);
    }

    private void VisualizeSequence(string sequence)
    {
        Stack<AgentParameters> savePoints = new Stack<AgentParameters>();
        var currentPosition = Vector3.zero;

        Vector3 direction = Vector3.forward;
        Vector3 tempPosition = Vector3.zero;

        positions.Add(currentPosition);

        foreach (var letter in sequence)
        {
            EncodingLetters encoding = (EncodingLetters)letter;

            switch (encoding)
            {
                case EncodingLetters.save:
                     break;
                case EncodingLetters.load:
                    break;
                case EncodingLetters.draw:
                    break;
                case EncodingLetters.turnRight:
                    break;
                case EncodingLetters.turnLeft:
                    break;
                default:
                    break;
            }
        }
    }

    public enum EncodingLetters
    {
        unknown='1',
        save='[',
        load=']',
        draw='F',
        turnRight='+',
        turnLeft='-'
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LSystemsGenerator : MonoBehaviour
{
    public Rules[] rules;
    public string rootSentences;

    [Range(0,4)]
    public int iterationLimit = 1;

    private void Start()
    {
        Debug.Log(GenerateSentence());
    }

    public string GenerateSentence(string word= null)
    {
        if(word==null)
        {
            word = rootSentences;
        }

        return GrowRecursive(word);
    }

    private string GrowRecursive(string word,int iterationIndex=0)
    {
        if(iterationIndex>=iterationLimit)
        {
            return word;
        }

        StringBuilder newWord= new StringBuilder();

        foreach (var c in word)
        {
            newWord.Append(c);
            ProcessRulesRecursivelly(newWord, c, iterationIndex);
        }

        return newWord.ToString();
    }

    private void ProcessRulesRecursivelly(StringBuilder newWord, char c, int iterationIndex)
    {
        foreach (var rule in rules)
        {
            if(rule.letter==c.ToString())
            {
                newWord.Append(GrowRecursive(rule.GetResult(), iterationIndex + 1));
            }
        }
    }
}

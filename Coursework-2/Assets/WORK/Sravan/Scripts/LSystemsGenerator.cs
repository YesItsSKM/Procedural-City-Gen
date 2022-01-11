using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LSystemsGenerator : MonoBehaviour
{
    public Rules[] rules;
    public string rootSentences;

    [Range(0, 4)]
    public int iterationLimit = 1;

    /// <summary>
    /// Ignore the randomnise
    /// </summary>
    public bool randomIgnoreRuleModifier = true;

    /// <summary>
    /// Probability to ignoring the random rules is 30 percentage
    /// </summary>
    [Range(0, 1)] public float chanceToIgnoreRules = 0.3f;


    private void Start()
    {
        Debug.Log(GenerateSentence());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="word"></param>
    /// <returns></returns>
    public string GenerateSentence(string word= null)
    {
        if(word==null)
        {
            word = rootSentences;
        }

        return GrowRecursive(word);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="word"></param>
    /// <param name="iterationIndex"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Generates the string 
    /// </summary>
    /// <param name="newWord">Everything adds upto this word </param>
    /// <param name="c">each character in the rule</param>
    /// <param name="iterationIndex">number of iterations </param>
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

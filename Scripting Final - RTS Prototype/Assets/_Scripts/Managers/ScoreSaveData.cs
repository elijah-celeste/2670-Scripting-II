using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Score")]
public class ScoreSaveData : ScriptableObject
{
    public int score = 0;
    public int difficultyLevel = 1;
    public int numberOfKnights = 1;
    
    void ResetScoreData()
    {
        score = 0;
        difficultyLevel = 1;
        numberOfKnights = 1;
    }
}

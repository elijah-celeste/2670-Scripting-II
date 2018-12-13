using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public ScoreSaveData score;

    public Button enterArena;

    public Text difficultyLevel;
    public Text playerOwnedKnights;
    public Text currentCoins;
    public Button purchaseKnight;

    public int baseCost = 2;
    public int currentCost;

    void Update()
    {
        currentCost = baseCost + score.numberOfKnights;
        playerOwnedKnights.text = "Player Owned Knights: " + score.numberOfKnights;
        purchaseKnight.GetComponentInChildren<Text>().text =
            "Purchase Knight \n Cost: " + (currentCost) + " Coins";
        currentCoins.text = "Coins: " + score.score;

        if (score.numberOfKnights > 9)
        {
            score.numberOfKnights = 9;
        }

        if (score.difficultyLevel > 9)
        {
            score.difficultyLevel = 9;
        }
    }
    
    public void setDifficulty(float value)
    {
        score.difficultyLevel = Mathf.RoundToInt(value);
        difficultyLevel.text = "Difficulty Level: " + value;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void PurchaseButton()
    {
        if (score.score >= currentCost)
        {
            score.score -= currentCost;
            score.numberOfKnights++;
        }
    }
}

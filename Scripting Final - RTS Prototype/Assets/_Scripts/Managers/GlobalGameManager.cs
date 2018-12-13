using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalGameManager : MonoBehaviour
{
	public ScoreSaveData score;
	public float timer;
	public Text timerText;
	public Text coinText;

	[Header("Knights")]
	public GameObject[] PlayerKnights;
	public GameObject[] EnemyKnights;

	void Start()
	{
		for (int i = 0; i < PlayerKnights.Length; i++)
		{
			if (i <= score.numberOfKnights-1)
			{
				PlayerKnights[i].SetActive(true);
			}
		}
		
		for (int i = 0; i < EnemyKnights.Length; i++)
		{
			if (i <= score.difficultyLevel-1)
			{
				EnemyKnights[i].SetActive(true);
				EntityController enemyController = EnemyKnights[i].GetComponent<EntityController>();
				enemyController.assignedTask = PlayerKnights[Random.Range(1, score.numberOfKnights)];
				enemyController.isTasked = true;
			}
		}
	}
	
	void Update ()
	{
		if (timer > 0)
		{
			timer -= Time.deltaTime;
		}
		else if (timer <= 0)
		{
			TimeOut();
		}

		timerText.text = string.Format("TIME: {0:#.00}", timer);
		coinText.text = "Coins: " + score.score;
	}

	public void TimeOut()
	{
		timer = 0;
		SceneManager.LoadScene(1);
	}
	
	public void AddScore()
	{
		score.score += 1;
	}
}

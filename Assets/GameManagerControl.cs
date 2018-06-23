using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManagerControl : UnityEngine.MonoBehaviour
{
	public int life = 3;
	private GameObject[] enemies;
	private GameObject[] humans;
	private CharacterControl myPlayer;
	private int myScore = 0;
	private int humansSaved = 0;
	public Text scoreText;
	public Text lifeText;
	private float levelNum = 1.0f;
	public GameObject[] EnemyTypes;
	public GameObject human;
	private GameObject toSpawn;
	private Vector3 spawnPosition;
	bool isRespawning = false;
	private GameObject placeholder;

	private int GetScoreToAdd(string myName)
	{
		int scoreToAdd = 0;
		switch (myName)
		{
			case "Human":
				scoreToAdd = 1000 + humansSaved * 1000;
				humansSaved++;
				if (humansSaved % 3 == 0)
				{
					life++;
				}
				break;
			case "Grunt":
				scoreToAdd = 100;
				break;
			default:
				//print("no point for u cuz u su c c c c");
				break;
		}
		return scoreToAdd;
	}
	public void DidIWin()
	{
		//print("how many enemies?" + (GameObject.FindGameObjectsWithTag("Enemy").Length - GameObject.FindObjectsOfType(typeof(HulkControl)).Length).ToString());
		if (!isRespawning)
		{
			if (GameObject.FindGameObjectsWithTag("Enemy").Length - GameObject.FindObjectsOfType(typeof(HulkControl)).Length <= 0)
			{
				//print("u win!");
				DestroyAllStuff();
				levelNum++;
				NewLevel(levelNum);
			}
		}
	}
	public void AddScore(string myName)
	{
		myScore += GetScoreToAdd(myName);
	}

	private void DestroyAllStuff()
	{
		isRespawning = true;
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		print(enemies);
		for (int i = 0; i < enemies.Length; i++)
		{
			print(enemies[i]);
			Destroy(enemies[i]);
		}

		humans = GameObject.FindGameObjectsWithTag("Human");
		for (int i = 0; i < humans.Length; i++)
		{
			Destroy(humans[i]);
		}

	}
	private void NewLevel(float levelNum)
	{
		isRespawning = false;
		WalkingEnemyControl.SetIsRespawning();
		HulkControl.SetIsRespawning();
		for (int i = 0; i < levelNum * 3; i++)
		{
			//print("i am triggered");
			//print("spawn " + i.ToString() + "!");
			spawnPosition = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-2.5f, 2.5f));
			while (Vector2.Distance(spawnPosition, new Vector3(0, 0, 0)) < 4)
			{
				spawnPosition = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-2.5f, 2.5f));
				//print("i don know da wae");
			}

			toSpawn = EnemyTypes[Random.Range(0, EnemyTypes.Length)];
			if (Vector2.Distance(spawnPosition, new Vector3(0, 0, 0)) > 4)
			{
				Instantiate(toSpawn, spawnPosition, transform.rotation);
			}

		}
		for (int i = 0; i < levelNum; i++)
		{
			spawnPosition = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-2.5f, 2.5f));
			while (Vector2.Distance(spawnPosition, new Vector3(0, 0, 0)) < 4)
			{
				spawnPosition = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-2.5f, 2.5f));
			}
			if (Vector2.Distance(spawnPosition, new Vector3(0, 0, 0)) > 4)
			{
				Instantiate(human, spawnPosition, transform.rotation);
			}
		}
		myPlayer.DeactivateCollision();
		myPlayer.DeactivateRenderer();
		Invoke("ResetPlayer", 2f);
	}
	private void ResetPlayer()
	{
		myPlayer.Reset();
		WalkingEnemyControl.SetNotRespawning();
		HulkControl.SetNotRespawning();
	}
	private void Quit()
	{
		Application.Quit();
	}
	private void GameOver()
	{
		//print("u suc c c c ")
		ScorePasserControl.SetMyScore(myScore);
		SceneManager.LoadScene(1);
		//Invoke("Quit", 2.0f);
	}
	public void death()
	{
		life--;
		DestroyAllStuff();
		//print(life);
		if (life > 0)
		{
			ResetPlayer();
			NewLevel(levelNum);
		}
		else
		{
			GameOver();
		}
	}

	// Use this for initialization
	void Start()
	{
		myPlayer = GameObject.Find("myCharacter").GetComponent<CharacterControl>();

		//placeholder = GameObject.FindGameObjectWithTag("Placeholder");
		NewLevel(levelNum);
	}

	// Update is called once per frame
	void Update()
	{

		scoreText.text = "Score: " + myScore.ToString();
		lifeText.text = "Life: " + life.ToString();
		//print(levelNum);
		//print(myPlayer);
	}
}

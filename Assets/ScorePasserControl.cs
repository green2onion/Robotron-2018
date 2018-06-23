using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePasserControl : MonoBehaviour {
	private static int myScore;
	public static void SetMyScore(int score)
	{
		myScore = score;
	}
	public static int GetMyScore()
	{
		return myScore;
	}
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		//print(myScore);
	}
}

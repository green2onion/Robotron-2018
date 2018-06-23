using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class YouLostText : MonoBehaviour {
	private int myScore;
	public Text text;
	decimal myScoreToPrint;
	string myTextToPrint;
	private void SetMyScore(int score)
	{
		//myScore = score;
		myScoreToPrint = score;
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//print(ScorePasserControl.GetMyScore());
		SetMyScore(ScorePasserControl.GetMyScore());
		myTextToPrint = string.Format("Your Score: {0}", myScoreToPrint);
		print(myTextToPrint);
		text.text = myTextToPrint;
	}
}

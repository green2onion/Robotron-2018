using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentEnemyControl : UnityEngine.MonoBehaviour
{
	public GameManagerControl myGameManager;
	public virtual void OnTriggerEnter2D(Collider2D hitInfo)
	{
		if (hitInfo.gameObject.tag == "Player")
		{
			print("player hit");
			myGameManager.death();
		}
	}
	
	public void OnDestroy()
	{
		myGameManager.DidIWin();
	}
	
	// Use this for initialization
	public virtual void Start()
	{
		myGameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerControl>();
	}
}

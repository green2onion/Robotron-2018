using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryEnemyControl : ParentEnemyControl
{
	private string myName = "Electrode";
	// Use this for initialization
	/*
	public override void Start()
	{
		base.Start();
	}

	// Update is called once per frame
	void Update()
	{
	}
	*/
	public override void OnTriggerEnter2D(Collider2D hitInfo)
	{
		base.OnTriggerEnter2D(hitInfo);
		if (hitInfo.tag == "Bullet")
		{
			myGameManager.AddScore(myName);
			Destroy(gameObject);
			myGameManager.DidIWin();
		}
	}
}

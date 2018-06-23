using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemyControl : ParentEnemyControl
{
	private string myName = "Grunt";
	private Transform player;
	private float moveSpeed = 1f;
	private static bool isRespawning = false;
	//private float maxDist = 20.0f;
	//private float minDist = 1.0f;
	void Chase()
	{
		transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
	}
	public static void SetIsRespawning()
	{
		isRespawning = true;
	}
	public static void SetNotRespawning()
	{
		isRespawning = false;
	}
	public override void OnTriggerEnter2D(Collider2D hitInfo)
	{
		base.OnTriggerEnter2D(hitInfo);
		if (hitInfo.tag == "Bullet")
		{
			myGameManager.AddScore(myName);
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	public override void Start()
	{
		base.Start();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		//transform.localScale = new Vector3(1, 1, 1);
		//transform.position = Vector2.zero;
	}

	// Update is called once per frame
	public virtual void Update()
	{
		if (!isRespawning)
		{
			Chase();
		}

		//transform.LookAt(player);
		/*
		if (Vector2.Distance(transform.position, player.position) >= minDist)
		{
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
			if (Vector2.Distance(transform.position, player.position) <= maxDist)
			{
				//Here Call any function U want Like Shoot at here or something
			}

		}
		*/

	}
}

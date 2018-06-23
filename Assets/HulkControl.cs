using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HulkControl : ParentEnemyControl
{
	private float tolerance = 0.5f;
	private Vector2 target;
	private float moveSpeed = 0.5f;
	private float randomTargetX;
	private float randomTargetY;
	private static bool isRespawning = false;
	public static void SetIsRespawning()
	{
		isRespawning = true;
	}
	public static void SetNotRespawning()
	{
		isRespawning = false;
	}
	void SetNewTarget()
	{
		randomTargetX = Random.Range(-4.0f, 4.0f);
		randomTargetY = Random.Range(-4.0f, 4.0f);
		target = new Vector2(transform.position.x + randomTargetX, transform.position.y + randomTargetY);
	}
	// hit wall
	void OnCollisionStay2D(Collision2D hitInfo)
	{
		//print("hello");
		if (hitInfo.gameObject.tag == "Wall")
		{
			SetNewTarget();
		}
	}
	// hit player
	void OnCollisionEnter2D(Collision2D hitInfo)
	{
		if (hitInfo.gameObject.tag == "Player")
		{
			myGameManager.death();
		}
	}
	// Use this for initialization
	public override void Start()
	{
		base.Start();
	}

	// Update is called once per frame
	void Update()
	{
		if (!isRespawning)
		{
			if (Vector2.Distance(transform.position, target) > tolerance)
			{
				transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
			}
			else
			{
				SetNewTarget();
			}
		}

	}
}

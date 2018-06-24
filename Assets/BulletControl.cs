using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : UnityEngine.MonoBehaviour
{
	private float startTime;
	private float lifeSpan = 2.0f;
	// Use this for initialization
	void Start()
	{
		startTime = Time.time;
	}
	void OnTriggerEnter2D(Collision2D hitInfo)
	{
		if (hitInfo.gameObject.tag == "Wall")
		{
			Destroy(gameObject);
		}
	}
	// Update is called once per frame
	void Update()
	{
		if (Time.time > startTime + lifeSpan)
		{
			//print("i am destroyed");
			Destroy(gameObject);
		}
	}
}

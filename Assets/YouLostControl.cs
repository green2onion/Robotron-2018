using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class YouLostControl : MonoBehaviour
{
	KeyCode restart = KeyCode.R;
	KeyCode quit = KeyCode.Escape;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(restart))
		{
			SceneManager.LoadScene("Scene1");
		}
		if (Input.GetKey(quit))
		{
			Application.Quit();
		}
	}
}

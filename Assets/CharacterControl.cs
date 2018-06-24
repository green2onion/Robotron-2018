using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CharacterControl : UnityEngine.MonoBehaviour
{
	private float walkSpeed = 3;
	// input binding
	private KeyCode walkRight = KeyCode.D;
	private KeyCode walkLeft = KeyCode.A;
	private KeyCode walkUp = KeyCode.W;
	private KeyCode walkDown = KeyCode.S;
	private KeyCode faceUp = KeyCode.UpArrow;
	private KeyCode faceDown = KeyCode.DownArrow;
	private KeyCode faceLeft = KeyCode.LeftArrow;
	private KeyCode faceRight = KeyCode.RightArrow;
	private KeyCode quit = KeyCode.Escape;
	private KeyCode fire = KeyCode.Space;
	private KeyCode restart = KeyCode.R;
	private Rigidbody2D rb2d;
	private bool isRespawning = false;

	//fire
	public GameObject myBullet;
	private GameObject tempBullet;
	private float lastShot = 0.0f;
	public float fireRate = 0.1f;
	public float bulletSpeed = 10;

	private Renderer rend;
	private CapsuleCollider2D collider;

	private void Movement()
	{
		var velocity = rb2d.velocity;
		// walk up and down
		if (Input.GetKey(walkUp))
		{
			velocity.y = walkSpeed;
		}
		else if (Input.GetKey(walkDown))
		{
			velocity.y = -walkSpeed;
		}
		else if (!Input.GetKey(walkUp) && !Input.GetKey(walkDown))
		{
			velocity.y = 0;
		}
		// walk right and left
		if (Input.GetKey(walkRight))
		{
			velocity.x = walkSpeed;
		}
		else if (Input.GetKey(walkLeft))
		{
			velocity.x = -walkSpeed;
		}
		else if (!Input.GetKey(walkRight) && !Input.GetKey(walkLeft))
		{
			velocity.x = 0;
		}
		// change real velocity
		rb2d.velocity = velocity;
	}
	private Vector2 getRotation()
	{
		Vector2 direction = new Vector2(0, 0);
		// face up and down
		if (Input.GetKey(faceUp))
		{
			direction.y = walkSpeed;
		}
		else if (Input.GetKey(faceDown))
		{
			direction.y = -walkSpeed;
		}
		// face right and left
		if (Input.GetKey(faceRight))
		{
			direction.x = walkSpeed;
		}
		else if (Input.GetKey(faceLeft))
		{
			direction.x = -walkSpeed;
		}
		return direction == Vector2.zero? new Vector2(walkSpeed, 0) : direction;
	}
	private void Quit()
	{
		if (Input.GetKey(quit))
		{
			Application.Quit();
		}
	}
	private void Restart()
	{
		if (Input.GetKey(restart))
		{
			SceneManager.LoadScene(0);
		}
	}
	public void DeactivateRenderer()
	{
		rend = GetComponent<Renderer>();
		rend.enabled = false;
		isRespawning = true;
	}
	public void DeactivateCollision()
	{
		collider = GetComponent<CapsuleCollider2D>();
		collider.enabled = false;
	}
	public void ActivateRenderer()
	{
		//rend = GetComponent<Renderer>();
		rend.enabled = true;
	}
	public void ActivateCollision()
	{
		//collider = GetComponent<CapsuleCollider2D>();
		collider.enabled = true;
	}

	private void Fire()
	{
		if (Time.time > fireRate + lastShot)
		{
			tempBullet = Instantiate(myBullet, transform.position, transform.rotation);
			tempBullet.GetComponent<Rigidbody2D>().velocity = (getRotation() * bulletSpeed);
			lastShot = Time.time;
		}
	}

	public void Reset()
	{
		transform.position = Vector2.zero;
		ActivateCollision();
		ActivateRenderer();
		isRespawning = false;
		print("i am reset!");
	}
	// Use this for initialization
	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (!isRespawning)
		{
			Movement();
			if (Input.GetKey(fire))
			{
				Fire();
			}
		}
		Restart();
		Quit();

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	 
	public float xVelocity;
	public float yVelocity;

	public int playerNum; 
	public float moveSpeed;
	public float airSpeedModifier;
	public float hoverAirSpeed; 
	public float normalAirSpeed; 
	public float jumpSpeed;
	public float minimumJumpHeight;
	public float hoverGrav;
	public float normalGrav;
	public float hoverStop; 
	public bool grounded;
	public bool inAir;
	public float jumpModifier;
	private bool canJump;
	public bool canHover;
	public KeyCode left; 
	public KeyCode right;
	public KeyCode jump;

	GameObject gameManager;
	GetSpreadSheetInfo gshi;

	SpriteRenderer sr; 
	Rigidbody2D rb; 



	// Use this for initialization
	void Start () {

		sr = GetComponent<SpriteRenderer> ();
		rb = GetComponent<Rigidbody2D> ();
		gameManager = GameObject.Find ("GameManager");
		gshi = gameManager.GetComponent<GetSpreadSheetInfo> ();
		grounded = true; 
		
	}
	
	// Update is called once per frame
	void Update () {
		playerMove (left, moveSpeed * -1); 
		playerMove (right, moveSpeed); 
		playerJump ();
//		jumpTimer = jumpValue * Time.deltaTime;

		xVelocity = rb.velocity.x;
		yVelocity = rb.velocity.y;

		moveSpeed = gshi.windNum;
		jumpSpeed = (gshi.humidNum)*jumpModifier;

	
	}
	 
	void playerMove(KeyCode key, float direction)
	{
		if (Input.GetKey(key)) 
		{
			if (inAir == false) 
			{
				rb.velocity = new Vector2 (direction, rb.velocity.y); 
			}

			if (inAir == true) 
			{
				rb.velocity = new Vector2 ((direction * airSpeedModifier), rb.velocity.y);
			}
			 
			if (key == left) 
			{
				sr.flipX = true; 
			}
			if (key == right) 
			{
				sr.flipX = false;
			}
			
		}

		if (Input.GetKeyUp (key)) {
			rb.velocity = new Vector2 (0, rb.velocity.y);
		}
			
	}

	void playerJump ()
	{
		if (Input.GetKey (jump)) 
		{
			if (grounded == true && canJump == true)
			{
				rb.velocity = new Vector2 (rb.velocity.x, jumpSpeed); 
				grounded = false;
				inAir = true;
				canJump = false;
			}
		}

		if (Input.GetKeyUp (jump) && grounded == false && rb.velocity.y >= 0 && transform.position.y >= minimumJumpHeight)
		{
			rb.velocity = new Vector2 (rb.velocity.x, 0);
		}


		if (Input.GetKeyUp (jump) && grounded == true) 
		{
			canJump = true;
		}

		if (Input.GetKey (jump) && inAir == true && canHover == true) 
		{
			airSpeedModifier = hoverAirSpeed; 
			rb.gravityScale = hoverGrav;
			rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y * hoverStop);

		}

		if (Input.GetKeyUp (jump) && inAir == true) 
		{
			airSpeedModifier = normalAirSpeed;
			rb.gravityScale = normalGrav;
			canHover = true;
		}
			


	}

	void OnCollisionEnter2D(Collision2D touched)
	{
		if (touched.gameObject.tag == "Floor") {
			grounded = true;
			inAir = false;
			canHover = false;
			airSpeedModifier = normalAirSpeed;
			rb.gravityScale = normalGrav; 
			if (!Input.GetKey (jump)) {
				canJump = true;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D touched)
	{
		if (touched.gameObject.tag == "Coin")   
		{
			ScoreManager.scoreCard.scorePoints (playerNum);
			Destroy (touched.gameObject); 
		}

		if (touched.gameObject.tag == "New York") 
		{
			gshi.cityShift ("new york", "ny");
		}

		if (touched.gameObject.tag == "Frisco") 
		{
			gshi.cityShift ("san francisco", "ca");
		}

		if (touched.gameObject.tag == "Boston") 
		{
			gshi.cityShift ("boston", "ma");
		}
		
	}

}

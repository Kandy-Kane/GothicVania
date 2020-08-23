using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


	public CharacterController2D controller;
	public Animator animator;
	 public int maxPlayerHealth = 300;
    private int currentPlayerHealth;
	private float thrust = 10.0f;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	private Rigidbody2D playerRigidBody;
	public bool invincible = false;



    void Start()
    {
        currentPlayerHealth = maxPlayerHealth;
        playerRigidBody = GetComponent<Rigidbody2D>();
        
        
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		float multiplier = 0.5f;
			if (other.gameObject.tag.Equals("Enemy"))
		{
			playerRigidBody.AddForce(-other.attachedRigidbody.velocity*multiplier);
		}
	}
		
  

   
	public void Invunerable(){

		
	}
	 public void TakeDamage(int damage){

		 if(!invincible)
		 {
			 currentPlayerHealth -= damage;
		
		/*transform.position = new Vector3(-0.1f, 0.05f, 0.5f);
		playerRigidBody.AddForce(transform.position, ForceMode2D.Force);*/
		//yield return StartCoroutine(playerRigidBody.use.Translation(gameObject.transform, Vector3.up, 0.5f, playerRigidBody.MoveType.Time));

        animator.SetTrigger("Hurt");
        if(currentPlayerHealth<=0)
        {
            Die();
        }
		invincible = true; 
		Invoke ("resetInvulerablity",1);
		 } 
		 
        
    }

	void resetInvulerablity(){
		invincible = false; 
	}

	void Die(){

	animator.SetBool("IsDead",true);
	this.enabled = false;
	Destroy(gameObject,5);
	}
	
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		animator.SetFloat("Speed",Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping",true);
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

	}
	public void OnLanding(){
		animator.SetBool("IsJumping",false);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}


public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector2 knockbackDir){
 
        float timer = 0;
 
        while( knockDur > timer){
 
            timer+=Time.deltaTime;


							if(jump == false)
							{
								playerRigidBody.AddForce(new Vector2(-knockbackDir.x * 400, -knockbackDir.y *50));
							}else if(jump==true)
							{
								playerRigidBody.AddForce(new Vector2(-knockbackDir.x * 500, knockbackDir.y + 500));
							}
					
		
            	
 
        }
 
        yield return 0;
 
    }






}

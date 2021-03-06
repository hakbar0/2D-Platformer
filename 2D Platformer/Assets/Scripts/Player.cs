﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour {

    //config
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 20f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(25f, 25f);
    [SerializeField] AudioClip death;

    //state
    bool isAlive = true;

    //cache component refrences
    Animator myAnimator;
    Rigidbody2D myRigidBody;
    CapsuleCollider2D myBodyCollider2D;
    BoxCollider2D myFeet;
    float gravityScaleAtStart;



	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider2D = GetComponent<CapsuleCollider2D>();
        myFeet = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidBody.gravityScale;
	}
	
	// Update is called once per frame
	void Update () {
        if (!isAlive) return;
        Run();
        ClimbLadder();
        FlipSprite();
        Jump();
        Die();
	}

	private void Run()
	{
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // either -1 or 1;
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);
	}

    private void ClimbLadder()
    {

        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myRigidBody.gravityScale = gravityScaleAtStart;
            myAnimator.SetBool("Climbing", false);
            return;
        }
            myRigidBody.gravityScale = 0f;
            float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
            Vector2 climbVelocity = new Vector2(myRigidBody.velocity.x, controlThrow * climbSpeed);
            myRigidBody.velocity = climbVelocity;
            bool playerVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
            myAnimator.SetBool("Climbing", playerVerticalSpeed);

    }





    private void FlipSprite(){
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon; // means greater than 0

        if (playerHasHorizontalSpeed) transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);

    }


    private void Jump()
    {

        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;

        if(CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;
        }
    }

    private void Die()
    {
        if (myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            AudioSource.PlayClipAtPoint(death, Camera.main.transform.position);
            myAnimator.SetTrigger("Dying");
            GetComponent<Rigidbody2D>().velocity = deathKick;
            isAlive = false;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }

}

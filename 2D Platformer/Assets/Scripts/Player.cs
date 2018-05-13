using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour {

    //config
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 20f;

    //state
    bool isAlive = true;

    //cache component refrences
    Animator myAnimator;
    Rigidbody2D myRigidBody;
    Collider2D myCollider2D;



	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider2D = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Run();
        FlipSprite();
        Jump();
	}

	private void Run()
	{
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // either -1 or 1;
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
	}

    private void FlipSprite(){
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon; // means greater than 0

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
            myAnimator.SetBool("Running", true);
        }

        else myAnimator.SetBool("Running", false);

    }


    private void Jump()
    {

        if (!myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;

        if(CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += jumpVelocityToAdd;
        }
    }

}

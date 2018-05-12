using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour {

    Rigidbody2D myRigidBody;
    [SerializeField] float runSpeed = 5f;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Run();
	}

	private void Run()
	{
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // either -1 or 1;
        Vector2 playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomJump : MonoBehaviour {

    [SerializeField] float mushroomJump = 30f;
    [SerializeField] bool isCollision = false;

    Rigidbody2D myRigidBody;
    CapsuleCollider2D myBodyCollider2D;

	private void OnTriggerStay2D(Collider2D collision)
	{
        myRigidBody = collision.GetComponent<Rigidbody2D>();
        myBodyCollider2D = collision.GetComponent<CapsuleCollider2D>();
        Vector2 jumpVelocityToAdd = new Vector2(0f, mushroomJump);
        myRigidBody.velocity += jumpVelocityToAdd;

	}
}

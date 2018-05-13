using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    //config
    [SerializeField] float moveSpeed = 0.02f;

    //cache component refrences
    Rigidbody2D myRigidBody;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update () {
        MoveEnemy();
	}

    private void MoveEnemy(){
        myRigidBody.velocity = new Vector2(moveSpeed, 0f);
    }
}

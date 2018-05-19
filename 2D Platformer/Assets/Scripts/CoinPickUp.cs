using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour {

    [SerializeField] AudioClip coinPickUpSFX;
    [SerializeField] int coinScore = 50;

	private void OnTriggerEnter2D(Collider2D collision)
	{
        AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
        FindObjectOfType<GameSession>().AddToScore(coinScore);
        Destroy(gameObject);
	}

}

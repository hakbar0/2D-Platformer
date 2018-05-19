﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour {

    [SerializeField] int playerLives = 3;

    private void Awake()
    {
        int numberOfSessions = FindObjectsOfType<GameSession>().Length;
        if (numberOfSessions > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
		
	}

    public void ProcessPlayerDeath(){
        if (playerLives > 1) TakeLife();
        else ResetGameSession();
    }

    public void TakeLife()
    {
        playerLives--;
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    private void ResetGameSession(){
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
	

}

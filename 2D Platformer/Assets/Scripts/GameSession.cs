using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {

    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;

    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;

    private void Awake()
    {
        int numberOfSessions = FindObjectsOfType<GameSession>().Length;
        if (numberOfSessions > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
	}

    public void ProcessPlayerDeath(){
        if (playerLives > 1) TakeLife();
        else ResetGameSession();
    }

    public void AddToScore(int pointsToAdd){
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    public void TakeLife()
    {
        playerLives--;
        livesText.text = playerLives.ToString();
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    private void ResetGameSession(){
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
	

}

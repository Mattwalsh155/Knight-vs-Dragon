﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject menu;
    public GameObject game;
    public GameObject pause;
    public GameObject gameOver;
    public GameObject instructions; 

    public int timer;
    public bool turn;
    public enum gameStates { MENU,GAMEPLAY,PAUSE }
    public gameStates GameStates;

    public Player[] players;

    public int turns = 0;

    public bool isGameOver = false;

    // Use this for initialization
    void Start () {
        game.SetActive(false);
        menu.SetActive(true);
        pause.SetActive(false);
        gameOver.SetActive(false);
        instructions.SetActive(false);

        players[0].playersTurn = true;
        players[1].playersTurn = false;

	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKey(KeyCode.P))
        {
            PauseGame();
        }

        if (players[0].playersTurn == true)
        {
            players[0].currentTurn.text = "Player 1's turn";
        }
        else if (players[1].playersTurn == true)
        {
            players[1].currentTurn.text = "Player 2's turn";
        }
	}

    public void PlayerMoving()
    {
        for(int i = 0; i < players.Length; i++)
        {
            players[i].hasShot = false;
        }
        for (int i = 0; i < players.Length; i++)
        {
            players[i].powerShow.text = "FirePower: 0";
        }
    }

    public void StartGame()
    {
        menu.SetActive(false);
        game.SetActive(true);
        pause.SetActive(false);
        gameOver.SetActive(false);
        instructions.SetActive(false);

    }

    public void InstructionsScreen()
    {
        menu.SetActive(false);
        game.SetActive(false);
        pause.SetActive(false);
        gameOver.SetActive(false);
        instructions.SetActive(true);
    }

    public void GameOver()
    {
        if (players[0].startingHealth <= 0)
        {
            players[0].winningPlayer.text = "Player 2 Wins!!";
        }
        else if (players[1].startingHealth <= 0)
        {
            players[1].winningPlayer.text = "Player 1 Wins!!";
        }

        gameOver.SetActive(true);
        isGameOver = true;
    }

    public void RestartGame()
    {
        game.SetActive(false);
        menu.SetActive(true);
        pause.SetActive(false);
        gameOver.SetActive(false);
        instructions.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        menu.SetActive(false);
        game.SetActive(false);
        pause.SetActive(true);
        gameOver.SetActive(false);
        instructions.SetActive(false);
    }

    public void QuitGame()
    {
        menu.SetActive(true);
        game.SetActive(false);
        pause.SetActive(false);
        gameOver.SetActive(false);
        instructions.SetActive(false);
        SceneManager.LoadScene(0);
    }
}

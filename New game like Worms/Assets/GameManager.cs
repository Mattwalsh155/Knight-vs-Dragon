using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject menu;
    public GameObject game;
    public GameObject pause;

    public int timer;
    public bool turn;
    public enum gameStates { MENU,GAMEPLAY,PAUSE}
    public gameStates GameStates;


	// Use this for initialization
	void Start () {
        game.SetActive(false);
        menu.SetActive(true);
        pause.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKey(KeyCode.P))
        {
            PauseGame();
        }
	}

    public void StartGame()
    {
        menu.SetActive(false);
        game.SetActive(true);
        pause.SetActive(false);
   
    }

    public void RestartGame()
    {
        
    }

    public void PauseGame()
    {
        menu.SetActive(false);
        game.SetActive(false);
        pause.SetActive(true);
    }

    public void QuitGame()
    {
        menu.SetActive(true);
        game.SetActive(false);
        pause.SetActive(false);
        SceneManager.LoadScene(0);
    }
}

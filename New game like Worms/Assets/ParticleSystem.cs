using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystem : MonoBehaviour {

    private Player player;
    private Player playerTwo;
    private GameManager gameManager;

    private bool firstHit = false;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<Player>();
        playerTwo = GameObject.Find("PlayerTwo").GetComponent<Player>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "obstacles")
        {
            Destroy(other.gameObject);
        }
        //boolean firstHit private make false to start. wrap damage in an if statement
        if (firstHit == false)
        {
        
            if (other.gameObject.name == "Player")
            {
                //Debug.Log("yay");
                player.GetComponent<Player>().startingHealth -= 10;
                player.playerHealth.text = player.startingHealth.ToString();
                firstHit = true;
            }
            else if (other.gameObject.name == "PlayerTwo")
            {
                //Debug.Log("yay");
                playerTwo.GetComponent<Player>().startingHealth -= 10;
                playerTwo.playerHealth.text = playerTwo.startingHealth.ToString();
                firstHit = true;
            }
        }
        if (player.startingHealth <= 0)
        {
            gameManager.GameOver();
        }

    }
}

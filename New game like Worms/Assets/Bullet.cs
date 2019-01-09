using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public GameObject explosion;

    private GameManager gameManager;

    void Start()
    {
        explosion.gameObject.SetActive(false);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void turnManager()
    {
        if (gameManager.turns == 0)
        {
            gameManager.players[gameManager.turns].playersTurn = false;
            gameManager.turns++;
            gameManager.players[gameManager.turns].playersTurn = true;
        }
        else
        {
            gameManager.players[gameManager.turns].playersTurn = false;
            gameManager.turns--;
            gameManager.players[gameManager.turns].playersTurn = true;
        }

        gameManager.PlayerMoving();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "walls")
        {
            explosion.gameObject.transform.parent = null;
            explosion.gameObject.SetActive(true);

            turnManager();
            Destroy(this.gameObject);
        }

        else if (collision.gameObject.tag == "obstacles")
        {
            explosion.gameObject.transform.parent = null;
            explosion.gameObject.SetActive(true);

            Destroy(collision.gameObject);

            turnManager();
            Destroy(this.gameObject);

        }

        else if (collision.gameObject.name == "Player" || collision.gameObject.name == "PlayerTwo")
        {
            explosion.gameObject.transform.parent = null;
            explosion.gameObject.SetActive(true);

            turnManager();
            Destroy(this.gameObject);

           
        }
    }
}

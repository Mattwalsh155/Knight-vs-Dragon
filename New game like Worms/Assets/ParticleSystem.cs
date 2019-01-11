using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystem : MonoBehaviour {

     GameObject player;

	// Use this for initialization
	void Start () {
		
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

        else if (other.gameObject.name == "Player" || other.gameObject.name == "PlayerTwo")
        {
            //player.GetComponent<Player>().startingHealth -= 10;
            //player.playerHealth.text = player.startingHealth.ToString();
        }

       //Debug.Log("yay");
        
    }
}

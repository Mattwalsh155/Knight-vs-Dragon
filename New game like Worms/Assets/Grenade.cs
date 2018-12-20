using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {
    private int bounces = 0;

    public GameObject explosion;

    void Start()
    {
        explosion.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        bounces++;

        if (collision.gameObject.tag == "obstacles" && bounces > 3)
        {
            explosion.gameObject.transform.parent = null;
            explosion.gameObject.SetActive(true);

            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            
           
        }
        else if (bounces > 3)
        {
            explosion.gameObject.transform.parent = null;
            explosion.gameObject.SetActive(true);

            Destroy(this.gameObject);
         
        }

        else if (collision.gameObject.name == "Player" || collision.gameObject.name == "PlayerTwo")
        {
            explosion.gameObject.transform.parent = null;
            explosion.gameObject.SetActive(true);

            Destroy(this.gameObject);
        }
    }
}

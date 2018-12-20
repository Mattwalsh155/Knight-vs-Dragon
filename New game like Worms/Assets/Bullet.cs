using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
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
        if (collision.gameObject.tag == "walls")
        {
            explosion.gameObject.transform.parent = null;
            explosion.gameObject.SetActive(true);

            Destroy(this.gameObject);
        }

        else if (collision.gameObject.tag == "obstacles")
        {
            explosion.gameObject.transform.parent = null;
            explosion.gameObject.SetActive(true);

            Destroy(collision.gameObject);
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

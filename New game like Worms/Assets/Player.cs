using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Rigidbody player;
    public bool isJumping = false;
    private float xVelocity = 0;
    private float yVelocity = 0;
    private float maxSpeed = 10;
    private float direction = 1;

    public Camera mainCam;

    public GameObject bullet;
    public Transform bulletSpawn;
    public Transform spawnUpLimit;
    public Transform reverseLoc;

    public GameObject grenade;
    public GameObject arrow;
    public GameObject pSprite;

    public float rotationMax = 0.5f;
    public float rotationMin = 0;

    public float power = 0;
    public float powerMax = 5;


    

	// Use this for initialization
	void Start () {
        
        bullet.gameObject.SetActive(true);
        grenade.gameObject.SetActive(false);
        arrow.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.D))
        {
            xVelocity += 1f;
            direction = 1;
            pSprite.transform.localScale = new Vector3(1, 1, 1);
            //bulletSpawn.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            xVelocity -= 1f;
            direction = -1;
            pSprite.transform.localScale = new Vector3(-1, 1, 1);
            //bulletSpawn.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            xVelocity = 0;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            
            //bulletSpawn.Rotate(new Vector3(0, , 0));
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
           // transform.Rotate(new Vector3(0, -180, 0));
        }

        if (Mathf.Abs(xVelocity) > maxSpeed)
        {
            xVelocity = maxSpeed * direction;
        }

        player.velocity = new Vector3(xVelocity, player.velocity.y, 0);
		
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            player.AddForce(Vector3.up * 3000);
        }

        if (Input.GetKeyUp(KeyCode.F))
        {

            if (grenade.gameObject == true)
            {
                ShootingGrenade();

            }

            if (bullet.gameObject == true)
            {
                ShootingBullet();

            }

            power = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
           
            bullet.gameObject.SetActive(false);
            grenade.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
           
            bullet.gameObject.SetActive(true);
            grenade.gameObject.SetActive(false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            //Debug.Log("bulletSpawn.transform.rotation.x : "+ bulletSpawn.transform.rotation.x);
            //Debug.Log("rotationMax : " + rotationMax);
            if (bulletSpawn.transform.rotation.x > -rotationMax)
            {
                if(direction == 1)
                {
                    bulletSpawn.Rotate(Vector3.left, 1, Space.Self);
                }
                else
                {
                    bulletSpawn.Rotate(Vector3.right, 1, Space.Self);
                }
                
            }
          
            arrow.gameObject.SetActive(true);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            // Debug.Log(direction);
             if (bulletSpawn.transform.rotation.x < rotationMin)
             {
            
                if (direction == 1)
                {
                    bulletSpawn.Rotate(Vector3.right, 1, Space.Self);
                }
                else
                {
                    bulletSpawn.Rotate(Vector3.left, 1, Space.Self);
                }
             }
           
            arrow.gameObject.SetActive(true);
          
        }
        else if (Input.GetKey(KeyCode.F))
        {
            arrow.gameObject.SetActive(true);

            power += Time.deltaTime;

            if (power > powerMax)
            {
                power = powerMax;
            }

        }
        else
        {
            arrow.gameObject.SetActive(false);
        }

    }

    void ShootingBullet()
    {
        
        GameObject temp = Instantiate(bullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        temp.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 1500 * power);
    }

    void ShootingGrenade()
    {
        
        GameObject temp = Instantiate(grenade, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        temp.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 15000 * power);
    }
}

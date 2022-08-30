using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private GameController gameController;

    private Rigidbody myRigidbody;

    [HideInInspector]
    public bool playerIsDead = false;

    [SerializeField]
    private GameObject deathEffect;

    [SerializeField]
    private float moveSpeed = 10f;

    [SerializeField]
    private float speed = 20f;
    private float maxSpeed = 100f;

    [SerializeField]
    private float timer;
    private float timeBtwIncreaseSpeed = 6f;
    private float increaseSpeed = 5f;

    [SerializeField]
    private float jumpForce;

    // Use this for initialization
    void Start ()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(timer >= timeBtwIncreaseSpeed && speed <= maxSpeed)
        {
            timer = 0;
            speed += increaseSpeed;
        }
        else
        {
            timer += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.AddForce(new Vector3(0, jumpForce, 0));
        }
    }

    void FixedUpdate()
    {
        float moveH = Input.GetAxisRaw("Horizontal");
        HandleMovements(moveH);
    }

    private void HandleMovements(float moveH)
    {
        myRigidbody.velocity = new Vector3(moveH * moveSpeed, myRigidbody.velocity.y, speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            myRigidbody.velocity = Vector3.zero;
            speed = 0f;
            playerIsDead = true;
            GetComponent<MeshRenderer>().enabled = false;
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
    }
}

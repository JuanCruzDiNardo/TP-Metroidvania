using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public float jumpForce = 10;
    public float speed = 5;
    public float jumps = 1;
    public Estados estado = Estados.idle;

    public static bool dobleJump = false;
    public static bool Hook = false;
    public static int keyCount;
    public GameObject EnemyinRange;
    
    public Rigidbody rb;

    public Range_Controller attackRange;

    public bool lookingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Time.timeScale = 1;
    }

    public virtual void FixedUpdate()
    {
        if (estado != Estados.attack)
            Movement();
    }

    // Update is called once per frame
    private void Update()
    {
        if (estado != Estados.attack)
        {
            Jump();
            //Duck();
            Atack();
        }
    }

    private void OnDestroy()
    {
        Time.timeScale = 0;
    }

    private void Atack()
    {
        if (Input.GetKey(KeyCode.E) && rb.velocity.y == 0)
        {
            estado = Estados.attack;

            if(EnemyinRange != null)
            {
                Destroy(EnemyinRange);
            }
        }
    }

    private void Duck()
    {
        
    }


    private void Movement()
    {        
        if (Input.GetKey(KeyCode.A))
        {

            rb.velocity = new Vector3(1 * -speed, rb.velocity.y, 0);
            lookingRight = false;
            estado = Estados.run;

        }
        else if (Input.GetKey(KeyCode.D))
        {


            rb.velocity = new Vector3(1 * speed, rb.velocity.y, 0);
            lookingRight = true;
            estado = Estados.run;
        }

        if (rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            estado = Estados.idle;
        }
        
    }

    public virtual void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            if(rb.velocity.y >= 0 || dobleJump || Hook)
            {
                if (jumps > 0)
                {
                    rb.velocity = new Vector3(rb.velocity.x, 0, 0);
                    rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                    jumps--;
                }
            }


        }
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            if (dobleJump)
                jumps = 2;
            else
                jumps = 1;
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            if (Hook)
            {
                if (dobleJump)
                    jumps = 2;
                else
                    jumps = 1;
            }

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            //jumps--;
        }


    }

}

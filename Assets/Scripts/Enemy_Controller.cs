using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject attackRange;
    public EnemyRange_Controler enemyRange;

    public float atkTime;
    public float speed = 5;
    public bool lookingRight = false;
    public bool attacking = false;
    
    private void Awake()
    { 

    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        PLayerFound();
        Attack();
    }

    protected virtual void Movement()
    {
        if (!attacking)
        {
            if (lookingRight)
                rb.velocity = new Vector3(1 * speed, rb.velocity.y, 0);
            else if (!lookingRight)
                rb.velocity = new Vector3(1 * -speed, rb.velocity.y, 0);
        }
    }

    protected void PLayerFound()
    {
        if (enemyRange.playerInRange && !attacking)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            rb.velocity = new Vector3( rb.velocity.x/2, rb.velocity.y, 0);
            attacking = true;
            atkTime += 2;            
        }
    }

    protected virtual void Attack()
    {
        if (attacking)
        {

            atkTime -= Time.deltaTime;

            if (atkTime <= 0)
            {
                if(enemyRange.playerInRange)
                    Destroy(GameObject.FindGameObjectWithTag("Player"));

                rb.constraints = RigidbodyConstraints.FreezeRotation;
                enemyRange.playerInRange = false;
                attacking = false;                
                atkTime = 0;
            }
        }
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Enemy"))
        {
            lookingRight = !lookingRight;
            this.transform.Rotate(new Vector3(0,180,0));
        }
    }

}

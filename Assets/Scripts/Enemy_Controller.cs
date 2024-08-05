using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject attackRange;
    public EnemyRange_Controler enemyRange;
    public Estados estado = Estados.e_idle;

    public Player_controller player;

    public float atkTime;
    public float HP = 3;
    public float speed = 5;
    public float damage = 2;
    public bool lookingRight = false;
    public bool attacking = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if(estado != Estados.e_damage)
        Movement();
        PLayerFound();
        Attack();
        CheckLimits();
    }

    protected virtual void Movement()
    {
        if (!attacking)
        {
            if (lookingRight)
                rb.velocity = new Vector3(1 * speed, rb.velocity.y, 0);
            else if (!lookingRight)
                rb.velocity = new Vector3(1 * -speed, rb.velocity.y, 0);

            estado = Estados.e_walk;
        }
    }

    protected void PLayerFound()
    {
        if (enemyRange.playerInRange && !attacking)
        {
            //rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
            rb.velocity = new Vector3( rb.velocity.x/2, rb.velocity.y, 0);
            attacking = true;
            atkTime += 1;
            
        }
    }

    protected virtual void Attack()
    {
        if (attacking)
        {
            estado = Estados.e_attack;

            atkTime -= Time.deltaTime;

            if (atkTime <= 0)
            {
                if (enemyRange.playerInRange)
                    player.RecibirDanio(damage);

                rb.constraints = RigidbodyConstraints.FreezeRotation;
                //enemyRange.playerInRange = false;
                attacking = false;                
                atkTime = 0;
            }
        }
    }

    public void RecibirDanio(float dmg)
    {
        HP -= dmg;
        estado = Estados.e_damage;
        rb.velocity = new Vector3(0, 0, 0);
        if (lookingRight)
            rb.AddForce(new Vector3(-5, 2, 0), ForceMode.Impulse);
        else
            rb.AddForce(new Vector3(5, 2, 0), ForceMode.Impulse);

        if (HP < 1)
            Morir();
    }

    public void Morir()
    {
        this.enabled = false;
        rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        rb.detectCollisions = false;
        estado = Estados.e_dead;

    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Enemy"))
        {
            lookingRight = !lookingRight;
            this.transform.Rotate(new Vector3(0,180,0));
        }
    }

    public void CheckLimits()
    {
        if (this.transform.position.y < -30)
        {
            Destroy(this.gameObject);
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller1 : MonoBehaviour
{
    public float speed = 5;

    public Rigidbody rb;

    public GameObject attackRange;
    private GameObject range = null;

    public EnemyRange_Controler1 enemyRange;

    public bool lookingRight = false;
    public bool playerInRange = false;
    public bool attacking = false;
    public float atkTime = 0;
    private Vector3 offset;

    //public static List <Enemy_Controller> _Enemys;

    //public static Enemy_Controller _Enemy;

    private void Awake()
    {        

        //if (_Enemy == null)
        //{
        //    //_Enemy = GameObject.FindObjectOfType<Enemy_Controller>();
        //    //if (_Enemy == null)
        //    //{
        //    //    GameObject container = new GameObject("Player");
        //    //    _Enemy = container.AddComponent<Enemy_Controller>();
        //    //}

        //    //DontDestroyOnLoad(_Enemy);
        //}
        //else
        //{
        //    //Destroy(this.gameObject);
        //}

        //_Enemys.Add(GameObject.FindObjectOfType<Enemy_Controller>());
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //ShowRange();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        //MoveRange();
        //Checkrange();
        PLayerFound();
        attack();
    }

    private void OnDestroy()
    {
        playerInRange = false;
    }

    private void MoveRange()
    {
        if (lookingRight)
            range.transform.position = this.transform.position - offset;
        else if (!this.lookingRight)
           range.transform.position = this.transform.position + offset;
    }

    private void Checkrange()
    {
        if(range != null)
        {
            //playerInRange = range;
        }
    }

    private void Movement()
    {
        if (!attacking)
        {
            if (lookingRight)
                rb.velocity = new Vector3(1 * speed, rb.velocity.y, 0);
            else if (!lookingRight)
                rb.velocity = new Vector3(1 * -speed, rb.velocity.y, 0);
        }
    }

    private void PLayerFound()
    {
        if (enemyRange.playerInRange && !attacking)
        {
            rb.velocity = new Vector3( rb.velocity.x/2, rb.velocity.y, 0);
            attacking = true;
            atkTime += 2;            
        }
    }

    private void attack()
    {
        if (attacking)
        {
            atkTime -= Time.deltaTime;

            if (atkTime <= 0)
            {
                if(enemyRange.playerInRange)
                    Destroy(GameObject.FindGameObjectWithTag("Player"));                

                enemyRange.playerInRange = false;
                attacking = false;                
                atkTime = 0;
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            lookingRight = !lookingRight;
            this.transform.Rotate(new Vector3(0,180,0));
        }
    }

    private void ShowRange()
    {        
        range = Instantiate(attackRange, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
        offset = new Vector3(this.transform.position.x - range.transform.position.x, this.transform.position.y - range.transform.position.y, this.transform.position.z - range.transform.position.z);

        Projectile_Controller projectile = new Projectile_Controller();

        if (enemyRange.playerInRange)
        {

        }
    }
}

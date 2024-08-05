using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range_Controller : MonoBehaviour
{

    public Player_controller parent;

    public bool EnemyinRange;

    public Enemy_Controller Enemy;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(parent.transform.position.x - this.transform.position.x, parent.transform.position.y - this.transform.position.y, parent.transform.position.z - this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void FixedUpdate()
    {
        Movement();
        CheckRange();
    }

    private void CheckRange()
    {
        parent.EnemyinRange = Enemy;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            EnemyinRange = true;
            Enemy = collider.gameObject.GetComponent<Enemy_Controller>();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            EnemyinRange = false;
            Enemy = null;
        }
    }

    private void Movement()
    {
        if (parent != null)
        {
            if (parent.lookingRight)
                transform.position = parent.transform.position - offset;
            else if (!parent.lookingRight)
                transform.position = parent.transform.position + offset;

        }
    }
}

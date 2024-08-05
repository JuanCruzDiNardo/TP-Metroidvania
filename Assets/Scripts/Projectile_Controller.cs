using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Controller : MonoBehaviour
{
    public float xLimit;

    public float projectileSpeed;

    public float projectileDMG;

    public bool lookingRight;

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        xLimit = this.transform.position.x + 15;
    }

    public void Update()
    {
        CheckLimits();
        ProjectileDirection();
    }

    public void ProjectileDirection()
    {
        if (lookingRight)
            rb.velocity = new Vector3(1 * projectileSpeed, 0, 0);
        else
            rb.velocity = new Vector3(-1 * projectileSpeed, 0, 0);
    }

    private void CheckLimits()
    {
        if (this.transform.position.x > xLimit)
        {
            Destroy(this.gameObject);
        }
        if (this.transform.position.x < -xLimit)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Player_controller player = collision.gameObject.GetComponent<Player_controller>();

            player.RecibirDanio(projectileDMG);
        }
    }

}

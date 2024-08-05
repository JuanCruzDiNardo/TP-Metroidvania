using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeEnemy_Controller : Enemy_Controller
{
    public float turnTime = 5;
    public Projectile_Controller projectile;
    public Projectile_Controller porjectileObj;

    protected override void Movement()
    {
        if (!attacking && !enemyRange.playerInRange)
        {
            turnTime -= Time.deltaTime;

            estado = Estados.e_idle;

            if (turnTime <= 0)
            {
                this.transform.Rotate(new Vector3(0, 180, 0));
                lookingRight = !lookingRight;
                turnTime = 5;
            }
        }
    }

    protected override void Attack()
    {
        if (attacking)
        {
            estado = Estados.e_range_attack;

            atkTime -= Time.deltaTime;

            if (atkTime <= 0)
            {
                Vector3 projectileSpawn;

                if (lookingRight)
                    projectileSpawn = new Vector3(transform.position.x + 1, transform.position.y + (float)0.5, 0);
                else
                    projectileSpawn = new Vector3(transform.position.x - 1, transform.position.y + (float)0.5, 0);

                if (enemyRange.playerInRange)
                {
                    porjectileObj = Instantiate(projectile, projectileSpawn, Quaternion.identity);
                    porjectileObj.lookingRight = this.lookingRight;
                    projectile.projectileDMG = damage;

                    atkTime += 1.2f;
                }
                else
                {
                    attacking = false;
                    atkTime = 0;
                }
            }
        }
    }

}

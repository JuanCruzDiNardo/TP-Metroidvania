using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy_Animation_Manager : MonoBehaviour
{
    public List<Animation_Sheet> animations = new List<Animation_Sheet>();
    public Animation_Sheet currentAnimation;
    public Enemy_Controller Enemy;
    public bool direccionActual;
    public bool animationLock;

    // Start is called before the first frame update
    void Start()
    {
        animations = (GetComponents<Animation_Sheet>().ToList<Animation_Sheet>());
        Enemy = GetComponent<Enemy_Controller>();
        currentAnimation = animations.Find(x => x.nombre == Enemy.estado);
        currentAnimation.AnimationStart();
    }

    // Update is called once per frame
    void  Update()
    {
        
        if (currentAnimation.nombre != Estados.e_damage)
            CheckEstado();
        else if (currentAnimation.loopended)
        {
            Enemy.estado = Estados.e_idle;
            CheckEstado();
        }
            

    }



    private void CheckEstado()
    {
        if(Enemy.estado != currentAnimation.nombre)
        {
            currentAnimation.AnimationStop();
            currentAnimation = animations.Find(x => x.nombre == Enemy.estado);
            currentAnimation.AnimationStart();
            
        }
    }
}



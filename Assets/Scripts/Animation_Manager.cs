using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Animation_Manager : MonoBehaviour
{
    public List<Animation_Sheet> animations = new List<Animation_Sheet>();
    public Animation_Sheet currentAnimation;
    public Player_controller player;
    public bool direccionActual;
    public bool animationLock;

    // Start is called before the first frame update
    void Start()
    {
        animations = (GetComponents<Animation_Sheet>().ToList<Animation_Sheet>());
        player = GetComponent<Player_controller>();
        currentAnimation = animations.Find(x => x.nombre == player.estado);
        currentAnimation.AnimationStart();
        direccionActual = player.lookingRight;

    }

    // Update is called once per frame
    void  Update()
    {

        if (!animationLock)
        {
            CheckEstado();
            CheckDireccion();
        }else if(animations.Find(x => x.nombre == Estados.attack).loopended)
        {
            animationLock = false;
            animations.Find(x => x.nombre == Estados.attack).loopended = false;
            player.estado = Estados.idle;
            CheckEstado();
        }else if (animations.Find(x => x.nombre == Estados.damaged).loopended)
        {
            animationLock = false;
            animations.Find(x => x.nombre == Estados.damaged).loopended = false;
            player.estado = Estados.idle;
            CheckEstado();
        }

        if(player.HP < 1)
        {
            player.estado = Estados.dead;
            CheckEstado();
        }

    }

    private void CheckDireccion()
    {
        if (direccionActual != player.lookingRight) 
        {
            direccionActual = player.lookingRight;
            currentAnimation.spriteRenderer.flipX = !currentAnimation.spriteRenderer.flipX;
        }
    }

    private void CheckEstado()
    {
        if(player.estado != currentAnimation.nombre)
        {
            currentAnimation.AnimationStop();
            currentAnimation = animations.Find(x => x.nombre == player.estado);
            currentAnimation.AnimationStart();
            if(currentAnimation.nombre == Estados.attack || currentAnimation.nombre == Estados.damaged)
            {                
                animationLock = true;
            }
        }
    }
}



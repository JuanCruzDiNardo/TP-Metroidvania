using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeBar_Controller : MonoBehaviour
{
    public float vidaMax;
    public Image barraDeVida;
    public Image barraDeFondo;
    public Player_controller Player;

    // Start is called before the first frame update
    void Start()
    {        
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_controller>();
        vidaMax = Player.HP;
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarVida();
    }

    private void ActualizarVida()
    {
        barraDeVida.fillAmount = Player.HP / vidaMax;

        if (Player.HP < 1)
            ApagarBarra();
    }

    private void ApagarBarra()
    {
        barraDeVida.gameObject.SetActive(false);
        barraDeFondo.gameObject.SetActive(false);
    }
}

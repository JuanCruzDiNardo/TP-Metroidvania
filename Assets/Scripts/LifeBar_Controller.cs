using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar_Controller : MonoBehaviour
{
    public float vidaMax;    
    public Image barraDeVida;
    public Image barraDeFondo;
    public Enemy_Controller Enemy;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponent<Enemy_Controller>();
        vidaMax = Enemy.HP;
    }

    // Update is called once per frame
    void Update()
    {
        ActualizarVida();        
    }

    private void ActualizarVida()
    {
        barraDeVida.fillAmount = Enemy.HP / vidaMax;

        if (Enemy.HP < 1)
            ApagarBarra();
    }

    private void ApagarBarra()
    {
        barraDeVida.gameObject.SetActive(false);
        barraDeFondo.gameObject.SetActive(false);
    }
}

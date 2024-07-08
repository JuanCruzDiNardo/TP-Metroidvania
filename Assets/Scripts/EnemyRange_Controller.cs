using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange_Controler : MonoBehaviour
{
    public bool playerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void FixedUpdate()
    {
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            //Enemy_Controller.playerInRange = true;

            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            //Enemy_Controller.playerInRange = false;

            playerInRange = false;
        }
    }

}

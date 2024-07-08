using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal_Controller : MonoBehaviour
{
    public int index;
    public bool onPortal;

    // Update is called once per frame
    void Update()
    {
        Teleport();
    }

    private void Teleport()
    {
        if (onPortal && Input.GetKeyDown(KeyCode.Q))
            SceneManager.LoadScene(index);
            
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onPortal = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onPortal = false;
        }
    }
}

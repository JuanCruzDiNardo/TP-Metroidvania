using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Material verde;
    public Material naranja;
    public Material pared;
    public bool test = true;
    public MeshRenderer render;
    public static Scene currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        ReStart();
        ToggleHitBoxs();
        ChangeEscene();
    }

    private void ChangeEscene()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
                 SceneManager.LoadScene("PLayTest");
            if (Input.GetKeyDown(KeyCode.Alpha1))
                SceneManager.LoadScene("Nivel1");
            if (Input.GetKeyDown(KeyCode.Alpha2))
                SceneManager.LoadScene("Nivel2");
            if (Input.GetKeyDown(KeyCode.Alpha3))
                SceneManager.LoadScene("Nivel3");            
        }
        currentScene = SceneManager.GetActiveScene();
    }

    private void ToggleHitBoxs()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            test = !test;

            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("HitBoxRef"))
            {
                obj.GetComponent<MeshRenderer>().enabled = !obj.GetComponent<MeshRenderer>().enabled;
            }

            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Wall"))
            {
                render = obj.GetComponent<MeshRenderer>();

                if(test)
                    render.material = verde;
                else 
                    render.material = pared;
            }
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Floor"))
            {
                render = obj.GetComponent<MeshRenderer>();

                if (test)
                    render.material = naranja;
                else
                    render.material = pared;
            }
        }

    }

    private void ReStart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(currentScene.name);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookBuff_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player_controller.Hook = true;
            Destroy(this.gameObject);
        }
    }

}
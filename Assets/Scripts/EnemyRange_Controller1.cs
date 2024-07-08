using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange_Controler1 : MonoBehaviour
{
    public Enemy_Controller parent;

    public GameObject tparet; 

    public int enemyCount = 0;
    private Vector3 offset;

    public bool playerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        //parent = Enemy_Controller._Enemys[enemyCount];
        //enemyCount++;
        //parent = Enemy_Controller._Enemy;
       // offset = new Vector3(parent.transform.position.x - this.transform.position.x, parent.transform.position.y - this.transform.position.y, parent.transform.position.z - this.transform.position.z);

        parent = GetComponent<Enemy_Controller>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        playerInRange = false;
    }

    public virtual void FixedUpdate()
    {
        if (parent != null)
        {
            if (parent.lookingRight)
                transform.position = parent.transform.position - offset;
            else if (!parent.lookingRight)
                transform.position = parent.transform.position + offset;

        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            //parent.playerInRange = true;

            //Enemy_Controller.playerInRange = true;
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            //parent.playerInRange = false;

            //Enemy_Controller.playerInRange = false;
            playerInRange = false;
        }
    }

}

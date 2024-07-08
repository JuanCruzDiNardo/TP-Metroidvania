using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Controller : MonoBehaviour
{
    public bool triggered;
    public bool closed;
    public Direction direction;
    public int distance;    
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            movement();
        }
    }


    private void movement()
    {
        int dir;

        if (closed)
            dir = -1;
        else 
            dir = 1;

        if(direction == Direction.up)
        {
            rb.transform.position = new Vector3(rb.position.x, rb.position.y + (dir * distance), 0);
        }
        else if (direction == Direction.down)
        {
            rb.transform.position = new Vector3(rb.position.x, rb.position.y - (dir * distance), 0);
        }
        else if (direction == Direction.right)
        {
            rb.transform.position = new Vector3(rb.position.x + (dir * distance), rb.position.y, 0);
        }
        else if(direction == Direction.left)
        {
            rb.transform.position = new Vector3(rb.position.x - (dir * distance), rb.position.y, 0);
        }

        triggered = false;
        closed = !closed;
    }

}

public enum Direction
{
    up,
    down,
    left,
    right,
}

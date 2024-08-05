using UnityEngine;

public class Parallax : MonoBehaviour
{
    public static bool gameOver = false;
    public GameObject cam;
    private float length, startPos;
    public float parallaxEffect;   
    void Start()
    {
        startPos = transform.position.x; 
        length = GetComponent<SpriteRenderer>().bounds.size.x; 
        parallaxEffect /= 2;
    }

    void Update()
    {
        if (!gameOver)
        {
            
            transform.position = new Vector3(transform.position.x - parallaxEffect, transform.position.y, transform.position.z);
            if (cam.transform.localPosition.x < cam.transform.localPosition.x - 20)
            {                
                transform.localPosition = new Vector3(cam.transform.localPosition.x + 20, transform.localPosition.y, transform.localPosition.z);
            }
        }
    }
}
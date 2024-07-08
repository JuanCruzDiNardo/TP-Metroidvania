using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public GameObject player;
    private Camera _camera;

    public float dampTime = 0.15f;
    public float smoothTime = 2f;
    public float zoomvalue;
    private Vector3 velocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 point = _camera.WorldToViewportPoint(player.transform.position);
            Vector3 delta = player.transform.position - _camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }

    }
}

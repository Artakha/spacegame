using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float speed;
    public float minZoom;
    public float maxZoom;
    public float scrollSpeed;
    public float bounds;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 zoom = transform.position;

        if (zoom.z > -15)
        {
            speed = 0.125f;
        }
        else if (zoom.z <= -15 && zoom.z > -60)
        {
            speed = 0.25f;
        }
        else if (zoom.z <= -60)
        {
            speed = 0.5f;
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < bounds)
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -bounds)
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -bounds)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
        }
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < bounds)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
        }

        

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (zoom.z > minZoom + 1 * Time.deltaTime * scrollSpeed)
            {   
                transform.Translate(Vector3.back * Time.deltaTime * scrollSpeed);
            } else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, minZoom);
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (zoom.z < maxZoom - 1 * Time.deltaTime * scrollSpeed)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * scrollSpeed);
            } else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, maxZoom);
            }
        }
    }
}

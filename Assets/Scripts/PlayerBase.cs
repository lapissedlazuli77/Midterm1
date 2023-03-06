using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public float speed;
    public float rotspeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;

        if (Input.GetKey("w"))
        {
            currentPosition += transform.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey("a"))
        {
            currentPosition -= transform.right * Time.deltaTime * speed;
        }
        if (Input.GetKey("s"))
        {
            currentPosition -= transform.forward * Time.deltaTime * speed;
        }
        if (Input.GetKey("d"))
        {
            currentPosition += transform.right * Time.deltaTime * speed;
        }
        if (Input.GetKey("left"))
        {
            transform.Rotate(-Vector3.up * rotspeed * Time.deltaTime);
        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(Vector3.up * rotspeed * Time.deltaTime);
        }
        transform.position = currentPosition;
    }

}

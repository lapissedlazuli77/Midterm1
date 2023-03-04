using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;

        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            currentPosition.x -= speed;
        }
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            currentPosition.x += speed;
        }
        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            currentPosition.z += speed;
        }
        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            currentPosition.z -= speed;
        }
        transform.position = currentPosition;
    }
}

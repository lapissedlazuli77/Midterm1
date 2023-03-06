using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;

        if (currentPosition.x >= 110 || currentPosition.y >= 110 || currentPosition.z >= 110
            || currentPosition.x <= -110 || currentPosition.y <= -110 || currentPosition.z <= -110)
        {
            Destroy(this);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(this);
    }
}

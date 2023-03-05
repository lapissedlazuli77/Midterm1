using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleLight : MonoBehaviour
{
    public float rotspeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(-Vector3.right * rotspeed * Time.deltaTime);
    }
}
